using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data;
using Microsoft.EntityFrameworkCore;

namespace API.Services
{
    public class ActivityRepository : BaseRepository<Activity, EpdContext>
    {
        public ActivityRepository(EpdContext context) : base(context)
        {
                
        }
    }
}