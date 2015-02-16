using Aluminum.Data;
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
                .ForMember(e => e.ImageFileName, e => e.Condition(t => !t.IsSourceValueNull))
                .ForMember(e => e.Id, e => e.MapFrom(t => t.CostumeId));

            Mapper.CreateMap<CostumeQuestion, QuestionViewModel>();

            // View model to entity maps

            Mapper.CreateMap<CostumeViewModel, Costume>()
                .ForMember(e => e.ImageFileName, e => e.Condition(t => !t.IsSourceValueNull))
                .ForMember(e => e.CostumeId, e => e.MapFrom(t => t.Id));
        }
    }
}