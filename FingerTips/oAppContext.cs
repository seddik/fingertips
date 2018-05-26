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
    public class oAppContext : DbContext
    {
        public oAppContext() : base(nameOrConnectionString: "Default")
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

        static oAppContext _instance;
        public static oAppContext Instance => _instance ?? (_instance = new oAppContext());

        internal void SaveChangesAndUpdate()
        {

            this.SaveChanges();
            MainModelView.Instance.UpdateAll();
        }
    }

    public class AppInitializer : CreateDatabaseIfNotExists<oAppContext>
    {
    }
}
