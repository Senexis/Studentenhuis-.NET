using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Avans.Studentenhuis.Models;

namespace Avans.Studentenhuis.Data.Models
{
    public class Meal
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        [DataType(DataType.DateTime, ErrorMessage = "Please enter a valid date.")]
        [MealDateRangeValid(ErrorMessage = "Date must be between now and two weeks from now.")]
        // This would be nice if it worked, but I don't know how to get the context in this class, resorting to controller validation instead. :-(
        // [MealDateIsUnique(ErrorMessage = "There is already a meal planned on this date.")]
        [Display(Name = "Date")]
        public DateTime DateTime { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        [DataType(DataType.Text, ErrorMessage = "Please enter a valid name.")]
        public string Name { get; set; }

        [DataType(DataType.MultilineText, ErrorMessage = "Please enter a valid description.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        [RegularExpression("([0-9]+)", ErrorMessage = "Please enter a valid number.")]
        [Display(Name = "Max. participants")]
        public int MaxParticipants { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        [DataType(DataType.Currency, ErrorMessage = "Please enter a valid price.")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        [Display(Name = "Cook")]
        public string CookId { get; set; }
        public Student Cook { get; set; }

        public bool HasParticipants => Participants.Count > 0;
        public bool HasRoomForParticipants => Participants.Count + 1 <= MaxParticipants;

        public bool CanParticipate(Student student) => HasRoomForParticipants && Cook != student && Participants.All(e => e.Student != student);
        public bool CanCancel(Student student) => Participants.Count > 0 && Participants.Any(e => e.Student == student);
        public bool CanEdit(Student student) => Participants.Count < 1 && Cook == student;
        public bool CanDelete(Student student) => CanEdit(student);

        public virtual ICollection<MealStudent> Participants { get; set; } = new List<MealStudent>();
    }
}