using Avans.Studentenhuis.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Avans.Studentenhuis.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Meal> Meals { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<MealStudent> MealStudents { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Meal entries have a unique date.
            builder.Entity<Meal>().HasIndex(e => e.DateTime).IsUnique();

            // One student can cook multiple meals.
            builder.Entity<Student>()
                .HasMany(e => e.CookingMeals)
                .WithOne(e => e.Cook)
                .HasForeignKey(e => e.CookId)
                .IsRequired();

            // MealStudent Many-to-Many definition.
            builder.Entity<MealStudent>()
                .HasKey(e => new { e.StudentId, e.MealId });

            builder.Entity<MealStudent>()
                .HasOne(ms => ms.Meal)
                .WithMany(m => m.Participants)
                .HasForeignKey(ms => ms.MealId);

            builder.Entity<MealStudent>()
                .HasOne(ms => ms.Student)
                .WithMany(s => s.ParticipatingMeals)
                .HasForeignKey(ms => ms.StudentId);
        }
    }
}
