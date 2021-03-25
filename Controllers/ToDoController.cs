using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoList.Database;
using ToDoList.Models;

namespace ToDoList.Controllers
{
    public class ToDoController : Controller
    {
        private readonly ToDoContext _db;//_db?

        public ToDoController(ToDoContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            var ad=new TodoList()
            {
                Id = 5,
                Task = "dsfdsfds"
            };
            ad.Task = "asdasd";
            List<TodoList> objLists = _db.ToDoList.ToList();//burdaki ToDoList prop ToDoContext den mi geliyor
            return View(objLists);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(TodoList obj)
        {
            if (ModelState.IsValid) 
            {
                _db.ToDoList.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.ToDoList.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(TodoList obj)
        {
            if (ModelState.IsValid)
            {
                _db.ToDoList.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);

        }

        //GET - DELETE
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.ToDoList.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        //POST - DELETE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var obj = _db.ToDoList.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.ToDoList.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");


        }


    }
}
