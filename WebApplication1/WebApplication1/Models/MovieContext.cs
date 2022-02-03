using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1_A.Models;

namespace WebApplication1_A.Models
{
    public class MovieContext: DbContext
    {
        public MovieContext (DbContextOptions<MovieContext> options) : base(options)
        {

        }

        public DbSet<ApplicationResponse> Movies { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Category>().HasData(
                new Category { CategoryID = 1, CategoryName = "Science Fantasy"},
                new Category { CategoryID = 2, CategoryName = "Fantasy"},
                new Category { CategoryID = 3, CategoryName = "Science Fiction"},
                new Category { CategoryID = 4, CategoryName = "Adventure"},
                new Category {  CategoryID = 5, CategoryName = "Complete Waste of Time (Romance)"},
                new Category { CategoryID = 6, CategoryName = "Partial Waste of Time (Romantic Comedy)"},
                new Category { CategoryID = 7, CategoryName = "The Perfect Movie- The Princess Bride"}
            );

            mb.Entity<ApplicationResponse>().HasData(
                new ApplicationResponse
                {
                    MovieID = 1,
                    Rating = "PG-13",
                    Edit = false,
                    LentTo = "",
                    Notes = "",
                    CategoryID = 1,
                    Title = "Rogue One: A Star Wars Story",
                    Year = "2016",
                    Director = "Gareth Edwards"
                },
                new ApplicationResponse
                {
                    MovieID = 2,
                    Rating = "PG-13",
                    Edit = false,
                    LentTo = "",
                    Notes = "",
                    CategoryID = 1,
                    Title = "Star Wars: Empire Strikes Back",
                    Year = "1980",
                    Director = "Irvin Kershner"
                },
                new ApplicationResponse
                {
                    MovieID = 3,
                    Rating = "PG",
                    Edit = false,
                    LentTo = "",
                    Notes = "",
                    CategoryID = 2,
                    Title = "How to Train Your Dragon",
                    Year = "2010",
                    Director = "Chris Sanders"
                }
            ) ;
        }
    }
}
