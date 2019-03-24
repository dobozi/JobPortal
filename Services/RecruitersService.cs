using JobsPortal.Data;
using JobsPortal.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobsPortal.Services
{
    public interface IRecruitersService
    {
        Task<Recruiter> Create(Recruiter model);
        Task<Recruiter> Get(int id);
        Task<IEnumerable<Recruiter>> GetAll();
        Task Delete(int id);
    }

    public class RecruitersService : IRecruitersService
    {
        private readonly JobsPortalDbContext _db;

        public RecruitersService(
            JobsPortalDbContext db
            )
        {
            _db = db;
        }

        public async Task<Recruiter> Create(Recruiter model)
        {
            var recruiter = new Recruiter
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                PhoneNumber = model.PhoneNumber,
                Identifier = model.Identifier

            };
            var entity = _db.Recruiters.Add(recruiter).Entity;

            await _db.SaveChangesAsync();

            return entity;
        }

        public async Task<Recruiter> Get(int id)
        {
            var recruiter = await _db.Recruiters
                .SingleOrDefaultAsync(x => x.Id == id);

            return recruiter;
        }

        public async Task<IEnumerable<Recruiter>> GetAll()
        {
            var recruiters = await _db.Recruiters
                .AsNoTracking()
                .Where(x =>x.Deleted !=true)
                .ToListAsync();

            return recruiters;
        }
        public async Task Delete(int id)
        {
            var recruiter = await _db.Recruiters.SingleOrDefaultAsync(x =>x.Id == id);
            if (recruiter != null)
                recruiter.Deleted = true;

            await _db.SaveChangesAsync();
        }
    }
}
