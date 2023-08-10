using DAL_V2.Entity;
using DAL_V2.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL_V2.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        public async Task<bool> Create(Category entity)
        {
            using (EntityDatabase db = new EntityDatabase())
            {
                db.Category.Add(entity);
                await db.SaveChangesAsync();
                return true;
            }
        }

        public async Task<bool> Delete(Category entity)
        {
            using (EntityDatabase db = new EntityDatabase())
            {
                db.Category.Remove(entity);
                await db.SaveChangesAsync();
                return true;
            }
        }

        public async Task<Category> GetById(Guid id)
        {
            using (EntityDatabase db = new EntityDatabase())
            {

                return await db.Category.SingleOrDefaultAsync(e => e.Id == id);
            }
        }

        public async Task<IEnumerable<Category>> Select()
        {

            using (EntityDatabase db = new EntityDatabase())
            {

                return await db.Category.ToListAsync();
            }
        }

        public async Task<IEnumerable<Category>> SelectIncludeProducts()
        {

            using (EntityDatabase db = new EntityDatabase())
            {
                return await db.Category.Include(e => e.Products).ToListAsync();
            }
        }

        public async Task<Category> Update(Category entity)
        {

            using (EntityDatabase db = new EntityDatabase())
            {
                db.Category.Update(entity);
                await db.SaveChangesAsync();
                return entity;
            }
        }
    }
}
