using System.Collections.Generic;
using System.Threading.Tasks;
using API.Services;
using Data;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : BaseController<Project, ProjectRepository>
    {
        public ProjectsController(ProjectRepository repository) : base(repository)
        {

        }
        
        [HttpGet("{id}/activities")]
        public async Task<ActionResult<IEnumerable<Activity>>> GetActivitiesOfProject(int id)
        {
            return await repository.GetActivitiesOfProject(id);
        }
    }
}