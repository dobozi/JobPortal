using JobsPortal.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobsPortal.Data
{
    public class JobsPortalDbContext : DbContext
    {
        public JobsPortalDbContext(DbContextOptions<JobsPortalDbContext> options) : base(options){}
        public DbSet<User> Users { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Recruiter> Recruiters { get; set; }
        public DbSet<Candidate> Candidates { get; set; }

        public DbSet<Job> Jobs { get; set; }

        public DbSet<Post> Posts { get; set; }

        public DbSet<Category> Categories { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CompanyRecruiter>()
                .HasKey(bc => new { bc.CompanyId, bc.RecruiterId });
            modelBuilder.Entity<CompanyRecruiter>()
                .HasOne(bc => bc.Company)
                .WithMany(b => b.CompanyRecruiters)
                .HasForeignKey(bc => bc.CompanyId);
            modelBuilder.Entity<CompanyRecruiter>()
                .HasOne(bc => bc.Recruiter)
                .WithMany(c => c.CompanyRecruiters)
                .HasForeignKey(bc => bc.RecruiterId);
            base.OnModelCreating(modelBuilder);
        }
    }
}
