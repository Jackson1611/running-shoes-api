using Microsoft.EntityFrameworkCore;
using RunningShoes.Interfaces;
using RunningShoes.Models;

namespace RunningShoes.Repository
{
    public class ShoeRepository : IShoeRepository
    {
        private readonly RunningShoesDbContext _context;

        public ShoeRepository(RunningShoesDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Shoe>> GetAllAsync()
        {
            return await _context.Shoes.ToListAsync();
        }

        public async Task<Shoe> GetByIdAsync(int id)
        {
            return await _context.Shoes.FindAsync(id);
        }

        public async Task<IEnumerable<Shoe>> SearchAsync(string query)
        {
            return await _context.Shoes
                .Where(s => s.Name.Contains(query) || s.Brand.Contains(query))
                .ToListAsync();
        }

        public async Task AddAsync(Shoe shoe)
        {
            _context.Shoes.Add(shoe);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Shoe shoe)
        {
            _context.Entry(shoe).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var shoe = await _context.Shoes.FindAsync(id);
            if (shoe != null)
            {
                _context.Shoes.Remove(shoe);
                await _context.SaveChangesAsync();
            }
        }

        
    }
}
