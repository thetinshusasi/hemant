using Contact.DAL.DataModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact.DAL.Contexts
{
    public class SqlContext : DbContext
    {
        public SqlContext() : base("ContactDB")
        {
            //this.Configuration.LazyLoadingEnabled = true;
            //this.Configuration.ProxyCreationEnabled = true;
            this.Configuration.LazyLoadingEnabled = true;
            Database.SetInitializer<SqlContext>(new DropCreateDatabaseIfModelChanges<SqlContext>());


        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();


        }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Logo> Logos { get; set; }
        public virtual DbSet<Organisation> Organisations { get; set; }
        public virtual DbSet<Position> Positions { get; set; }
        public virtual DbSet<Slogan> Slogans { get; set; }
        public virtual DbSet<State> States { get; set; }
        public virtual DbSet<Contact.DAL.DataModels.Contact> Contacts { get; set; }





    }
}
