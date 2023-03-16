using RestApi.Data;
using RestApi.Interface;
using RestApi.Models;

namespace RestApi.Repository
{
    public class CategoryRepository:ICategoryRepository
    {
        private readonly DataContext _context;

        public CategoryRepository(DataContext context)
        {
            _context = context;
        }
        public ICollection<Category> GetCategories()
        {
            return _context.Categories.ToList();
        }
        public bool CategoryExist(int id)
        {
            return( _context.Categories.Any(p=>p.Id==id));
        }
        public Category GetCategory(int id)
        {
            return _context.Categories.Where(p => p.Id == id).FirstOrDefault();
        }
        public ICollection<Pokemon> GetPokemonByCategory(int id) { 
        return _context.PokemonCategories.Where(p=>p.CategoryId==id).Select(p => p.Pokemon).ToList();
        }
    }
}
