using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using VtopAcademy.Schools;
using VtopAcademy.Exams;

namespace VtopAcademy
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options) { 
         
        }

        // Add Database tables here

        public DbSet<School> Schools { get; set; } = null!;
        public DbSet<Exam> Exams { get; set; } = null!;
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
