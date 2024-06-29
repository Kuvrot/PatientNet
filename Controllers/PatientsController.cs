using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PatientNet.Models;
using PatientNet.Models.ViewModels;

namespace PatientNet.Controllers
{
	public class PatientsController : Controller
	{

		private readonly PatientNetContext _context;

		public PatientsController(PatientNetContext context)
		{
			_context = context;	
		}

		public async Task<IActionResult> Index()
		{
			return View(await _context.Patients.ToListAsync());
		}

		public IActionResult Add()
		{
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Add(PatientViewModel patientViewModel)
		{

			if (ModelState.IsValid)
			{
				var patient = new Patient()
				{
					Name = patientViewModel.Name,
					Age = patientViewModel.Age,
					Birthdate = patientViewModel.Birthdate,
					Sex = patientViewModel.Sex,
					Allergies = patientViewModel.Allergies,
					Observations = patientViewModel.Observations
				};

				_context.Add(patient);
				await _context.SaveChangesAsync();
				return RedirectToAction("Index");
			}

			return View();
		}

	}
}
