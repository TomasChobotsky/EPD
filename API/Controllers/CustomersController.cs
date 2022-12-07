using System.Collections.Generic;
using System.Threading.Tasks;
using API.Services;
using Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : BaseController<Customer, CustomerRepository>
    {
        public CustomersController(CustomerRepository repository) : base(repository)
        {

        }
        
        [HttpGet("{id}/projects")]
        [Authorize]
        public async Task<ActionResult<IEnumerable<Project>>> GetProjectsOfCustomer(int id)
        {
            return await repository.GetProjectsOfCustomer(id);
        }
    }
}