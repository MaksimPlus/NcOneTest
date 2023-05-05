using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NcOne.DAL;
using NcOne.Models;

namespace NcOne.Controllers
{
    public class EmployeeController : Controller
    {
        private EmployeeContext context;
        public EmployeeController(EmployeeContext context)
        {
            this.context = context;
        }
        public ActionResult Index()
        {
            var employees = context.Employees.Include(p => p.Departaments)
                .Include(u => u.ProgrammingLanguages);
            return View(employees.ToList());
        }
        // Добавление нового сотрудника
        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.Departaments = new SelectList(context.Departaments, "Id", "Name");
            ViewBag.programminglanguage = new SelectList(context.ProgrammingLanguages, "Id", "Name");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Employee employee)
        {
            context.Employees.Add(employee);
            await context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        // Редактирование существующего
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Employee employee = context.Employees.Find(id);
            if (employee != null)
            {
                ViewBag.Departaments = new SelectList(context.Departaments, "Id", "Name");
                ViewBag.programminglanguage = new SelectList(context.ProgrammingLanguages, "Id", "Name");
                return View(employee);
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Employee employee)
        {
            context.Entry(employee).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        // Удаление сотрудника
        [HttpGet]
        public ActionResult Delete(int? id)
        {
            Employee employee = context.Employees.Find(id);
            if (employee != null)
            {
                context.Employees.Remove(employee);
                context.SaveChanges();
                return RedirectToAction("Index");
            }

            return NotFound();
        }
        public RedirectResult RedirectToDepartament()
        {
            return RedirectPermanent("/Departament/Index");
        }
        public RedirectResult RedirectToLanguage()
        {
            return RedirectPermanent("/ProgrammingLanguage/Index");
        }
    }
}
