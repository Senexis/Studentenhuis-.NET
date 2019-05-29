using System.Security.Claims;
using System.Threading.Tasks;
using Avans.Studentenhuis.Data.Interfaces;
using Avans.Studentenhuis.Data.Models;
using Avans.Studentenhuis.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Avans.Studentenhuis.Components
{
    public class SidebarComponent : ViewComponent
    {
        private IMealRepository _mealRepository;
        private UserManager<Student> _userManager;

        public SidebarComponent(IMealRepository mealRepository, UserManager<Student> userManager)
        {
            _mealRepository = mealRepository;
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var student = HttpContext.User;
            var studentId = student.FindFirstValue(ClaimTypes.NameIdentifier);
            Student studentObj = null;
            if (studentId != null) studentObj = await _userManager.FindByIdAsync(studentId);

            return View(new TodaysMealViewModel(_mealRepository, studentObj));
        }
    }
}
