using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Media;

namespace FingerTips
{
    public class AppContext : DbContext
    {
        public AppContext() : base(nameOrConnectionString: "Default")
        {
            Database.SetInitializer(new AppInitializer());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.HasDefaultSchema("public");
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<List> Lists { get; set; }
        public DbSet<Card> Cards { get; set; }
        public DbSet<Label> Labels { get; set; }
        public DbSet<Member> Members { get; set; }

        static AppContext _instance;
        public static AppContext Instance => _instance ?? (_instance = new AppContext());
    }

    public class AppInitializer : CreateDatabaseIfNotExists<AppContext>
    {
    }
}
