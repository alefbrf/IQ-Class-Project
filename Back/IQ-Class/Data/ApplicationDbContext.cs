using IQ_Class.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace IQ_Class.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options) 
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<School>()
                .HasMany(School => School.school_class)
                .WithOne(SchoolClass => SchoolClass.school)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<School>()
                .HasMany(School => School.users)
                .WithOne(SchoolUser => SchoolUser.school)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Role>()
                .HasMany(Roles => Roles.user_role)
                .WithOne(UserRole => UserRole.role)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<User>()
                .HasOne(School => School.school)
                .WithMany(SchoolUser => SchoolUser.users)
                .OnDelete(DeleteBehavior.NoAction);
        }
        public DbSet<School> schools { get; set; }
        public DbSet<User> users { get; set; }
        public DbSet<Role> roles { get; set;}
        public DbSet<UserRole> user_roles { get; set; }
        public DbSet<SchoolClass> school_class { get; set; }
        public DbSet<UserClass> users_class { get; set; }
    }
}
