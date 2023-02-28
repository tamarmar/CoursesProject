namespace DAL
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    public partial class CoursesProjectEntities : DbContext
    {
        public CoursesProjectEntities()
            : base("name=CoursesProjectEntities")
        {
            base.Configuration.ProxyCreationEnabled = false;
        }
        public DbSet<T> GetDbSet<T>() where T : class
        {
            return this.Set<T>();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }

        public virtual DbSet<Cours> Courses { get; set; }
        public virtual DbSet<Lesson> lessons { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<StudentInCourse> student_in_cours { get; set; }
        //public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
    }
}