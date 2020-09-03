using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectService.Database;
using ProjectService.Database.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProjectService.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        DatabaseContext db;

        public ProjectController()
        {
            db = new DatabaseContext();

        }

        // GET: api/<ProjectController>
        [ActionName("getAllProjects")]
        [HttpGet]
        public IEnumerable<project> Get()
        {
            return db.Projects.ToList();
        }

        // GET api/<ProjectController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ProjectController>
        
        
        [ActionName("createProject")]
        [HttpPost]
        public IActionResult Post([FromBody] project model)
        {
            try
            {
                db.Projects.Add(model);
                db.SaveChanges();
                return StatusCode(StatusCodes.Status201Created);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        // PUT api/<ProjectController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }


        // DELETE api/<ProjectController>/5
        [ActionName("deleteProject")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            
                var projectToDelete = db.Projects.SingleOrDefault(x => x.ProjectId == id);
                
            if(projectToDelete == null)
            {
                return NotFound("No record found");
            }

            db.Projects.Remove(projectToDelete);
            db.SaveChanges();

            return Ok();
            
        }
    }
}
