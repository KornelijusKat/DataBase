using Microsoft.EntityFrameworkCore;

namespace DataBase
{
    class ProjectContext : DbContext
    {
        public DbSet<Department> Departments { get; set; }
        public DbSet<Lecture> Lectures { get; set; }
        public DbSet<Student> Students { get; set; } 
        protected override void OnConfiguring(DbContextOptionsBuilder options)
           => options.UseLazyLoadingProxies().UseSqlServer($"Server = localhost; Database=University;Trusted_Connection=True;MultipleActiveResultSets=true;");
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>()
                .HasMany(x => x.LectureList).WithMany(s => s.DepartmentList);
        }
    }
}
