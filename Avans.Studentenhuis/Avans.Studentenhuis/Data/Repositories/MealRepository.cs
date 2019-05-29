using System;
using System.Collections.Generic;
using System.Linq;
using Avans.Studentenhuis.Data.Interfaces;
using Avans.Studentenhuis.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Avans.Studentenhuis.Data.Repositories
{
    public class MealRepository : Repository<Meal>, IMealRepository
    {
        public MealRepository(ApplicationDbContext context) : base(context)
        {
            // The generic ctor is fine here.
        }

        public IEnumerable<Meal> Meals => GetAllWithParticipants();

        public IEnumerable<Meal> GetAllWithCook()
        {
            return _context.Set<Meal>().Include(e => e.Cook);
        }

        public IEnumerable<Meal> GetAllWithCookBetween(DateTime from, DateTime to)
        {
            return GetAllWithCook().Where(e => from <= e.DateTime && e.DateTime <= to);
        }

        public Meal GetWithCook(Guid id)
        {
            return _context.Set<Meal>().Where(e => e.Id == id).Include(e => e.Cook).First();
        }

        public IEnumerable<Meal> GetAllWithParticipants()
        {
            return _context.Set<Meal>().Include(e => e.Cook).Include(e => e.Participants).ThenInclude(e => e.Student);
        }

        public Meal GetWithParticipants(Guid id)
        {
            return _context.Set<Meal>().Where(e => e.Id == id).Include(e => e.Cook).Include(e => e.Participants).ThenInclude(e => e.Student).First();
        }
    }
}
