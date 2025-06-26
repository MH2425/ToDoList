using Entities;
using UseCases;

namespace Infrastructure
{
    public class InMemoryToDoItemRepository : IToDoItemRepository
    {
        private readonly List<ToDoItem> _items;
        private int _nextId = 1;  

        public InMemoryToDoItemRepository()
        {
            _items = [];
        }

        public void Add(ToDoItem item)
        {
            // Assign ID
            item.Id = _nextId++;
            _items.Add(item);
        }

        public void Delete(int id)
        {
            var item = _items.FirstOrDefault(i => i.Id == id);
            if (item != null)
            {
                _items.Remove(item);
            }
            else
            {
                throw new KeyNotFoundException($"Item with id {id} not found.");
            }
        }

        public ToDoItem? GetById(int id)
        {
            return _items.FirstOrDefault(i => i.Id == id);
        }

        public IEnumerable<ToDoItem> GetItems()
        {
            return _items;
        }

        public void Update(ToDoItem item)
        {
            var existingItem = _items.FirstOrDefault(i => i.Id == item.Id);
            if (existingItem != null)
            {
                existingItem.Text = item.Text;
                existingItem.IsCompleted = item.IsCompleted;
            }
            else
            {
                throw new KeyNotFoundException($"Item with id {item.Id} not found.");
            }
        }
    }
}
