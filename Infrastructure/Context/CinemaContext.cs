using System;
using System.Collections.Generic;
using Core.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Context
{
    public partial class CinemaContext : IdentityDbContext<User>
    {
        protected readonly IConfiguration Configuration;

        public CinemaContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
        }
        public virtual DbSet<Booking> Bookings { get; set; }

        public virtual DbSet<Country> Countries { get; set; }

        public virtual DbSet<Genre> Genres { get; set; }

        public virtual DbSet<Hall> Halls { get; set; }

        public virtual DbSet<Movie> Movies { get; set; }

        public virtual DbSet<Seat> Seats { get; set; }

        public virtual DbSet<Session> Sessions { get; set; }

        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Booking>(entity =>
            {
                entity.HasKey(e => e.BookingId).HasName("PK_Booking");

                entity.Property(e => e.TicketNumber)
                    .HasMaxLength(14)
                    .IsUnicode(false);

                entity.HasOne(d => d.Seat).WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.SeatId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Bookings_Seats");

                entity.HasOne(d => d.Session).WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.SessionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Booking_Session");


            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.HasKey(e => e.CountryId).HasName("PK__Countrie__10D1609FB9CC7701");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Genre>(entity =>
            {
                entity.HasKey(e => e.GenreId).HasName("PK__Genres__0385057EAAB28AAB");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Hall>(entity =>
            {
                entity.HasKey(e => e.HallId).HasName("PK_Hall");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Movie>(entity =>
            {
                entity.HasKey(e => e.MovieId).HasName("PK_Movie");

                entity.Property(e => e.Director)
                    .HasMaxLength(80)
                    .IsUnicode(false);
                entity.Property(e => e.ReleaseData).HasColumnType("date");
                entity.Property(e => e.Synopsis).IsUnicode(false);
                entity.Property(e => e.Time).HasPrecision(0);
                entity.Property(e => e.Title)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasMany(d => d.Countries).WithMany(p => p.Movies)
                    .UsingEntity<Dictionary<string, object>>(
                        "MovieCountry",
                        r => r.HasOne<Country>().WithMany()
                            .HasForeignKey("CountryId")
                            .OnDelete(DeleteBehavior.Cascade)
                            .HasConstraintName("FK__MovieCoun__Count__59C55456"),
                        l => l.HasOne<Movie>().WithMany()
                            .HasForeignKey("MovieId")
                            .OnDelete(DeleteBehavior.Cascade)
                            .HasConstraintName("FK__MovieCoun__Movie__58D1301D"),
                        j =>
                        {
                            j.HasKey("MovieId", "CountryId").HasName("PK__MovieCou__AADF8213D87DD9CD");
                            j.ToTable("MovieCountries");
                        });

                entity.HasMany(d => d.Genres).WithMany(p => p.Movies)
                    .UsingEntity<Dictionary<string, object>>(
                        "MovieGenre",
                        r => r.HasOne<Genre>().WithMany()
                            .HasForeignKey("GenreId")
                            .OnDelete(DeleteBehavior.Cascade)
                            .HasConstraintName("FK__MovieGenr__Genre__31B762FC"),
                        l => l.HasOne<Movie>().WithMany()
                            .HasForeignKey("MovieId")
                            .OnDelete(DeleteBehavior.Cascade)
                            .HasConstraintName("FK__MovieGenr__Movie__30C33EC3"),
                        j =>
                        {
                            j.HasKey("MovieId", "GenreId").HasName("PK__MovieGen__BBEAC44D042C98CF");
                            j.ToTable("MovieGenres");
                        });
            });

            modelBuilder.Entity<Seat>(entity =>
            {
                entity.HasKey(e => e.SeatId).HasName("PK_Place");

                entity.HasOne(d => d.Hall).WithMany(p => p.Seats)
                    .HasForeignKey(d => d.HallId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Place_Hall");

                entity.HasOne(d => d.Session).WithMany(p => p.Seats)
                    .HasForeignKey(d => d.SessionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Place_Session");
            });

            modelBuilder.Entity<Session>(entity =>
            {
                entity.HasKey(e => e.SessionsId).HasName("PK_Session");

                entity.Property(e => e.Date).HasColumnType("date");
                entity.Property(e => e.Time).HasPrecision(0);

                entity.HasOne(d => d.Hall).WithMany(p => p.Sessions)
                    .HasForeignKey(d => d.HallId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Sessions_Halls");

                entity.HasOne(d => d.Movie).WithMany(p => p.Sessions)
                    .HasForeignKey(d => d.MovieId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Session_Movie");
            });



            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}