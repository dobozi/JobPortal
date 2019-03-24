using JobsPortal.Data.Entities;
using JobsPortal.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

[Route("api/jobs")]
[Produces("application/json")]
public class JobsController : Controller
{  
 private readonly IJobsService _service;

    public JobsController(
        IJobsService service
        )
    {
        _service = service;
    }
    [HttpGet("{id}", Name = "GetJob")]
    public async Task<IActionResult> Get(int id)
    {
        var job = await _service.Get(id);
        if (job == null)
            return NotFound();
        return Ok(job);
    }
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var jobs = await _service.GetAll();
        if (jobs == null)
            return NotFound();
        return Ok(jobs);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody]Job model)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        var job = await _service.Create(model);

        return CreatedAtRoute("GetJob",
            new { id = job.Id }, job);
    }
}