using RestApi.Data;
using RestApi.Interface;
using RestApi.Models;
namespace RestApi.Repository
{
    public class PokemonRepository:IPokemonRepository
    {
        private readonly DataContext _context;
        public PokemonRepository(DataContext context)
        {
            _context = context;
        }

        public Pokemon GetPokemon(int id)
        {
            return _context.Pokemon.Where(p => p.Id == id).FirstOrDefault();
        }

        public Pokemon GetPokemon(string name)
        {
            return _context.Pokemon.Where(p => p.Name == name).FirstOrDefault();
        }

        public decimal GetPokemonRating(int id)
        {
            var review=_context.Reviews.Where(p => p.Pokemon.Id == id);
            if(review.Count() <= 0)
                return 0;
            return ((decimal)review.Sum(r => r.Rating) / review.Count()) ;
        }

        public ICollection<Pokemon> GetPokemons()
        {
            return _context.Pokemon.OrderBy(p=>p.Id).ToList();
        }
        public bool PokemonExist(int id)
        {
            return (_context.Pokemon.Any(p => p.Id == id));

        }

    }
}
