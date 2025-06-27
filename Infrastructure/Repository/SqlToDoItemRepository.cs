using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases;

namespace Infrastructure.Repository
{
    public class SqlToDoItemRepository : IToDoItemRepository
    {
        private readonly ToDoContext _context;
        public SqlToDoItemRepository(ToDoContext context)
        {
            _context = context;
        }

        public void Add(ToDoItem item)
        {
            item.Id = 0;
            _context.ToDoItems.Add(item);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var item = _context.ToDoItems.Find(id);
            if (item != null)
            {
                _context.ToDoItems.Remove(item);
                _context.SaveChanges();
            }
            else
            {
                throw new KeyNotFoundException($"Item with id {id} can not found");
            }
        }

        public ToDoItem? GetById(int id)
        {
            return _context.ToDoItems.Find(id);
        }

        public IEnumerable<ToDoItem> GetItems() 
        { 
            return _context.ToDoItems.ToList();    
        }

        public void Update(ToDoItem item)
        {
            var existingItem = GetById(item.Id);
            if (existingItem != null)
            {
                existingItem.Text = item.Text;
                existingItem.IsCompleted = item.IsCompleted;
                _context.SaveChanges();
            }
            else
            {
                throw new KeyNotFoundException($"Item with id {item.Id} can not found");
            }
        }
    }
}
