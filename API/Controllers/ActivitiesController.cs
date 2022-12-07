using System.Collections.Generic;
using System.Threading.Tasks;
using API.Services;
using Data;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivitiesController : BaseController<Activity, ActivityRepository>
    {
        public ActivitiesController(ActivityRepository repository) : base(repository)
        {

        }
    }
}