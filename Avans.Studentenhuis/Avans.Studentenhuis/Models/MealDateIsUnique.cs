using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Avans.Studentenhuis.Data;
using Microsoft.EntityFrameworkCore;

namespace Avans.Studentenhuis.Models
{
    public class MealDateIsUnique : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            // TODO: Find a way to retrieve the current context here. Maybe someday.
            var db = new ApplicationDbContext(new DbContextOptions<ApplicationDbContext>());
            return db.Meals.Any(m => m.DateTime == (DateTime) value);
        }
    }
}
