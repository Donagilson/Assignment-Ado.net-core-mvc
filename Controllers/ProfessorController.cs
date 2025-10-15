using Microsoft.AspNetCore.Mvc;
using ProfessorManagementSystem.Models;
using ProfessorManagementSystem.Services;
using System.Linq;

namespace ProfessorManagementSystem.Controllers
{
    public class ProfessorController : Controller
    {
        private readonly IProfessorService _service;

        public ProfessorController(IProfessorService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult List()
        {
            var professors = _service.GetAllProfessors().ToList();
            return View(professors);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Departments = _service.GetAllDepartments();
            return View();
        }

        [HttpPost]
        public IActionResult Create(Professor professor)
        {
            if (ModelState.IsValid)
            {
                _service.AddProfessor(professor);
                return RedirectToAction("List");
            }
            ViewBag.Departments = _service.GetAllDepartments();
            return View(professor);
        }

        // ✅ Edit GET
        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Departments = _service.GetAllDepartments();
            var professor = _service.GetProfessorById(id);
            if (professor == null)
                return NotFound();
            return View(professor);
        }

        // ✅ Edit POST
        [HttpPost]
        public IActionResult Edit(Professor professor)
        {
            if (ModelState.IsValid)
            {
                _service.UpdateProfessor(professor);
                return RedirectToAction("List");
            }
            ViewBag.Departments = _service.GetAllDepartments();
            return View(professor);
        }
    }
}
