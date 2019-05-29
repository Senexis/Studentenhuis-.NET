using System.Collections.Generic;
using Avans.Studentenhuis.Data.Models;

namespace Avans.Studentenhuis.Data.Interfaces
{
    public interface IStudentRepository
    {
        IEnumerable<Student> GetAllWithMeals();
        IEnumerable<Student> GetAllWithCookingMeals();
        IEnumerable<Student> GetAllWithPariticipatingMeals();
    }
}
