namespace FinalProject.Web.Migrations
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<FinalProject.Web.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(FinalProject.Web.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            context.Pests.AddOrUpdate(
                p => p.PestName,
                new Pest { PestName = "Grass Spider", NumberOfLegs = 8, URLPic = "http://www.spiders.us/files/agelenopsis-spp-1.jpg", URLInfo = "http://www.spiders.us/species/agelenopsis-spp/" },
                new Pest { PestName = "Black and Yellow Garden Spider", NumberOfLegs = 8, URLPic = "http://www.spiders.us/files/argiope-aurantia-1.jpg", URLInfo = "http://www.spiders.us/species/argiope-aurantia/" },
                new Pest { PestName = "Black Widow Spider", NumberOfLegs = 8, URLPic = "http://www.spiders.us/files/latrodectus-mactans-1.jpg", URLInfo = "http://www.spiders.us/species/latrodectus-mactans/" },
                new Pest { PestName = "Brown Recluse Spider" },
                new Pest { PestName = "Wolf Spider" },
                new Pest { PestName = "House Spider" },
                new Pest { PestName = "American Cockroach" },
                new Pest { PestName = "German Cockroach" },
                new Pest { PestName = "Smokey Brown Cockroach" },
                new Pest { PestName = "Carpenter Ant" },
                new Pest { PestName = "Fire Ants" },
                new Pest { PestName = "Little Black Ants" },
                new Pest { PestName = "Crazy Ants" },
                new Pest { PestName = "Velvet Ants" },
                new Pest { PestName = "Indian Meal Moth" },
                new Pest { PestName = "Weeval" },
                new Pest { PestName = "Saw Tooth Grain Beetle" },
                new Pest { PestName = "Larger Cabinet Beetle" },
                new Pest { PestName = "Norway Rat" },
                new Pest { PestName = "Roof Rat" },
                new Pest { PestName = "Mouse" }

                );
        }

    }
}

