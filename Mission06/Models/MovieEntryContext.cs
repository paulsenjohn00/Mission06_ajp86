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
        public DbSet<Category> Categories { get; set; }

		protected override void OnModelCreating(ModelBuilder mb)
		{
            mb.Entity<Category>().HasData(
                new Category { CategoryId=1, CategoryName="Action/Adventure"},
                new Category { CategoryId = 2, CategoryName = "Comedy" },
                new Category { CategoryId = 3, CategoryName = "Thriller" },
                new Category { CategoryId = 4, CategoryName = "Romance" },
                new Category { CategoryId = 5, CategoryName = "Sci-Fi/Fantasy" }
                );

			mb.Entity<MovieEntry>().HasData(
				new MovieEntry
				{
					MovieId = 1,
					CategoryId = 2,
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
                    CategoryId = 4,
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
                    CategoryId = 5,
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

