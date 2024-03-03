using RunningShoes.Models;

namespace RunningShoes.Interfaces
{
    public interface IShoeRepository
    {
        Task<IEnumerable<Shoe>> GetAllAsync();
        Task<Shoe> GetByIdAsync(int id);
        Task<IEnumerable<Shoe>> SearchAsync(string query);
        Task AddAsync(Shoe shoe);
        Task UpdateAsync(Shoe shoe);
        Task DeleteAsync(int id);

    }
}
