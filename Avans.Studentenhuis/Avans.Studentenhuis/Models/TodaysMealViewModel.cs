using System;
using System.Linq;
using Avans.Studentenhuis.Data.Interfaces;
using Avans.Studentenhuis.Data.Models;
using Microsoft.AspNetCore.Identity;

namespace Avans.Studentenhuis.Models
{
    public class TodaysMealViewModel
    {
        public UserManager<Student> UserManager;

        public Meal Meal { get; set; }
        public Student Student { get; set; }

        public TodaysMealViewModel(IMealRepository mealRepository, Student student)
        {
            if (student != null)
            {
                Student = student;
            }

            try
            {
                Meal = mealRepository.Find(e => e.DateTime.Date.CompareTo(DateTime.Today.Date) == 0).First();
            }
            catch (Exception)
            {
                // Meal can be null here.
            }
        }
    }
}
