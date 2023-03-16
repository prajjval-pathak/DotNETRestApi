using RestApi.Models;

namespace RestApi.Interface
{
    public interface IPokemonRepository
    {
        ICollection<Pokemon> GetPokemons();
        Pokemon GetPokemon(int id);
        Pokemon GetPokemon(string name);    
        decimal GetPokemonRating(int id);
        public bool PokemonExist(int id);
    }
}
