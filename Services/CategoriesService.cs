using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JobsPortal.Data;
using JobsPortal.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

namespace JobsPortal.Services
{
    public interface ICategoriesService
    {
        Task<Category> Get(int id);
        Task<Category> Create(Category model);
        Task<IEnumerable<Category>> GetAll();
        Task Delete(int id);
        Task<Category> Update(Category model);
    }

    public class CategoriesService : ICategoriesService
    {
        private readonly JobsPortalDbContext _db;

        public CategoriesService(
            JobsPortalDbContext db
            )
        {
            _db = db;
        }

        public async Task<Category> Create(Category model)
        {
            var category = new Category
            {
                Name = model.Name,
                Description = model.Description,               
                Modified = DateTime.Now,
                Enabled = model.Enabled                
            };

            category.Schema = JsonConvert.SerializeObject(category);
            var entity = _db.Categories.Add(category).Entity;

            await _db.SaveChangesAsync();

            return entity;
        }

        public async Task Delete(int id)
        {
            _db.Categories.Remove(new Category { Id= id});
            await _db.SaveChangesAsync();
        }

        public async Task<Category> Get(int id)
        {
            var category = await _db.Categories
                .SingleOrDefaultAsync(x => x.Id == id);

            return category;
        }

        public async Task<IEnumerable<Category>> GetAll()
        {
            var categories = await _db.Categories
                .AsNoTracking()
                .ToListAsync();

            return categories;
        }

        public async Task<Category> Update(Category model)
        {
            var category = _db.Categories
                .SingleOrDefault(x => x.Id == model.Id);

            category.Description = model.Description;
            category.Name = model.Name;
            category.Modified = DateTime.UtcNow;
            category.Schema = JsonConvert.SerializeObject(category);

            await _db.SaveChangesAsync();

            return category;
                
        }
    }
}
