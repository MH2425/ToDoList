using Entities;

namespace UseCases
{
    public class ToDoListManager(IUnitOfWork<ToDoItem> unitOfWork)
    {
        private readonly IUnitOfWork<ToDoItem> _unitOfWork = unitOfWork;

        public IEnumerable<ToDoItem> GetToDoItems()
        {
            return _unitOfWork.Repository.GetAll();
        }

        public void AddToDoItem(ToDoItem item)
        {
            _unitOfWork.Repository.Add(item);
            _unitOfWork.Save();
        }

        /// <summary>
        /// Toggle completion of each item in database
        /// </summary>
        /// <param name="id"></param>
        /// <exception cref="KeyNotFoundException"></exception>
        public void MarkComplete(int id)
        {
            var item = _unitOfWork.Repository.GetById(id);
            if (item != null)
            {
                item.IsCompleted = !item.IsCompleted;
                _unitOfWork.Repository.Update(item);
                _unitOfWork.Save();
            }
            else
            {
                throw new KeyNotFoundException($"Item ID:{id} not found");
            }
        }

        public void Delete(int id)
        {
            _unitOfWork.Repository.Delete(id);
            _unitOfWork.Save();
        }

        public void Update(ToDoItem item)
        {
            _unitOfWork.Repository.Update(item);
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
                _unitOfWork.Repository.Delete(item.Id);
            }
            _unitOfWork.Save();
        }
    }
}
