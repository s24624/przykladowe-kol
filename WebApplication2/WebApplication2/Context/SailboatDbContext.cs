using Microsoft.EntityFrameworkCore;
using WebApplication2.Models;

namespace WebApplication2.Context;

public class SailboatDbContext : DbContext
{
    public SailboatDbContext() { }
        public SailboatDbContext(DbContextOptions<SailboatDbContext> options) : base(options)
        {
        }
        
        public virtual DbSet<ClientCategory> ClientCategories { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<BoatStandard> BoatStandards { get; set; }
        public virtual DbSet<Reservation> Reservations { get; set; }
        public virtual DbSet<Sailboat> Sailboats { get; set; }
        public virtual DbSet<SailboatReservation> SailboatReservations { get; set; }
        
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
            optionsBuilder.UseSqlServer("Data Source=localhost, 1433; User=SA; Password=yourStrong(!)Password; Initial Catalog=apdb; Integrated Security=False;Connect Timeout=30;Encrypt=False");
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ClientCategory>(opt =>
            {
                opt.HasKey(e => e.IdClientCategory);
                opt.Property(e => e.Name).HasMaxLength(100).IsRequired();
                opt.Property(e => e.DiscountPerc).IsRequired();
            });
            modelBuilder.Entity<Client>(opt =>
            {
                opt.HasKey(e => e.IdClientCategory);
                opt.Property(e => e.Name).HasMaxLength(100).IsRequired();
                opt.HasOne(e=>e.ClientCategory).WithMany(e=>e.Clients)
                    .HasForeignKey(e=>e.IdClientCategory);
            });
            modelBuilder.Entity<BoatStandard>(opt =>
            {
                opt.HasKey(e => e.IdBoatStandard);
                opt.Property(e => e.Name).HasMaxLength(100).IsRequired();
                opt.Property(e => e.Level).IsRequired();
            });
            modelBuilder.Entity<Reservation>(opt =>
            {
                opt.HasKey(e => e.IdReservation);
                opt.Property(e=>e.Fulfilled).IsRequired();
                opt.Property(e=>e.CancelReaeson).IsRequired();
                opt.Property(e=>e.NumOfBoats).IsRequired();
                opt.Property(e=>e.DateFrom).IsRequired();
                opt.Property(e=>e.DateTo).IsRequired();
                opt.Property(e=>e.Capacity).IsRequired();
                opt.Property(e=>e.Price).IsRequired();

                opt.HasOne(e=>e.Client).WithMany(e=>e.Reservations)
                    .HasForeignKey(e=>e.IdClient);
                opt.HasOne(e=>e.BoatStandard).WithMany(e=>e.Reservations)
                    .HasForeignKey(e=>e.IdBoatStandard);
            });

            modelBuilder.Entity<Sailboat>(opt =>
            {
                opt.HasKey(e=>e.IdSailboat);
                opt.Property(e => e.Name).IsRequired().HasMaxLength(100);

                opt.HasOne(e => e.BoatStandard).WithMany(e => e.Sailboats).
                    HasForeignKey(e => e.IdBoatStandard);
            });
            modelBuilder.Entity<SailboatReservation>(opt =>
            {
                opt.HasKey(e => new
                {
                    e.IdReservation,
                    e.IdSailboat
                });
                opt.HasOne(e => e.Reservation).WithMany(e => e.SailboatReservations)
                    .HasForeignKey(e => e.IdReservation);
                opt.HasOne(e => e.Sailboat).WithMany(e => e.SailboatReservations)
                    .HasForeignKey(e => e.IdSailboat).OnDelete(DeleteBehavior.Restrict);;

            });
        }
    
    
    
}