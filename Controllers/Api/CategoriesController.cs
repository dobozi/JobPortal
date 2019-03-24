using JobsPortal.Data.Entities;
using JobsPortal.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobsPortal.Controllers.Api
{
    [Route("api/categories")]
    [Produces("application/json")]
    public class CategoriesController : Controller
    {
        private readonly ICategoriesService _service;

        public CategoriesController(
            ICategoriesService service
            )
        {
            _service = service;
        }
        [HttpGet("{id}", Name = "GetCategory")]
        public async Task<IActionResult> Get(int id)
        {
            var category = await _service.Get(id);
            if (category == null)
                return NotFound();
            return Ok(category);
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categories = await _service.GetAll();
            if (categories == null)
                return NotFound();
            return Ok(categories);
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Category model){
            var category = await _service.Update(model);

            return Ok(category);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]Category model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var category = await _service.Create(model);

            return CreatedAtRoute("GetCategory",
                new { id = category.Id }, category);
        }
        [HttpPost, Route("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await this._service.Delete(id);

            return RedirectToAction(nameof(GetAll));
        }
    }
}
