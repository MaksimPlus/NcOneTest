using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NcOne.DAL;
using NcOne.Models;
using System.Net;

namespace NcOne.Controllers
{
    public class DepartamentController : Controller
    {
        private EmployeeContext context;
        public DepartamentController(EmployeeContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            var departament = context.Departaments.ToList();
            return View(departament.ToList());
        }
        // Добавление отдела
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Create(Departament departament)
        {
            context.Departaments.Add(departament);
            await context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        // Редактирование существующего
        [HttpGet]
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Departament departament = context.Departaments.Find(id);
            if (departament != null)
            {
                return View(departament);
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Departament departament)
        {
            context.Entry(departament).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        // Удаление отдела
        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            Departament departament = context.Departaments.Find(id);
            if (departament == null)
            {
                return NotFound();
            }
            context.Departaments.Remove(departament);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public RedirectResult RedirectToEmployee()
        {
            return RedirectPermanent("/Employee/Index");
        }
        public RedirectResult RedirectToLanguage()
        {
            return RedirectPermanent("/ProgrammingLanguage/Index");
        }
    }
}
