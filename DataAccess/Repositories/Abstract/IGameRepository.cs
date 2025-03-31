using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Filters;
namespace DataAccess.Repositories.Abstract
{
    public interface IGameRepository
    {
        public Task<List<Game>> GetAllAsync();
        public Task<List<Game>> GetByFilterAsync(GameFilter filter);
        public Task<Game?> GetByIdAsync(int id);
        public Task<int> CreateAsync(Game game);
        public Task<int> UpdateAsync(Game game);
        public Task DeleteAsync(Game game);
    }
}
