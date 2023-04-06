using KOTIT.Employees.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace KOTIT.Employees.Infrastructure.DBContexts;

public class BaseContext : DbContext
{
    public DbSet<Employee> Emlpoyees { get; set; }

    public BaseContext(DbContextOptions<BaseContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Employees
        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(x => x.Id);
            entity
                .Property(x => x.Id)
                .ValueGeneratedOnAdd();
            entity
                .Property(x => x.FirstName)
                .HasMaxLength(50)
                .IsRequired();
            entity
                .Property(x => x.LastName)
                .HasMaxLength(50)
                .IsRequired();
            entity
                .Property(x => x.BirthDate)
                .IsRequired();
            entity
                .Property(x=>x.CreatedDate)
                .HasDefaultValue(DateTime.UtcNow);
            entity
                .Property(x => x.LastModifiedDate)
                .ValueGeneratedOnUpdate()
                .HasDefaultValue(DateTime.UtcNow);
        });
    }
}
