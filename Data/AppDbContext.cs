using System.Reflection;
using Microsoft.EntityFrameworkCore;
using StudentAPI.Entity;
using StudentAPI.Data.EntityConfiguration;


namespace StudentAPI.Data;

public class AppDbContext : DbContext
{
    public DbSet<StudentEntity> Students { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        //
        base.OnModelCreating(modelBuilder);
    }



}
