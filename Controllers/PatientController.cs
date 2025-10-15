using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PatientManagementSystem2025.Models;
using PatientManagementSystem2025.Services;

namespace PatientManagementSystem2025.Controllers
{
    public class PatientsController : Controller
    {
        private readonly IPatientService patientService;

        public PatientsController(IPatientService patientService)
        {
            this.patientService = patientService;
        }

        #region 1. List all patients
        [HttpGet]
        public IActionResult List()
        {
            var patients = patientService.GetAllPatients().ToList();
            return View(patients);
        }
        #endregion

        #region 2. Get for Create
        [HttpGet]
        public IActionResult Create()
        {
            // Convert memberships to SelectList
            var memberships = patientService.GetAllMemberships()
                                .Select(m => new SelectListItem
                                {
                                    Value = m.MemberId.ToString(),
                                    Text = m.MemberDescrip
                                }).ToList();
            ViewBag.Memberships = memberships;

            return View();
        }

        [HttpPost]
        public IActionResult Create(Patient patient)
        {
            if (ModelState.IsValid)
            {
                patientService.AddPatient(patient);
                return RedirectToAction("List");
            }

            // Re-populate dropdown if validation fails
            var memberships = patientService.GetAllMemberships()
                                .Select(m => new SelectListItem
                                {
                                    Value = m.MemberId.ToString(),
                                    Text = m.MemberDescrip
                                }).ToList();
            ViewBag.Memberships = memberships;

            return View(patient);
        }
        #endregion

        #region 4. Get for Edit
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var patient = patientService.GetPatientById(id);
            if (patient == null)
                return NotFound();

            // Convert memberships to SelectList
            var memberships = patientService.GetAllMemberships()
                                .Select(m => new SelectListItem
                                {
                                    Value = m.MemberId.ToString(),
                                    Text = m.MemberDescrip
                                }).ToList();
            ViewBag.Memberships = memberships;

            return View(patient);
        }
        #endregion

        #region 5. POST Edit
        [HttpPost]
        public IActionResult Edit(int id, Patient patient)
        {
            if (ModelState.IsValid)
            {
                patientService.EditAndUpdatePatient(patient);
                return RedirectToAction("List");
            }

            // Re-populate dropdown if validation fails
            var memberships = patientService.GetAllMemberships()
                                .Select(m => new SelectListItem
                                {
                                    Value = m.MemberId.ToString(),
                                    Text = m.MemberDescrip
                                }).ToList();
            ViewBag.Memberships = memberships;

            return View(patient);
        }
        #endregion
    }
}
