using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace service
{
    public class GardenerRepository
    {
        private readonly DbContext _dbContext;

        public GardenerRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Gardener> GetGardenerById(int id)
        {
            return await _dbContext.Gardeners.FindAsync(id);
        }

        public async Task<IEnumerable<Gardener>> GetAllGardeners()
        {
            return await _dbContext.Gardeners.ToListAsync();
        }

        public async Task AddGardener(Gardener gardener)
        {
            _dbContext.Gardeners.Add(gardener);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateGardener(Gardener gardener)
        {
            _dbContext.Entry(gardener).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteGardener(int id)
        {
            var gardener = await _dbContext.Gardeners.FindAsync(id);
            if (gardener != null)
            {
                _dbContext.Gardeners.Remove(gardener);
                await _dbContext.SaveChangesAsync();
            }
        }
    }

}
