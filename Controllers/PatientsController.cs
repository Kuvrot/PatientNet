﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
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

		[HttpPost]
		public async Task<IActionResult> Index (string search)
		{
			var patients = from p in _context.Patients
						   select p;

			if (!String.IsNullOrEmpty(search))
			{
				patients = patients.Where(p => p.Name.Contains(search));
			}

			return View(await patients.ToListAsync());
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

		[HttpPost]
        public async Task<IActionResult> NewConsult(string name)
        {
			var patient = from p in _context.Patients select p;
			patient = patient.Where(p => p.Name == name);
            return View(await patient.ToListAsync());
        }

		[HttpPost]
        public async Task<IActionResult> AddNewConsult(string date, string diagnostic, string observations, int patientId)
        {
			var consult = new Consult()
			{
				PatientId = patientId,
				Date = date,
				Observations = observations,
				Diagnostic = diagnostic
			};

			_context.Add(consult);
			await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> PatientHistory(int id)
		{

			var history = from h in _context.Consults select h;
			history = history.Where(h => h.PatientId == id);

			return View(await history.ToListAsync());
		}

	}
}
