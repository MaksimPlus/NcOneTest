using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NcOne.DAL;
using NcOne.Models;

namespace NcOne.Controllers
{
    public class ProgrammingLanguageController : Controller
    {
        private EmployeeContext context;
        public ProgrammingLanguageController(EmployeeContext context) 
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            var programmingLanguage = context.ProgrammingLanguages.ToList();
            return View(programmingLanguage.ToList());
        }
        // Добавление отдела
        [HttpGet]
        public ActionResult Create()
        {
            return View();  
        }
        [HttpPost]
        public async Task<IActionResult> Create(ProgrammingLanguage programmingLanguage)
        {
            context.ProgrammingLanguages.Add(programmingLanguage);
            await context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        // Редактирование отдела
        [HttpGet]
        public ActionResult Edit(int id)
        {
            if(id == null)
            {
                return NotFound();
            }
            ProgrammingLanguage programmingLanguage = context.ProgrammingLanguages.Find(id);
            if(programmingLanguage != null)
            {
                return View(programmingLanguage);
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> Edit(ProgrammingLanguage programmingLanguage)
        {
            context.Entry(programmingLanguage).State = EntityState.Modified;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        // Удаление отдела
        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            ProgrammingLanguage programmingLanguage = context.ProgrammingLanguages.Find(id);
            if (programmingLanguage == null)
            {
                return NotFound();
            }
            context.ProgrammingLanguages.Remove(programmingLanguage);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public RedirectResult RedirectToEmployee()
        {
            return RedirectPermanent("/Employee/Index");
        }
        public RedirectResult RedirectToDepartament()
        {
            return RedirectPermanent("/Departament/Index");
        }
    }
}
