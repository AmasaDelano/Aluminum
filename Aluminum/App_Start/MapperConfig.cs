using Aluminum.Models;
using Aluminum.ViewModels;
using AutoMapper;

namespace Aluminum
{
    public class MapperConfig
    {
        public static void RegisterMaps()
        {
            // Entity to view model maps

            Mapper.CreateMap<Costume, CostumeViewModel>()
                .ForMember(e => e.Id, e => e.MapFrom(t => t.CostumeID));

            Mapper.CreateMap<CostumeQuestion, QuestionViewModel>();

            // View model to entity maps

            Mapper.CreateMap<CostumeViewModel, Costume>()
                .ForMember(e => e.CostumeID, e => e.MapFrom(t => t.Id));
        }
    }
}