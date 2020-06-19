using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebMotors.Core.Entities;
using WebMotors.WebMotorsWeb.Models;

namespace WebMotors.WebMotorsWeb.Core.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AnuncioViewModel, Anuncio>();
            CreateMap<Anuncio, AnuncioViewModel>();

            CreateMap<List<AnuncioViewModel>, List<Anuncio>>();
        }
    }
}
