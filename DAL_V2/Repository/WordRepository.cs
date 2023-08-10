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
    public class WordRepository : IWordRepository
    {
        public async Task<bool> Create(Word entity)
        {
            using (EntityDatabase db = new EntityDatabase())
            {
                db.Words.Add(entity);
                await db.SaveChangesAsync();
                return true;
            }
        }

        public async Task<bool> Delete(Word entity)
        {
            using (EntityDatabase db = new EntityDatabase())
            {
                db.Words.Remove(entity);
                await db.SaveChangesAsync();
                return true;
            }
        }

        public async Task<Word> GetById(Guid id)
        {
            using (EntityDatabase db = new EntityDatabase())
            {

                return await db.Words.SingleOrDefaultAsync(e => e.Id == id);
            }
        }

        public async Task<IEnumerable<Word>> Select()
        {
            using (EntityDatabase db = new EntityDatabase())
            {

                return await db.Words.ToListAsync();
            }
        }

        public async Task<IEnumerable<Word>> SelectIncludeKeyParamsProducts()
        {
            using (EntityDatabase db = new EntityDatabase())
            {
                return await db.Words.Include(e => e.ProductLink).ThenInclude(x => x.Product).ToListAsync();
            }
        }

        public async Task<Word> Update(Word entity)
        {
            using (EntityDatabase db = new EntityDatabase())
            {
                db.Words.Update(entity);
                await db.SaveChangesAsync();
                return entity;
            }
        }
    }
}
