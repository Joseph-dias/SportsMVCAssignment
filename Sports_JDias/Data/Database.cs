using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Sports_JDias.Data
{
    public class Database : DbContext
    {
        public Database()
        {
            Configuration.LazyLoadingEnabled = false;
        }
        public virtual DbSet<Entities.PlayerEntity> players { get; set; }
        public virtual DbSet<Entities.GameEntity> games { get; set; }
        public virtual DbSet<Entities.StatEntity> stats { get; set; }
    }

    public class AppDbInitializer : DropCreateDatabaseIfModelChanges<Database>
    {

    }
}