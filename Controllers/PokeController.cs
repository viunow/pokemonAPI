using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using pokeAPI.Data;
using pokeAPI.Data.DTOS;
using pokeAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pokeAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PokeController : ControllerBase
    {
        private PokemonContext _context;
        private IMapper _mapper;
        public PokeController(PokemonContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AdicionarPokemon([FromBody] CreatePokemonDto pokemonDto)
        {
            Pokemon pokemon = _mapper.Map<Pokemon>(pokemonDto);
            _context.Pokemons.Add(pokemon);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RecuperarPokemonPorId), new { Id = pokemon.Id }, pokemon);
        }

        [HttpGet]
        public IEnumerable<Pokemon> ListarPokemon()
        {
            return _context.Pokemons;
        }

        [HttpGet("{id}")]
        public IActionResult RecuperarPokemonPorId (int id)
        {
            Pokemon pokemon = _context.Pokemons.FirstOrDefault(pokemon => pokemon.Id == id);
            if (pokemon != null)
            {
                ReadPokemonDto pokemonDto = _mapper.Map<ReadPokemonDto>(pokemon);
                return Ok(pokemonDto);
            }
            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult AtualizarPokemon(int id, [FromBody] UpdatePokemonDto pokemonDto)
        {
            Pokemon pokemon = _context.Pokemons.FirstOrDefault(pokemon => pokemon.Id == id);
            if (pokemon == null)
            {
                return NotFound();
            }
            _mapper.Map(pokemonDto, pokemon);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletarPokemon(int id)
        {
            Pokemon pokemon = _context.Pokemons.FirstOrDefault(pokemon => pokemon.Id == id);
            if (pokemon == null)
            {
                return NotFound();
            }
            _context.Remove(pokemon);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
