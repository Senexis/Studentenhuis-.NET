using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Avans.Studentenhuis.Data.Interfaces;
using Avans.Studentenhuis.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace Avans.Studentenhuis.Controllers
{
    [Authorize]
    public class MealsController : Controller
    {
        private readonly IMealRepository _mealRepository;
        private readonly UserManager<Student> _userManager;

        public MealsController(IMealRepository mealRepository, UserManager<Student> userManager)
        {
            _mealRepository = mealRepository;
            _userManager = userManager;
        }

        // GET: Meals
        [AllowAnonymous]
        public IActionResult Index()
        {
            var meals = _mealRepository.GetAllWithCookBetween(DateTime.Today, DateTime.Today.AddDays(14));
            return View(meals);
        }

        // GET: Meals/Details/5
        [AllowAnonymous]
        public IActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var meal = _mealRepository.GetWithParticipants((Guid)id);

            if (meal == null)
            {
                return NotFound();
            }

            return View(meal);
        }

        // GET: Meals/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Meals/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DateTime,Name,Description,MaxParticipants,Price")] Meal meal)
        {
            // TODO: Replace this with MealDateIsUnique attribute on the Meal model. Maybe someday. :-(
            if (_mealRepository.GetAll().Any(e => e.DateTime.Date.CompareTo(meal.DateTime.Date) == 0))
            {
                // The ValidationSummary flag will only display added model errors for empty keys, sadly.
                ModelState.AddModelError(string.Empty, "There is already a meal planned on this date.");
            }

            if (ModelState.IsValid)
            {
                meal.Id = Guid.NewGuid();
                meal.Cook = await _userManager.GetUserAsync(User);

                _mealRepository.Create(meal);
                return RedirectToAction(nameof(Index));
            }

            return View(meal);
        }

        // GET: Meals/Participate/5
        public async Task<IActionResult> Participate(Guid id)
        {
            var meal = _mealRepository.GetWithParticipants(id);
            if (meal == null)
            {
                return NotFound();
            }

            var user = await _userManager.GetUserAsync(User);
            if (user == null || !meal.CanParticipate(user))
            {
                return Forbid();
            }

            var mealStudent = new MealStudent(meal, user);
            meal.Participants.Add(mealStudent);
            _mealRepository.Update(meal);
            
            return RedirectToAction(nameof(Index));
        }

        // GET: Meals/Cancel/5
        public async Task<IActionResult> Cancel(Guid id)
        {
            var meal = _mealRepository.GetWithParticipants(id);
            if (meal == null)
            {
                return NotFound();
            }

            var user = await _userManager.GetUserAsync(User);
            if (user == null || !meal.CanCancel(user))
            {
                return Forbid();
            }

            var mealStudent = meal.Participants.First(e => e.Student == user);
            meal.Participants.Remove(mealStudent);
            _mealRepository.Update(meal);

            return RedirectToAction(nameof(Index));
        }

        // GET: Meals/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var meal = _mealRepository.GetWithParticipants((Guid) id);
            if (meal == null)
            {
                return NotFound();
            }

            var user = await _userManager.GetUserAsync(User);
            if (user == null || !meal.CanEdit(user))
            {
                return Forbid();
            }

            return View(meal);
        }

        // POST: Meals/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Guid id, [Bind("DateTime,Name,Description,MaxParticipants,Price")] Meal meal)
        {
            if (id != meal.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _mealRepository.Update(meal);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MealExists(meal.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }

            return View(meal);
        }

        // GET: Meals/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var meal = _mealRepository.GetWithParticipants((Guid) id);
            if (meal == null)
            {
                return NotFound();
            }
            var user = await _userManager.GetUserAsync(User);
            if (user == null || !meal.CanDelete(user))
            {
                return Forbid();
            }

            return View(meal);
        }

        // POST: Meals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Guid id)
        {
            var meal = _mealRepository.GetById(id);
            _mealRepository.Delete(meal);
            return RedirectToAction(nameof(Index));
        }

        private bool MealExists(Guid id)
        {
            return _mealRepository.Find(e => e.Id == id).ToList().Count > 0;
        }
    }
}
