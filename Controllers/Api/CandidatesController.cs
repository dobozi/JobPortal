using JobsPortal.Data.Entities;
using JobsPortal.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobsPortal.Controllers.Api
{
    [Route("api/candidates")]
    [Produces("application/json")]
    public class CandidatesController : Controller
    {
        private readonly ICategoriesService _service;

        public CandidatesController(
            ICategoriesService service
            )
        {
            _service = service;
        }
        [HttpGet("{id}", Name = "GetCandidate")]
        public async Task<IActionResult> Get(int id)
        {
            var candidate = await _service.Get(id);
            if (candidate == null)
                return NotFound();
            return Ok(candidate);
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var candidates = await _service.GetAll();
            if (candidates == null)
                return NotFound();
            return Ok(candidates);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]Category model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var candidate = await _service.Create(model);

            return CreatedAtRoute("GetCandidate",
                new { id = candidate.Id }, candidate);
        }
    }
}
