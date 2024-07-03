using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RendezView.Core;
namespace RendezView.Application.Data;

public class AppointmentsContext : DbContext
{
    protected readonly IConfiguration Configuration;
    
    public AppointmentsContext(IConfiguration configuration)
    {
        Configuration = configuration;
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite(Configuration.GetConnectionString("AppointmentsDB"));
    }
    
    public DbSet<SchedulerAppointment> Appointments { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Contract> Contracts { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<SchedulerAppointment>(entity =>
        {
            entity.ToTable("Appointments");
            entity.HasKey(e => e.Id);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("Users");
            entity.HasKey(x => x.Id);

            entity.HasOne<Contract>()
                .WithOne(x => x.User)
                .HasForeignKey<User>(x => x.ContractId)
                .IsRequired(false);
        });

        modelBuilder.Entity<Contract>(entity =>
        {
            entity.ToTable("Contracts");
            entity.HasKey(x => x.Id);
            entity.HasOne<User>()
                .WithOne(x => x.Contract)
                .HasForeignKey<Contract>(x => x.UserId)
                .IsRequired(false);
        });
        base.OnModelCreating(modelBuilder);
    }
}