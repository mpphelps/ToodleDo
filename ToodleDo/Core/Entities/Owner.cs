using System.Collections.ObjectModel;

namespace ToodleDo.Core.Entities
{
    public class Owner
    {
        public Owner()
        {
            ToDoItems = new ObservableCollection<ToDoItem>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ObservableCollection<ToDoItem> ToDoItems { get; set; }
    }
}