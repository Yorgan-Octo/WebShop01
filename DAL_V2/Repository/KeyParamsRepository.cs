using DAL_V2.Entity;
using DAL_V2.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL_V2.Repository
{
    public class KeyParamsRepository : IKeyParamsRepository
    {
        public async Task<bool> Create(KeyParams entity)
        {
            using (EntityDatabase db = new EntityDatabase())
            {
                db.KeyLink.Add(entity);
                await db.SaveChangesAsync();
                return true;
            }
        }

        public async Task<bool> Delete(KeyParams entity)
        {
            using (EntityDatabase db = new EntityDatabase())
            {
                db.KeyLink.Remove(entity);
                await db.SaveChangesAsync();
                return true;
            }
        }

        public async Task<KeyParams> GetById(Guid id)
        {
            using (EntityDatabase db = new EntityDatabase())
            {

                return await db.KeyLink.SingleOrDefaultAsync(e => e.Id == id);
            }
        }

        public async Task<IEnumerable<KeyParams>> Select()
        {
            using (EntityDatabase db = new EntityDatabase())
            {

                return await db.KeyLink.ToListAsync();
            }
        }

        public async Task<IEnumerable<KeyParams>> SelectIncludeWords()
        {
            using (EntityDatabase db = new EntityDatabase())
            {
                return await db.KeyLink.Include(e => e.KeyWords).ToListAsync();
            }
        }

        public async Task<KeyParams> Update(KeyParams entity)
        {
            using (EntityDatabase db = new EntityDatabase())
            {
                db.KeyLink.Update(entity);
                await db.SaveChangesAsync();
                return entity;
            }
        }
    }
}
