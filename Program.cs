using ApiDemo.Data;
using ApiDemo.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Ambil dari appsettings.json (lokal) atau ENV (Docker)
var cs = builder.Configuration.GetConnectionString("Default")
         ?? Environment.GetEnvironmentVariable("DB_CONNECTION");

builder.Services.AddDbContext<AppDb>(opt => opt.UseNpgsql(cs));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();

// CRUD sederhana
app.MapGet("/todos", async (AppDb db) => await db.Todos.ToListAsync());

app.MapPost("/todos", async (AppDb db, TodoItem body) =>
{
    db.Todos.Add(body);
    await db.SaveChangesAsync();
    return Results.Created($"/todos/{body.Id}", body);
});

app.MapPut("/todos/{id:int}", async (int id, AppDb db, TodoItem body) =>
{
    var todo = await db.Todos.FindAsync(id);
    if (todo is null) return Results.NotFound();
    todo.Title = body.Title;
    todo.Done  = body.Done;
    await db.SaveChangesAsync();
    return Results.Ok(todo);
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
