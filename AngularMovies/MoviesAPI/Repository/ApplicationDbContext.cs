using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MoviesAPI.Models;
using System.Diagnostics.CodeAnalysis;

namespace MoviesAPI.Repository
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext([NotNullAttribute] DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<Genre> Genres { get; set; }
        public DbSet<Actor> Actors { get; set; }

        public DbSet<MovieTheater>MovieTheaters { get; set; }

        public DbSet<Movie> Movies { get; set; }

        public DbSet<MovieGenre> movieGenres { get; set; }

        public DbSet<MovieTheaterMovies> MovieTheaterMovies { get; set; }

        public DbSet<MovieActor> MovieActors { get; set; }
        public DbSet<Rating> Ratings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MovieTheater>()
                .Property(mt => mt.Location)
                .HasColumnType("geometry")
                .HasSrid(4326);

            modelBuilder.Entity<MovieActor>()
                .HasKey(x => new { x.MovieID, x.ActorID });

            modelBuilder.Entity<MovieTheaterMovies>()
                .HasKey(x => new { x.MovieID, x.MovieTheaterID });

            modelBuilder.Entity<MovieGenre>()
                .HasKey(x => new { x.MovieID, x.GenreID });

            base.OnModelCreating(modelBuilder);
        }
    }
}
