using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SHBC_SNN.Models
{
    public class SnnDb : DbContext // Derives from DbContext class (Entity Framework).
    {
        public SnnDb() : base("name = DefaultConnection") // Point constructor of DbContext towards Web.Config file.
        {

        }

        /* Migrations to alter schema, and add testing data.
         * Use Package Manager Console.
         * Type then TAB for auto-completion.
         * Enable migrations PM>Enable-Migrations -ContextTypeName SnnDb (Code First Migrations, Migrations folder added).
         * 
         */


        public DbSet<SnnCase> SnnCases { get; set; }
        public DbSet<SnnContacts> SnnContacts { get; set; }

        // From here modify the Home Controller to show the data from this database.
    }
}