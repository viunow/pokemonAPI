using Microsoft.EntityFrameworkCore;
using pokeAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pokeAPI.Data
{
    public class PokemonContext : DbContext
    {
        public PokemonContext(DbContextOptions<PokemonContext> opt) : base (opt)
        {

        }

        public DbSet<Pokemon> Pokemons { get; set; }
    }
}
