using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace API.Services
{
    public class UserRepository
    {
        public readonly EpdContext context;
        public UserRepository(EpdContext context)
        {
            this.context = context;
        }

        public async Task<User> Add(User entity)
        {
            context.Users.Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task<User> Get(string username)
        {
            return await context.Users.FirstOrDefaultAsync(x => x.Username == username);
        }

        //NOT IMPLEMENTED! Is supposed to be accessible only by the admin
        public async Task<List<User>> GetAll()
        {
            var users = await context.Users.ToListAsync();
            users.ForEach(t => t.Password = null);
            users.ForEach(t => t.Username = null);
            return users;
        }

        public async Task<User> Update(int id, User entity)
        {
            var local = context.Set<User>()
                .Local
                .FirstOrDefault(entry => entry.Id.Equals(id));
            
            if (local != null)
            {
                context.Entry(local).State = EntityState.Detached;
            }
            context.Entry(entity).State = EntityState.Modified;
            
            await context.SaveChangesAsync();

            return entity;
        }
        
        public async Task<List<Activity>> GetActivitiesOfUser(string username)
        {
            return await context.Users.Where(x => x.Username == username).SelectMany(x => x.Activities).ToListAsync();
        }
    }
}