using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using ToodleDo.Core.Entities;
using ToodleDo.DataAccess.EntityConfiguration;

namespace ToodleDo.DataAccess
{
    public class ToDoContext : DbContext
    {
        public ToDoContext()
        :base("name=ToDoContext")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }
        public virtual DbSet<Owner> Owners { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }
        public virtual DbSet<ToDoItem> ToDoItems { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ToDoItemConfiguration());
        }

    }
}