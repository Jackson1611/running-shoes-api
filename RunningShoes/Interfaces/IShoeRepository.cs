using RunningShoes.Models;

namespace RunningShoes.Interfaces
{
    public interface IShoeRepository
    {
        List<Shoe> GetAll();
        Shoe GetById(int id);
        Shoe GetByName(string name);
        List<Shoe> Search(string query);
        void Add(Shoe shoe);
        void Update(Shoe shoe);
        void Delete(int id);
        
    }
}
