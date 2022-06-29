using System.Data.Entity.ModelConfiguration;
using ToodleDo.Core.Entities;

namespace ToodleDo.DataAccess.EntityConfiguration
{
    public class ToDoItemConfiguration : EntityTypeConfiguration<ToDoItem>
    {
        public ToDoItemConfiguration()
        {
            Property(t => t.Description)
                .IsRequired()
                .HasMaxLength(2000);

            Property(t => t.StartDateTime).IsRequired();
            Property(t => t.DueDateTime).IsRequired();
            Property(t => t.Priority).IsRequired();

            HasRequired(t => t.Owner)
                .WithMany(o => o.ToDoItems)
                .HasForeignKey(t => t.OwnerId)
                .WillCascadeOnDelete(false);

            HasMany(t => t.Tags)
                .WithMany(t => t.ToDoItems)
                .Map(m =>
                {
                    m.ToTable("ToDoTags");
                    m.MapLeftKey("ToDoId");
                    m.MapRightKey("TagId");
                });

        }
    }
}