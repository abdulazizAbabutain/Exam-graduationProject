using Exam.web.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exam.web.DBcontexts
{
    public class ExamAppContext : IdentityDbContext
    {
        public ExamAppContext(DbContextOptions<ExamAppContext> options) : base(options)
        {
        }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<AnswerSheet> AnswerSheets { get; set; }
        public DbSet<ExamRoomSession> ExamRoomSessions { get; set; }
        public DbSet<UserExamResult> UserExamResults { get; set; }
        public DbSet<Questions> Questions { get; set; }
        // lockup table
        public DbSet<Department> Departments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Department>().HasData(
                Department.ComputerScience,
                Department.InformationTechnology,
                Department.InformationSystem
                );
        }

    }
}
