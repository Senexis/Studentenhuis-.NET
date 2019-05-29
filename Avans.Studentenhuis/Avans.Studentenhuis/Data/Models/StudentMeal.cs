using System;

namespace Avans.Studentenhuis.Data.Models
{
    public class MealStudent
    {
        public MealStudent()
        {
            
        }

        public MealStudent(Meal meal, Student student)
        {
            MealId = meal.Id;
            StudentId = student.Id;
        }

        public Guid MealId { get; set; }
        public Meal Meal { get; set; }
        public string StudentId { get; set; }
        public Student Student { get; set; }
    }
}
