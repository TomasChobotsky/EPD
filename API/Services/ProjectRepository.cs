using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data;
using Microsoft.EntityFrameworkCore;

namespace API.Services
{
    public class ProjectRepository : BaseRepository<Project, EpdContext>
    {
        public ProjectRepository(EpdContext context) : base(context)
        {
                
        }
        
        public async Task<List<Activity>> GetActivitiesOfProject(int id)
        {
            return await context.Projects.Where(x => x.Id == id).SelectMany(x => x.Activities).ToListAsync();
        }
    }
}