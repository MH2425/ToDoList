using Entities;

namespace UseCases
{
    public class ToDoListManager
    {
        private readonly IUnitOfWork<ToDoItem> _unitOfWork;

        public ToDoListManager(IUnitOfWork<ToDoItem> unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<ToDoItem> GetToDoItems()
        {
            return _unitOfWork.Db.Set<ToDoItem>().ToList();
        }

        public void AddToDoItem(ToDoItem item)
        {
            _unitOfWork.Db.Set<ToDoItem>().Add(item);
            _unitOfWork.Save();
        }

        /// <summary>
        /// Toggle completion of each item in database
        /// </summary>
        /// <param name="id"></param>
        /// <exception cref="KeyNotFoundException"></exception>
        public void MarkComplete(int id)
        {
            var item = _unitOfWork.Db.Set<ToDoItem>().Find(id);
            if (item != null)
            {
                item.IsCompleted = !item.IsCompleted;
                _unitOfWork.Edit(item);
                _unitOfWork.Save();
            }
            else
            {
                throw new KeyNotFoundException($"Item ID:{id} not found");
            }
        }

        public void Delete(int id)
        {
            var item = _unitOfWork.Db.Set<ToDoItem>().Find(id);
            if (item != null)
            {
                _unitOfWork.Db.Set<ToDoItem>().Remove(item);
                _unitOfWork.Save();
            }
            else
            {
                throw new KeyNotFoundException($"Item ID:{id} not found");
            }
        }

        public void Update(ToDoItem item)
        {
            _unitOfWork.Edit(item);
            _unitOfWork.Save();
        }

        /// <summary>
        /// Reset the database
        /// </summary>
        public void ClearItems()
        {
            var items = GetToDoItems().ToList();
            foreach (var item in items)
            {
                _unitOfWork.Db.Set<ToDoItem>().Remove(item);
            }
            _unitOfWork.Save();
        }
    }
}
