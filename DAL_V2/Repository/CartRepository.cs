using DAL_V2.Entity;
using DAL_V2.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;

namespace DAL_V2.Repository
{
    public class CartRepository : ICartRepository
    {
        public async Task<bool> Create(Cart entity)
        {
            using (EntityDatabase db = new EntityDatabase())
            {
                db.Cart.Add(entity);
                await db.SaveChangesAsync();
                return true;
            }
        }

        public async Task<bool> Delete(Cart entity)
        {
            using (EntityDatabase db = new EntityDatabase())
            {
                db.Cart.Remove(entity);
                await db.SaveChangesAsync();
                return true;
            }
        }

        public async Task<Cart> GetById(Guid id)
        {
            using (EntityDatabase db = new EntityDatabase())
            {

                return await db.Cart.SingleOrDefaultAsync(e => e.Id == id);
            }

        }

        public async Task<IEnumerable<Cart>> Select()
        {
            using (EntityDatabase db = new EntityDatabase())
            {

                return await db.Cart.ToListAsync();
            }
        }

        public async Task<Cart> Update(Cart entity)
        {

            using (EntityDatabase db = new EntityDatabase())
            {
                db.Cart.Update(entity);
                await db.SaveChangesAsync();
                return entity;
            }
        }
    }
}
