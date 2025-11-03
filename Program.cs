using Microsoft.EntityFrameworkCore;
using ApiDemo.Data;
using ApiDemo.Models;

var builder = WebApplication.CreateBuilder(args);

// --- DbContext ---
var cs = builder.Configuration.GetConnectionString("Postgres")
         ?? Environment.GetEnvironmentVariable("POSTGRES_CONNECTION")
         ?? "Host=localhost;Port=5432;Database=apidemo;Username=postgres;Password=postgres";
builder.Services.AddDbContext<AppDb>(opt => opt.UseNpgsql(cs));

// --- Swagger ---
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// --- CORS (untuk Next.js/Vite) ---
var corsPolicy = "_defaultCors";
builder.Services.AddCors(o =>
{
    o.AddPolicy(corsPolicy, p =>
        p.WithOrigins(builder.Configuration.GetSection("Cors:Origins").Get<string[]>() ?? Array.Empty<string>())
         .AllowAnyHeader()
         .AllowAnyMethod());
});

var app = builder.Build();

// Auto-migrate saat start (dev-friendly)
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDb>();
    db.Database.Migrate();
}

// Swagger hanya on di Development (optional: boleh juga on selalu)
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(corsPolicy);

// --- Minimal API ---
app.MapGet("/", () => Results.Ok(new { status = "ok", message = "ApiDemo up" }));

app.MapGet("/todos", async (AppDb db) =>
    await db.Todos.AsNoTracking().ToListAsync());

app.MapGet("/todos/{id:int}", async (int id, AppDb db) =>
    await db.Todos.FindAsync(id) is { } todo
        ? Results.Ok(todo)
        : Results.NotFound());

app.MapPost("/todos", async (TodoItem body, AppDb db) =>
{
    db.Todos.Add(body);
    await db.SaveChangesAsync();
    return Results.Created($"/todos/{body.Id}", body);
});

app.MapPut("/todos/{id:int}", async (int id, TodoItem body, AppDb db) =>
{
    var todo = await db.Todos.FindAsync(id);
    if (todo is null) return Results.NotFound();

    todo.Title = body.Title;
    todo.Done = body.Done;
    await db.SaveChangesAsync();
    return Results.NoContent();
});

app.MapDelete("/todos/{id:int}", async (int id, AppDb db) =>
{
    var todo = await db.Todos.FindAsync(id);
    if (todo is null) return Results.NotFound();

    db.Remove(todo);
    await db.SaveChangesAsync();
    return Results.NoContent();
});

app.Run();
