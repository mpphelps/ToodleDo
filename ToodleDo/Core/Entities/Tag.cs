using System.Collections.ObjectModel;

namespace ToodleDo.Core.Entities
{
    public class Tag
    {
        public Tag()
        {
            ToDoItems = new ObservableCollection<ToDoItem>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ObservableCollection<ToDoItem> ToDoItems { get; set; }
    }
}