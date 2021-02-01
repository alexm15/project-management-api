using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectManagementAPI.Data;
using ProjectManagementAPI.Data.Entitites;
using ProjectManagementAPI.Models;

namespace ProjectManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly ProjectManagementContext _context;
        private readonly IMapper _mapper;

        public TasksController(ProjectManagementContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        // PUT: api/Tasks/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTask(int id, EditTaskModel model)
        {
            var task = _mapper.Map<ProjectTask>(model);

            var dbTask = await _context.Tasks.SingleOrDefaultAsync(t => t.Id == id);
            if (dbTask == null) return BadRequest();
            
            dbTask.Name = task.Name;
            dbTask.TimeSpent = task.TimeSpent;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TaskExists(id))
                {
                    return NotFound();
                }
                throw;
            }
            return NoContent();
        }

        // POST: api/ProjectTasks
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CreateTaskModel>> PostTask(CreateTaskModel model)
        {
            var task = _mapper.Map<ProjectTask>(model);
            var project = await _context.Projects.Include(p => p.Tasks).SingleOrDefaultAsync(p => p.Id == model.ProjectId);
            if (project == null) return BadRequest(new {message = $"Project with id {model.ProjectId} was not found"});
            
            project.Tasks.Add(task);
            await _context.SaveChangesAsync();

            //return CreatedAtAction("GetProject", new { controller = "Projects", id = model.ProjectId}, project); //TODO: Cyclic dependency issue 
            return Ok();
        }

        // DELETE: api/ProjectTasks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTask(int id)
        {
            var projectTask = await _context.Tasks.FindAsync(id);
            if (projectTask == null)
            {
                return NotFound();
            }
            _context.Tasks.Remove(projectTask);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TaskExists(int id)
        {
            return _context.Tasks.Any(e => e.Id == id);
        }
    }
}
