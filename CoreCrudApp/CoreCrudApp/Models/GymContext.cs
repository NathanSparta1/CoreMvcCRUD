using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace CoreCrudApp.Models
{
    public class GymContext:DbContext
    {
        public DbSet<Categories> Categories { get; set; }
        public DbSet<Exercise> Exercise { get; set; }
        public DbSet<Users> Users { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\ProjectsV13;Initial Catalog=GymDataBaseCore;" +
            "Integrated Security=True;Connect Timeout=30;" +
            "Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }

        public GymContext()
        {

        }

        public GymContext(DbContextOptions<GymContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Categories>()
                .Property(c => c.CategoryName)
                .IsRequired()
                .HasMaxLength(50);

            // define a one-to-many relationship
            modelBuilder.Entity<Categories>()
                .HasMany(e => e.Exercise)
                .WithOne(c => c.Categories);
                
            

            modelBuilder.Entity<Exercise>()
              .HasOne(c => c.Categories)
              .WithMany(e => e.Exercise)
              .HasForeignKey(e => e.CategoryId);
        }
    }

    
}
