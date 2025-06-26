namespace ToDoList.Models
{
    public class ToDoListViewModel
    {
        public required IEnumerable<Item> Items { get; init; } // init => set after initialise new object of this class
    }
}
