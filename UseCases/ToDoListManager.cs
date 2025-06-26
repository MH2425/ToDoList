using Entities;

namespace UseCases
{
    public class ToDoListManager(IToDoItemRepository repository)
    {
        private readonly IToDoItemRepository repository = repository;

        public IEnumerable<ToDoItem> GetToDoItems()
        {
            return repository.GetItems();
        }

        public void AddToDoItem(ToDoItem item)
        {
            repository.Add(item);
        }

        public void MarkComplete(int id)
        {
            var item = repository.GetById(id);
            if (item != null)
            {
                item.IsCompleted = !item.IsCompleted;
                repository.Update(item);
            }
            else
            {
                throw new KeyNotFoundException($"Item ID:{id} not found");
            }
        }

        public void Delete(int id)
        {
            repository.Delete(id);
        }

        public void Update(ToDoItem item)
        {
            repository.Update(item);
        }
    }
}
