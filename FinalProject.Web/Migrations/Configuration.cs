namespace FinalProject.Web.Migrations
{
    using Models;
    using System;
    using System.Collections.ObjectModel;
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

            var norwayRat = new Pest { PestName = "Norway Rat" };
            var roofRat = new Pest { PestName = "Roof Rat" };
            var mouse = new Pest { PestName = "Mouse" };
            context.Pests.AddOrUpdate(
                p => p.PestName,
                new Pest { PestName = "Grass Spider" },
                new Pest { PestName = "Black and Yellow Garden Spider" },
                new Pest { PestName = "Black Widow Spider" },
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
                norwayRat,
                roofRat,
                mouse

                );
            


            var firstQuestion = new Question { Text = "How many legs?" };

            var rats = new Collection<Pest>() { norwayRat, roofRat, mouse };
            firstQuestion.Answers = new Collection<Answer>()
            {
                new Answer() { Text = "4", AssociatedPest = rats }
            };


            var secondQuestion = new Question
            {
                Text = "Is it Big or Small?",
                Answers = new Collection<Answer> {
                    new Answer() { Text = "Big",AssociatedPest = new Collection<Pest>() { norwayRat} },
                    new Answer() { Text = "Small", AssociatedPest = new Collection<Pest>() { roofRat, mouse }}
                }
            };

            var thirdQuestion = new Question
            {
                Text = "Where was it located?",
                Answers = new Collection<Answer> {
                    new Answer() { Text = "Roof or Tree", AssociatedPest = new Collection<Pest>() { roofRat } },
                    new Answer() { Text = "In or Around House", AssociatedPest = new Collection<Pest>() { mouse }}
            }
            };

            context.Questions.AddOrUpdate(p => p.Text,
                firstQuestion,
                secondQuestion,
                thirdQuestion
                );


            context.SaveChanges();

        }

    }
}

