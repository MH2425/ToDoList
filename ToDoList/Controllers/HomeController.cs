using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using ToDoList.Models;
using UseCases;

namespace ToDoList.Controllers
{
    public class HomeController : Controller
    {
        private readonly ToDoListManager _listManager;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ToDoListManager listManager, ILogger<HomeController> logger)
        {
            _listManager = listManager;
            _logger = logger;
        }

        public IActionResult Index()
        {
            var toDoItems = _listManager.GetToDoItems();
            return View(new ToDoListViewModel()
            {
                Items = toDoItems.Select(ti => new Item()
                {
                    Id = ti.Id,
                    Text = ti.Text,
                    IsCompleted = ti.IsCompleted
                })
            });
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View("Add");
        }

        [HttpPost]
        public IActionResult Add(Item item)
        {
            _listManager.AddToDoItem(new ToDoItem()
            {
                Text = item.Text,
                IsCompleted = false
            });

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var toDoItems = _listManager.GetToDoItems();
            var item = toDoItems.FirstOrDefault(i => i.Id == id);

            if (item == null)
            {
                return NotFound();
            }

            return View(new Item() { Id = item.Id, Text = item.Text, IsCompleted = item.IsCompleted });
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            try
            {
                _listManager.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch (KeyNotFoundException ex)
            {
                _logger.LogError(ex, "Item with id {Id} not found", id);
                return NotFound();
            }
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var toDoItems = _listManager.GetToDoItems();
            var item = toDoItems.FirstOrDefault(i => i.Id == id);

            if (item == null)
            {
                return NotFound();
            }

            return View(new Item()
            {
                Id = item.Id,
                Text = item.Text,
                IsCompleted = item.IsCompleted
            });
        }

        [HttpPost]
        public IActionResult Edit(Item item)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var toDoItem = new ToDoItem
                    {
                        Id = item.Id,
                        Text = item.Text,
                        IsCompleted = item.IsCompleted
                    };
                    _logger.LogInformation("Updating item with ID: {Id}", item.Id);
                    _listManager.Update(toDoItem);
                    return RedirectToAction(nameof(Index));
                }
                catch (KeyNotFoundException ex)
                {
                    _logger.LogError(ex, "Item with id {Id} not found", item.Id);
                    return NotFound();
                }
            }
            return View(item);
        }

        [HttpPost]
        public IActionResult ToggleComplete(int id)
        {
            try
            {
                _listManager.MarkComplete(id);
                return RedirectToAction(nameof(Index));
            }
            catch (KeyNotFoundException ex)
            {
                _logger.LogError(ex, "Item with id {Id} not found", id);
                return NotFound();
            }
        }

        [HttpPost]
        public IActionResult ClearAll()
        {
            try
            {
                _listManager.ClearItems();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to clear all items");
                return RedirectToAction(nameof(Index));
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
