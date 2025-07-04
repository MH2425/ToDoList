using Entities;

namespace UseCases
{
    public class ToDoListManager
    {
        private readonly IUnitOfWork<ToDoItem> _unitOfWork;
        private readonly IRepository<ToDoItem> _repository;

        public ToDoListManager(IUnitOfWork<ToDoItem> unitOfWork, IRepository<ToDoItem> repository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
        }

        public IEnumerable<ToDoItem> GetToDoItems()
        {
            return _repository.GetAll();
        }

        public void AddToDoItem(ToDoItem item)
        {
            _repository.Add(item);
            _unitOfWork.Save();
        }

        /// <summary>
        /// Toggle completion of each item in database
        /// </summary>
        /// <param name="id"></param>
        /// <exception cref="KeyNotFoundException"></exception>
        public void MarkComplete(int id)
        {
            var item = _repository.GetById(id);
            if (item != null)
            {
                item.IsCompleted = !item.IsCompleted;
                _repository.Update(item);
                _unitOfWork.Save();
            }
            else
            {
                throw new KeyNotFoundException($"Item ID:{id} not found");
            }
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
            _unitOfWork.Save();
        }

        public void Update(ToDoItem item)
        {
            _repository.Update(item);
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
                _repository.Delete(item.Id);
            }
            _unitOfWork.Save();
        }
    }
}
