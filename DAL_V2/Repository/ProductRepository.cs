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
    public class ProductRepository : IProductRepository
    {
        public async Task<bool> Create(Product entity)
        {
            using (EntityDatabase db = new EntityDatabase())
            {
                db.Product.Add(entity);
                await db.SaveChangesAsync();
                return true;
            }
        }

        public async Task<bool> Delete(Product entity)
        {
            using (EntityDatabase db = new EntityDatabase())
            {
                db.Product.Remove(entity);
                await db.SaveChangesAsync();
                return true;
            }
        }

        public async Task<Product> GetById(Guid id)
        {
            using (EntityDatabase db = new EntityDatabase())
            {

                return await db.Product.SingleOrDefaultAsync(e => e.Id == id);
            }
        }

        public async Task<Product> GetByIdIncludWord(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Product>> Select()
        {
            using (EntityDatabase db = new EntityDatabase())
            {

                return await db.Product.ToListAsync();
            }
        }
        public async Task<IEnumerable<Product>> SelectIncludeCategory()
        {
            using (EntityDatabase db = new EntityDatabase())
            {
                return await db.Product.Include(e => e.Category).ToListAsync();
            }
        }

        public async Task<Product> Update(Product entity)
        {
            using (EntityDatabase db = new EntityDatabase())
            {
                db.Product.Update(entity);
                await db.SaveChangesAsync();
                return entity;
            }
        }
    }
}
