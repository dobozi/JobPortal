using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JobsPortal.Data;
using JobsPortal.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace JobsPortal.Services
{
    public interface IJobsService
    {
        Task<Job> Create(Job model);
        Task<Job> Get(int id);
        Task<IEnumerable<Job>> GetAll();
    }

    public class JobsService : IJobsService
    {
        private readonly JobsPortalDbContext _db;

        public JobsService(
            JobsPortalDbContext db
            )
        {
            _db = db;
        }

        public async Task<Job> Create(Job model)
        {
            var job = new Job
            {   Id = model.Id,
                JobTitle = model.JobTitle,
                JobDescription = model.JobDescription,
                CompanyName = model.CompanyName,
                WorkplaceAddress = model.WorkplaceAddress,
                WorkSchedule = model.WorkSchedule

    };
            var entity = _db.Jobs.Add(job).Entity;

            await _db.SaveChangesAsync();

            return entity;
        }

        public async Task<Job> Get(int id)
        {
            var job = await _db.Jobs
                .SingleOrDefaultAsync(x => x.Id == id);

            return job;
        }

        public async Task<IEnumerable<Job>> GetAll()
        {
            var jobs = await _db.Jobs
                .AsNoTracking()
                .ToListAsync();

            return jobs;
        }
    }


}