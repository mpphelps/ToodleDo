using System.Collections.Generic;
using System.Collections.ObjectModel;
using ToodleDo.Core.Entities;
using ToodleDo.Core.Enums;

namespace ToodleDo.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ToodleDo.DataAccess.ToDoContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ToodleDo.DataAccess.ToDoContext context)
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

            #region Add Tags

            var tags = new Dictionary<string, Tag>
            {
                { "General", new Tag() { Id = 1, Name = "General" } },
                { "Splendid", new Tag() { Id = 2, Name = "Splendid" } },
                { "Cliff Jumpers", new Tag() { Id = 3, Name = "Cliff Jumper" } },
                { "Springer", new Tag() { Id = 4, Name = "Springer" } },
                { "Software Development", new Tag() { Id = 5, Name = "Software Development" } },
                { "Personal", new Tag() { Id = 6, Name = "Personal" } },
            };
            foreach (var tag in tags.Values)
            {
                context.Tags.AddOrUpdate(t => t.Id, tag);
            }

            #endregion

            #region Add Owners

            var owners = new List<Owner>
            {
                new Owner() { Id = 1, Name = "Michael Phelps" },
                new Owner() { Id = 2, Name = "Alex Ho" },
                new Owner() { Id = 3, Name = "Fred Gibbs" },
                new Owner() { Id = 4, Name = "Hemant Agarwal" },
                new Owner() { Id = 5, Name = "Paul Desjerlais" }
            };
            foreach (var owner in owners)
            {
                context.Owners.AddOrUpdate(o => o.Id, owner);
            }

            #endregion

            #region Add ToDo Items

            var toDoItems = new List<ToDoItem>
            {
                new ToDoItem()
                {
                    Id = 1,
                    Description = "Continue Self Paced Development",
                    Priority = Priority.Low,
                    StartDateTime = DateTime.Today,
                    DueDateTime = DateTime.Today.AddDays(7),
                    OwnerId = 1,
                    Tags = new ObservableCollection<Tag>()
                    {
                        tags["General"]
                    }
                },
                new ToDoItem()
                {
                    Id = 2,
                    Description = "Update HPD Goals",
                    Priority = Priority.Medium,
                    StartDateTime = DateTime.Today,
                    DueDateTime = DateTime.Today.AddDays(7),
                    OwnerId = 1,
                    Tags = new ObservableCollection<Tag>()
                    {
                        tags["General"]
                    }
                },
                new ToDoItem()
                {
                    Id = 3,
                    Description = "Complete Honeywell Compliance Training",
                    Priority = Priority.Medium,
                    StartDateTime = DateTime.Today,
                    DueDateTime = DateTime.Today.AddDays(7),
                    OwnerId = 1,
                    Tags = new ObservableCollection<Tag>()
                    {
                        tags["General"]
                    }
                },
                new ToDoItem()
                {
                    Id = 4,
                    Description = "Complete HCPP-23725: Errors in generation of XML file during SM translation",
                    Priority = Priority.High,
                    StartDateTime = DateTime.Today,
                    DueDateTime = DateTime.Today.AddDays(7),
                    OwnerId = 1,
                    Tags = new ObservableCollection<Tag>()
                    {
                        tags["Springer"]
                    }
                },
                new ToDoItem()
                {
                    Id = 5,
                    Description = "Complete HCPP-21685: TRB 1-DON9VAB- HIMA Translator Configures RS [Reset-Set] Block As SR [Set-Reset] Block",
                    Priority = Priority.High,
                    StartDateTime = DateTime.Today,
                    DueDateTime = DateTime.Today.AddDays(7),
                    OwnerId = 1,
                    Tags = new ObservableCollection<Tag>()
                    {
                        tags["Springer"]
                    }
                },
                new ToDoItem()
                {
                    Id = 6,
                    Description = "Watch KT Videos",
                    Priority = Priority.Low,
                    StartDateTime = DateTime.Today,
                    DueDateTime = DateTime.Today.AddDays(7),
                    OwnerId = 1,
                    Tags = new ObservableCollection<Tag>()
                    {
                        tags["Cliff Jumpers"]
                    }
                },
                new ToDoItem()
                {
                    Id = 7,
                    Description = "Review Authorization repo and provide feedback",
                    Priority = Priority.Low,
                    StartDateTime = DateTime.Today,
                    DueDateTime = DateTime.Today.AddDays(7),
                    OwnerId = 1,
                    Tags = new ObservableCollection<Tag>()
                    {
                        tags["Splendid"]
                    }
                }
            };
            foreach (var toDoItem in toDoItems)
            {
                context.ToDoItems.AddOrUpdate(t => t.Id, toDoItem);
            }

            #endregion
        }
    }
}
