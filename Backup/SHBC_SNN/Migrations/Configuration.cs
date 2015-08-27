namespace SHBC_SNN.Migrations
{
    using SHBC_SNN.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SHBC_SNN.Models.SnnDb>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true; // EF won't make any changes unless you tell it: True for dev, False for live.
        }

        protected override void Seed(SHBC_SNN.Models.SnnDb context) // EF populates Db with initial data.
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
            context.SnnCases.AddOrUpdate(r => r.CaseNo,
                new SnnCase { CaseNo = "Snn1", Address = "Surrey Heath House", Uprn = 1000123 },
                new SnnCase { CaseNo = "Snn2", Address = "Camberley Library", Uprn = 1000124 },
                new SnnCase { CaseNo = "Snn3", Address = "Sandu Manor", Uprn = 1000125,
                    Contacts = 
                        new List<SnnContacts> { new SnnContacts { FirstName = "Matt", LastName="Lindsay", Email = "matt.lindsay@surreyheath.gov.uk", PrimaryContact = true }}},
                new SnnCase
                {
                    CaseNo = "Snn4",
                    Address = "McDavid Court",
                    Uprn = 1000126,
                    Contacts =
                        new List<SnnContacts> {
                        new SnnContacts { FirstName = "James", LastName = "Rutter", Email = "james.rutter@surreyheath.gov.uk", PrimaryContact = true },
                        new SnnContacts { FirstName = "David", LastName = "McDavid", Email = "david.mcdermott@surreyheath.gov.uk", PrimaryContact = false }
                    }
                }); /* Migration add / updates run this Seed method.
                     * PM>Update-Database -Verbose
                     * 
                     * Now we want to modify the view on the Home Controller Index action.
                     * 
                     * PM>Update-Database -Force -Verbose
                     */
        }   
    }
}
