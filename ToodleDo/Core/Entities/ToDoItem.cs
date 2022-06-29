using System;
using System.Collections.ObjectModel;
using System.Data.Entity.Infrastructure;
using ToodleDo.Core.Enums;

namespace ToodleDo.Core.Entities
{
    public class ToDoItem
    {
        public ToDoItem()
        {
            Tags = new ObservableCollection<Tag>();
        }
        public int Id { get; set; }
        public string Description { get; set; }
        public Priority Priority { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime DueDateTime { get; set; }
        public virtual ObservableCollection<Tag> Tags { get; set; }
        public virtual Owner Owner { get; set; }
        public int OwnerId { get; set; }


    }
}