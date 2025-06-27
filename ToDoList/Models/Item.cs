namespace ToDoList.Models
{
    public class Item
    {
        public int Id { get; set; }
        public required string Text { get; set; }
        public bool IsCompleted { get; set; }
        public Item(int id, string text, bool isCompleted)
        {
            Id = id;
            Text = text;
            IsCompleted = isCompleted;
        }
        public Item() { } 
    }
}
