using System;
using Microsoft.EntityFrameworkCore;

namespace Mission06.Models
{
	public class MovieEntryContext : DbContext
	{
		// Constructor
		public MovieEntryContext(DbContextOptions<MovieEntryContext> options) : base(options)
		{
			
		}

		public DbSet<MovieEntry> entries { get; set; }

		protected override void OnModelCreating(ModelBuilder mb)
		{
			mb.Entity<MovieEntry>().HasData(
				new MovieEntry
				{
					MovieId = 1,
					Category = "Comedy",
					Title = "Tommyboy",
					Year = 1995,
					Director = "Peter Segal",
					Rating = "PG-13",
					Edited = false,
					LentTo = "Johnny",
					Notes = "This is Johnny's all-time favorite movie"
				},
                new MovieEntry
                {
                    MovieId = 2,
                    Category = "Romance/Fantasy",
                    Title = "About Time",
                    Year = 2013,
                    Director = "Richard Curtis",
                    Rating = "R",
                    Edited = false,
                    LentTo = "Johnny",
                    Notes = "This movie has the best message of any movie ever"
                },
                new MovieEntry
                {
                    MovieId = 3,
                    Category = "Fantasy/Adventure",
                    Title = "Lord of the Rings: Return of the King",
                    Year = 2003,
                    Director = "Peter Jackson",
                    Rating = "PG-13",
                    Edited = false,
                    LentTo = "Johnny",
                    Notes = "Favorite of all the movies, but the whole trilogy is the best of all time."
                }
            );
		}
	}
}

