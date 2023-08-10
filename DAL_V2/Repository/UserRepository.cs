using DAL_V2.Entity;
using DAL_V2.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_V2.Repository
{
    public class UserRepository : IUserRepository
    {
        public async Task<bool> Create(User entity)
        {
            using (EntityDatabase db = new EntityDatabase())
            {
                db.User.Add(entity);
                await db.SaveChangesAsync();
                return true;
            }
        }

        public async Task<bool> Delete(User entity)
        {
            using (EntityDatabase db = new EntityDatabase())
            {
                db.User.Remove(entity);
                await db.SaveChangesAsync();
                return true;
            }
        }

        public async Task<User> GetById(Guid id)
        {
            using (EntityDatabase db = new EntityDatabase())
            {

                return await db.User.SingleOrDefaultAsync(e => e.Id == id);
            }
        }

        public async Task<IEnumerable<User>> Select()
        {
            using (EntityDatabase db = new EntityDatabase())
            {

                return await db.User.ToListAsync();
            }
        }

        public async Task<User> Update(User entity)
        {
            using (EntityDatabase db = new EntityDatabase())
            {
                db.User.Update(entity);
                await db.SaveChangesAsync();
                return entity;
            }
        }
    }
}
