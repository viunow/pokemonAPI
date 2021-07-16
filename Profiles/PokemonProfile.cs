using AutoMapper;
using pokeAPI.Data.DTOS;
using pokeAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pokeAPI.Profiles
{
    public class PokemonProfile : Profile
    {
        public PokemonProfile()
        {
            CreateMap<CreatePokemonDto, Pokemon>();
            CreateMap<Pokemon, ReadPokemonDto>();
            CreateMap<UpdatePokemonDto, Pokemon>();
        }
    }
}
