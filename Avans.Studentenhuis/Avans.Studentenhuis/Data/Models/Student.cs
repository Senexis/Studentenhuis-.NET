using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Avans.Studentenhuis.Data.Models
{
    public class Student : IdentityUser
    {
        [Required(ErrorMessage = "This field is required.")]
        [DataType(DataType.Text, ErrorMessage = "Please enter a valid name.")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        [RegularExpression("([0-9-+]+)", ErrorMessage = "Please enter a valid phone number.")]
        public override string PhoneNumber { get; set; }

        public ICollection<Meal> CookingMeals { get; set; } = new List<Meal>();
        public virtual ICollection<MealStudent> ParticipatingMeals { get; set; } = new List<MealStudent>();
    }
}
