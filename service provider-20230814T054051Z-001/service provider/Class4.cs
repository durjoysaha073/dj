using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace service
{
    public class GardenerService
    {
        private readonly GardenerRepository _repository;

        public GardenerService(GardenerRepository repository)
        {
            _repository = repository;
        }

        public async Task<Gardener> GetGardenerById(int id)
        {
            return await _repository.GetGardenerById(id);
        }

        public async Task<IEnumerable<Gardener>> GetAllGardeners()
        {
            return await _repository.GetAllGardeners();
        }

        public async Task AddGardener(Gardener gardener)
        {
            await _repository.AddGardener(gardener);
        }

        public async Task UpdateGardener(Gardener gardener)
        {
            await _repository.UpdateGardener(gardener);
        }

        public async Task DeleteGardener(int id)
        {
            await _repository.DeleteGardener(id);
        }
    }

}
