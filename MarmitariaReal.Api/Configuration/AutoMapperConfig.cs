using AutoMapper;
using MarmitariaReal.Domain.Entities;
using MarmitariaReal.Domain.ViewModels;

namespace MarmitariaReal.Api.Configuration
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig() 
        { 
            CreateMap<Receita, ReceitaViewModel>().ReverseMap();
            CreateMap<ReceitaEditViewModel, Receita>();
        }
    }
}
