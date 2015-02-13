using Aluminum.Models;
using Aluminum.ViewModels;
using AutoMapper;

namespace Aluminum
{
    public class MapperConfig
    {
        public static void RegisterMaps()
        {
            Mapper.CreateMap<CostumeViewModel, Costume>()
                .ForMember(e => e.CostumeID, e => e.MapFrom(t => t.Id));

            Mapper.CreateMap<Costume, CostumeViewModel>()
                .ForMember(e => e.Id, e => e.MapFrom(t => t.CostumeID))
                .ForMember(
                    e => e.Properties,
                    e => e.ResolveUsing<PropertiesResolver>()
                        .FromMember(t => t));

            Mapper.CreateMap<CostumeQuestion, QuestionViewModel>();

            Mapper.CreateMap<Costume, CostumePropertiesViewModel>();
        }
    }

    public class PropertiesResolver : ValueResolver<Costume, CostumePropertiesViewModel>
    {
        protected override CostumePropertiesViewModel ResolveCore(Costume source)
        {
            return Mapper.Map<CostumePropertiesViewModel>(source);
        }
    }
}