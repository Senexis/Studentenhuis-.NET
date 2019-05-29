using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Avans.Studentenhuis.Controllers;
using Avans.Studentenhuis.Data.Interfaces;
using Avans.Studentenhuis.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Avans.Studentenhuis.Tests
{
    public class MealTests
    {
        [Fact]
        public void ControllerIndexReturnsSingleMeal()
        {
            var mealRepo = new Mock<IMealRepository>();
            mealRepo.Setup(m => m.Meals).Returns(new List<Meal>
            {
                new Meal {Name = "Meal 1", Description = "Description 1"}
            });

            var mealController = new MealsController(mealRepo.Object, null);
            var mealResult = (ViewResult) mealController.Index();

            if (mealResult.ViewData.Model is List<Meal> mealList)
            {
                Assert.Single(mealList);
                Assert.True(mealList.Exists(m => m.Name == "Meal 1"));
            };
        }

        [Fact]
        public void ControllerIndexReturnsMultipleMeals()
        {
            var mealList = new List<Meal>();

            for (var i = 0; i < 20; i++)
            {
                mealList.Add(new Meal{ Name = $"Meal {i}", Description = $"Description {i}"});
            }

            var mealRepo = new Mock<IMealRepository>();
            mealRepo.Setup(m => m.Meals).Returns(mealList);

            var mealController = new MealsController(mealRepo.Object, null);
            var mealResult = (ViewResult)mealController.Index();

            if (mealResult.ViewData.Model is List<Meal> mealList1)
            {
                Assert.Equal(20, mealList1.Count);
                for (var i = 0; i < 20; i++)
                {
                    Assert.True(mealList1.Exists(m => m.Name == $"Meal {i}"));
                }
            };
        }
    }
}
