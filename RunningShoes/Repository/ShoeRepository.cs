using Microsoft.EntityFrameworkCore;
using RunningShoes.Interfaces;
using RunningShoes.Models;
using System.Collections.Generic;
using System.Linq;

namespace RunningShoes.Repository
{
    public class ShoeRepository : IShoeRepository
    {
        private readonly RunningShoesDbContext _context;

        public ShoeRepository(RunningShoesDbContext context)
        {
            _context = context;
        }

        public List<Shoe> GetAll()
        {
            return _context.Shoes.OrderBy(p => p.Id).ToList();
        }

        public Shoe GetById(int id)
        {
            return _context.Shoes.Find(id);
        }

        public Shoe GetByName(string name)
        {
            return _context.Shoes.FirstOrDefault(s => s.Name == name);
        }

        public List<Shoe> Search(string query)
        {
            return _context.Shoes
                .Where(s => s.Name.Contains(query) || s.Brand.Contains(query))
                .ToList();
        }

        public void Add(Shoe shoe)
        {
            _context.Shoes.Add(shoe);
            _context.SaveChanges();
        }

        public void Update(Shoe shoe)
        {
            _context.Entry(shoe).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var shoe = _context.Shoes.Find(id);
            if (shoe != null)
            {
                _context.Shoes.Remove(shoe);
                _context.SaveChanges();
            }
        }

        public List<Review> GetReviewsByShoeId(int shoeId)
        {
            return _context.Reviews
                .Where(r => r.ShoeId == shoeId)
                .OrderByDescending(r => r.CreatedAt)
                .ToList();
        }

        public void AddReviewToShoe(Review review)
        {
            _context.Reviews.Add(review);
            _context.SaveChanges();
        }
    }
}