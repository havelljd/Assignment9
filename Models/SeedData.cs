using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//I'm not sure why I chose I Am Legend as seed data, or why I kept in here, but I don't want to take it out. Anyways. REMEMBER TO ADD THE STUFF IN STARTUP FOR SEEDDATA TO WORK

namespace DateMe.Models
{
    public class SeedData
    {
        public static void EnsurePopulated (IApplicationBuilder application)
        {
            MovieDbContext context = application.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<MovieDbContext>();

            if(context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }
            if (!context.Movies.Any())
            {
                context.Movies.AddRange(

                    new EnterMovieModel
                    {
                        category = "Action",
                        title = "I Am Legend",
                        year = 2008,
                        director = "Some guy",
                        rating = "PG-13",
                        edited = false,
                        lentto = "Nobody",
                        notes = "None"
                    }
                    );
                context.SaveChanges();
            }
        }
    }
}
