using Microsoft.AspNetCore.Mvc;
using ClaseOnline.Models;
using System;
using System.Collections.Generic;

namespace ClaseOnline.Controllers
{
    public class HomeController : Controller
    {
        private static List<TaskModel> tasks = new List<TaskModel>();

        public IActionResult Index()
        {
            return View(tasks);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(TaskModel task)
        {
            task.Id = tasks.Count + 1; 
            tasks.Add(task);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var task = tasks.Find(t => t.Id == id);
            if (task == null)
            {
                return NotFound();
            }
            return View(task);
        }

        [HttpPost]
        public IActionResult Edit(TaskModel task)
        {
            var existingTask = tasks.Find(t => t.Id == task.Id);
            if (existingTask != null)
            {
                existingTask.Title = task.Title;
                existingTask.Description = task.Description;
                existingTask.DueDate = task.DueDate;
                existingTask.Priority = task.Priority;
                existingTask.IsComplete = task.IsComplete;
            }
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var task = tasks.Find(t => t.Id == id);
            if (task == null)
            {
                return NotFound();
            }
            tasks.Remove(task);
            return RedirectToAction("Index");
        }
    }
}

