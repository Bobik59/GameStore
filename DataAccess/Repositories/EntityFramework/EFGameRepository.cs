using DataAccess.Entities;
using DataAccess.Filters;
using DataAccess.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;

namespace DataAccess.Repositories.EntityFramework
{
    public class EFGameRepository : IGameRepository
    {
        private AppDbContext _context;
        public EFGameRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Game>> GetAllAsync()
        {
            return await _context.Games.ToListAsync();
        }
        public async Task<List<Game>> GetByFilterAsync(GameFilter filter)
        {
            return await _context.Games.Filter(filter).ToListAsync();
        }
        public async Task<Game?> GetByIdAsync(int id)
        {
            return await _context.Games.FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<int> CreateAsync(Game game)
        {
            await _context.Games.AddAsync(game);
            await _context.SaveChangesAsync();
            return game.Id;
        }
        public async Task<int> UpdateAsync(Game game)
        {
            _context.Games.Update(game);
            await _context.SaveChangesAsync();
            return game.Id;
        }
        public async Task DeleteAsync(Game game)
        {
            _context.Games.Remove(game);
            await _context.SaveChangesAsync();
        }
    }
}
