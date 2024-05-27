using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MeetingRoomBooking.Models;

namespace MeetingRoomBooking.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<MeetingRoom> MeetingRooms { get; set; }
        public DbSet<Reservation> Reservations { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<MeetingRoom>()
                .HasKey(m => m.Id);

            builder.Entity<MeetingRoom>()
                .HasIndex(m => m.Name)
                .IsUnique();

            builder.Entity<Reservation>()
                .HasOne(r => r.MeetingRoom)
                .WithMany(m => m.Reservations)
                .HasForeignKey(r => r.MeetingRoomId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<MeetingRoom>()
                .Property(m => m.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Entity<Reservation>()
                .Property(r => r.ReservedBy)
                .IsRequired()
                .HasMaxLength(100);

            builder.Entity<Reservation>()
                .Property(r => r.Date)
                .IsRequired();  // Certifique-se de que a propriedade 'Date' é obrigatória
        }
    }
}