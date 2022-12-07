using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data;
using Microsoft.EntityFrameworkCore;

namespace API.Services
{
    public class CustomerRepository : BaseRepository<Customer, EpdContext>
    {
        public CustomerRepository(EpdContext context) : base(context)
        {
            
        }
        
        public async Task<List<Project>> GetProjectsOfCustomer(int id)
        {
            return await context.Customers.Where(x => x.Id == id).SelectMany(x => x.Projects).ToListAsync();
        }
    }
}