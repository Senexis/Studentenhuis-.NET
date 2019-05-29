using System;
using System.Collections.Generic;
using Avans.Studentenhuis.Data.Models;

namespace Avans.Studentenhuis.Data.Interfaces
{
    public interface IMealRepository : IRepository<Meal>
    {
        IEnumerable<Meal> Meals { get; }
        IEnumerable<Meal> GetAllWithCook();
        IEnumerable<Meal> GetAllWithCookBetween(DateTime from, DateTime to);
        Meal GetWithCook(Guid id);
        IEnumerable<Meal> GetAllWithParticipants();
        Meal GetWithParticipants(Guid id);
    }
}