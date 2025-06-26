using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCases
{
    public interface IToDoItemRepository
    {
        void Add(ToDoItem item);
        void Delete(int id);
        ToDoItem? GetById(int id); // Nullable to handle cases where the item might not be found
        IEnumerable<ToDoItem> GetItems();
        void Update(ToDoItem item);
    }
}
