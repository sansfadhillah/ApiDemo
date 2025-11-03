using Microsoft.EntityFrameworkCore;
using ApiDemo.Models;

namespace ApiDemo.Data;

public class AppDb(DbContextOptions<AppDb> options) : DbContext(options)
{
    public DbSet<TodoItem> Todos => Set<TodoItem>();
}
