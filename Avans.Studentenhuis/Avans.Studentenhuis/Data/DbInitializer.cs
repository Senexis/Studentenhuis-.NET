using Avans.Studentenhuis.Data.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace Avans.Studentenhuis.Data
{
    public class DbInitializer
    {
        public static void SeedUsers(UserManager<Student> studentManager)
        {
            if (studentManager.FindByNameAsync("timov") == null)
            {
                var timo = new Student
                {
                    UserName = "timov",
                    FullName = "Timo Viveen",
                    Email = "timo@example.com",
                    PhoneNumber = "+316-12345678"
                };

                studentManager.CreateAsync(timo, "1234").Wait();
            }

            if (studentManager.FindByNameAsync("wouterj") == null)
            {
                var wouter = new Student
                {
                    UserName = "wouterj",
                    FullName = "Wouter Jansen",
                    Email = "wouter@example.com",
                    PhoneNumber = "+316-12345678"
                };

                studentManager.CreateAsync(wouter, "1234").Wait();
            }

            if (studentManager.FindByNameAsync("rowinvb") == null)
            {
                var rowin = new Student
                {
                    UserName = "rowinvb",
                    FullName = "Rowin van Blokland",
                    Email = "rowin@example.com",
                    PhoneNumber = "+316-12345678"
                };

                studentManager.CreateAsync(rowin, "1234").Wait();
            }
        }

        public static void Seed(IApplicationBuilder application)
        {
            using (var serviceScope = application.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();
       
            }
        }
    }
}
