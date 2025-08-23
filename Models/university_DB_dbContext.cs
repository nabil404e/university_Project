using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore; 

namespace university_Project.Models
{
    public class university_DB_dbContext :IdentityDbContext<ApplicationUser>
    {
        public DbSet<Cls_Course> Courses { get; set; }
        public DbSet<Cls_Department> Departments { get; set; }

        public DbSet<Cls_Trainer> Trainers { get; set; }

        public DbSet<Cls_CRS_Result> Results { get; set; }

        public DbSet<AppApplayCourse> ApplayCourses { get; set; }
        public DbSet<Cls_Instructor> Instrutors { get; set; }

        public university_DB_dbContext():base()
        {

        }

        public university_DB_dbContext(DbContextOptions options) : base(options){ }  /// make  constractor  to acees  database   
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); // مهم جداً لإضافة جداول Identity

            // Instructor relationships
            modelBuilder.Entity<Cls_Instructor>()
                .HasOne(i => i.Department)
                .WithMany()
                .HasForeignKey(i => i.Depart_ID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Cls_Instructor>()
                .HasOne(i => i.Course)
                .WithMany()
                .HasForeignKey(i => i.CRS_ID)
                .OnDelete(DeleteBehavior.Restrict);

            // Trainer relationships
            modelBuilder.Entity<Cls_Trainer>()
                .HasOne(t => t.Department)
                .WithMany()
                .HasForeignKey(t => t.DepartmentID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Cls_Trainer>()
                .HasOne(t => t.Course)
                .WithMany()
                .HasForeignKey(t => t.CourseID)
                .OnDelete(DeleteBehavior.Restrict);

            // Result relationships
            modelBuilder.Entity<Cls_CRS_Result>()
                .HasOne(r => r.Course)
                .WithMany()
                .HasForeignKey(r => r.Crs_ID)
                .OnDelete(DeleteBehavior.Restrict);
        }


        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog =university_DB ; Integrated Security=True;Encrypt=False;Trust Server Certificate=True");

        //    base.OnConfiguring(optionsBuilder);
        //}
    }
}
