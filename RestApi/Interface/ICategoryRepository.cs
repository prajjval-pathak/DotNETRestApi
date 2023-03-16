using RestApi.Models;

namespace RestApi.Interface
{
    public interface ICategoryRepository
    {
        ICollection<Category> GetCategories();
        Category GetCategory(int id);
        ICollection<Pokemon> GetPokemonByCategory(int id);
        public bool CategoryExist(int id);
    }
}
