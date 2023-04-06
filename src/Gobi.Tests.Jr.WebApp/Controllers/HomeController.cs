using Gobi.Test.Jr.Application;
using Gobi.Test.Jr.Domain;
using Microsoft.AspNetCore.Mvc;

namespace Gobi.Tests.Jr.WebApp.Controllers
{
    public class TodoController : Controller
    {
        private readonly TodoItemService _todoItemService;

        public TodoController(TodoItemService todoItemService)
        {
            _todoItemService = todoItemService;
        }

        public IActionResult Index()
        {
            var items = _todoItemService.GetAll();

            return View(items);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View(new TodoItem());
        }

        [HttpPost]
        public IActionResult Add(TodoItem todoItem)
        {
            _todoItemService.Add(todoItem);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int todoItemId)
        {
            TodoItem todoItem = _todoItemService.GetById(todoItemId);
            return View(todoItem);
        }

        [HttpPost]
        public IActionResult Edit(TodoItem todoItem)
        {
            _todoItemService.Update(todoItem);
            return RedirectToAction("Index");
        }


        public IActionResult Delete(int todoItemId)
        {
            _todoItemService.Delete(todoItemId);
            return RedirectToAction("Index");
        }
    }
}