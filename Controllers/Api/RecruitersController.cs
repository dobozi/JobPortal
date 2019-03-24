using JobsPortal.Data.Entities;
using JobsPortal.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobsPortal.Controllers.Api
{
    [Route("api/recruiters")]
    [Produces("application/json")]
    public class RecruitersController : Controller
    {
        private readonly IRecruitersService _service;

        public RecruitersController(
            IRecruitersService service
            )
        {
            _service = service;
        }
        [HttpGet("{id}", Name = "GetRecruiter")]
        public async Task<IActionResult> Get(int id)
        {
            var recruiter = await _service.Get(id);
            if (recruiter == null)
                return NotFound();
            return Ok(recruiter);
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var recruiters = await _service.GetAll();
            if (recruiters == null)
                return NotFound();
            return Ok(recruiters);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]Recruiter model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var recruiter = await _service.Create(model);

            return CreatedAtRoute("GetRecruiter",
                new { id = recruiter.Id }, recruiter);
        }
        [HttpDelete]
        public Task Delete(int id)
        {
           return _service.Delete(id);

        }
    }
}
