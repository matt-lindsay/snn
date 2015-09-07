namespace snn.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<snn.Models.snnContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(snn.Models.snnContext context)
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

            context.CaseStatus.AddOrUpdate(
                a => a.StatusDescription,
                new Models.CaseStatus { StatusDescription = "Planning Approved" },
                new Models.CaseStatus { StatusDescription = "Building Commenced" },
                new Models.CaseStatus { StatusDescription = "Building Completion" },
                new Models.CaseStatus { StatusDescription = "Payment" },
                new Models.CaseStatus { StatusDescription = "Postcode Request" },
                new Models.CaseStatus { StatusDescription = "Pre Release" },
                new Models.CaseStatus { StatusDescription = "Complete NYB" },
                new Models.CaseStatus { StatusDescription = "Complete LIVE" },
                new Models.CaseStatus { StatusDescription = "Inactive" },
                new Models.CaseStatus { StatusDescription = "Inactive Closed" }
                );

            context.CaseTypes.AddOrUpdate(
                b => b.TypeDescription,
                new Models.CaseType { TypeDescription = "Conversion" },
                new Models.CaseType { TypeDescription = "Demolition" },
                new Models.CaseType { TypeDescription = "New Build" },
                new Models.CaseType { TypeDescription = "Renaming / Renumbering" },
                new Models.CaseType { TypeDescription = "Retrospective" },
                new Models.CaseType { TypeDescription = "N/A" }
                );
        }
    }
}
