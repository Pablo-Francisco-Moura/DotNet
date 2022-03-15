using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using projeto_dotnet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace projeto_dotnet.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {

        }

        public DbSet<CoursesModel> CoursesModels { get; set; }
        public DbSet<Status> Status { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<CoursesModel>(e =>
            {
                e.ToTable("Courses");
                e.HasKey(p => p.Id);
                e.Property(p => p.Title).HasColumnType("varchar40").IsRequired();
                e.HasMany(p => p.Status)
                    .WithOne(p => p.CoursesModel);
            });
        }

    }
}
