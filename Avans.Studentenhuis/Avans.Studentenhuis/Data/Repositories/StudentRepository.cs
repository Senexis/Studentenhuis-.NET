using System.Collections.Generic;
using Avans.Studentenhuis.Data.Interfaces;
using Avans.Studentenhuis.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Avans.Studentenhuis.Data.Repositories
{
    public class StudentRepository : Repository<Student>, IStudentRepository
    {
        public StudentRepository(ApplicationDbContext context) : base(context)
        {
            // The generic ctor is fine here.
        }

        public IEnumerable<Student> GetAllWithMeals()
        {
            return _context.Set<Student>().Include(e => e.CookingMeals).Include(e => e.ParticipatingMeals);
        }

        public IEnumerable<Student> GetAllWithCookingMeals()
        {
            return _context.Set<Student>().Include(e => e.CookingMeals);
        }

        public IEnumerable<Student> GetAllWithPariticipatingMeals()
        {
            return _context.Set<Student>().Include(e => e.ParticipatingMeals);
        }
    }
}
