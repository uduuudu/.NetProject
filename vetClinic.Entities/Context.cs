using Microsoft.EntityFrameworkCore;
using vetClinic.Entities.Models;
using Microsoft.Data.SqlClient.Server;


namespace vetClinic.Entities;
public class Context : DbContext {
    public DbSet<Appointment>? Appointments { get; set; }
    public DbSet<Breed>? Breeds { get; set; }
    public DbSet<Pet>? Pets { get; set; }
    public DbSet<Service>? Services { get; set; }
    public DbSet<User>? Users { get; set; }
    public DbSet<Species>? Speciess { get; set; }

    public Context(DbContextOptions<Context> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        #region Users

        builder.Entity<User>().ToTable("users");
        builder.Entity<Appointment>().HasKey(x => x.Id);

        #endregion

        #region Services

        builder.Entity<Service>().ToTable("services");
        builder.Entity<Appointment>().HasKey(x => x.Id);


        #endregion

        #region Specieses

        builder.Entity<Species>().ToTable("specieses");
        builder.Entity<Appointment>().HasKey(x => x.Id);


        #endregion

        #region Breeds

        builder.Entity<Breed>().ToTable("breeds");
        builder.Entity<Breed>().HasKey(x => x.Id);
        builder.Entity<Breed>().HasOne(x => x.Species)
                                    .WithMany(x => x.Breeds)
                                    .HasForeignKey(x => x.SpeciesID)
                                    .OnDelete(DeleteBehavior.Cascade);

        #endregion

        #region Pets

        builder.Entity<Pet>().ToTable("pets");
        builder.Entity<Pet>().HasKey(x => x.Id);
        builder.Entity<Pet>().HasOne(x => x.User)
                                    .WithMany(x => x.Pets)
                                    .HasForeignKey(x => x.UserID)
                                    .OnDelete(DeleteBehavior.Restrict);
        builder.Entity<Pet>().HasOne(x => x.Species)
                                    .WithMany(x => x.Pets)
                                    .HasForeignKey(x => x.SpeciesID)
                                    .OnDelete(DeleteBehavior.Restrict);
        builder.Entity<Pet>().HasOne(x => x.Breed)
                                    .WithMany(x => x.Pets)
                                    .HasForeignKey(x => x.BreedID)
                                    .OnDelete(DeleteBehavior.Restrict);

        #endregion

        #region Appointments

        builder.Entity<Appointment>().ToTable("appointments");
        builder.Entity<Appointment>().HasKey(x => x.Id);
        builder.Entity<Appointment>().HasOne(x => x.User)
                                    .WithMany(x => x.Appointments)
                                    .HasForeignKey(x => x.UserID)
                                    .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<Appointment>().HasOne(x => x.Pet)
                                    .WithMany(x => x.Appointments)
                                    .HasForeignKey(x => x.PetID)
                                    .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<Appointment>().HasOne(x => x.Service)
                                    .WithMany(x => x.Appointments)
                                    .HasForeignKey(x => x.ServiceID)
                                    .OnDelete(DeleteBehavior.Cascade);

        #endregion

        
    }
}