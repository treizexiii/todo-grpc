using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Npgsql;
using Tools.TransactionManager;

namespace Persistence.Database.Context;

public class TodoDb : DbContext, IDbContext
{
    public TodoDb(DbContextOptions<TodoDb> options) : base(options)
    {
    }

    public DbSet<Todo> Todos { get; set; } = null!;
    public DbSet<Item> Items { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }

    public Task SeedAsync()
    {
        Console.WriteLine("Seeding database");
        return Task.CompletedTask;
    }

    public async Task<IDbContextTransaction> BeginTransactionAsync()
    {
        return await base.Database.BeginTransactionAsync();
    }

    public async Task SaveChangesAsync()
    {
        await base.SaveChangesAsync();
    }

    public IDbContextTransaction? CurrentTransaction => base.Database.CurrentTransaction;
}