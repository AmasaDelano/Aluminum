using System.Linq;
using Aluminum.Data;
using Aluminum.Web.ViewModels;
using AutoMapper;

namespace Aluminum.Web
{
    public class MapperConfig
    {
        public static void RegisterMaps()
        {
            // Entity to view model maps

            Mapper.CreateMap<Costume, CostumeViewModel>()
                .ForMember(e => e.HairColors, e => e.MapFrom(t => t.HairColors.Select(c => c.HairColorTypeId).ToList()))
                .ForMember(e => e.HairLengths, e => e.MapFrom(t => t.HairLengths.Select(l => l.HairLengthTypeId).ToList()))
                .ForMember(e => e.AgeRanges, e => e.MapFrom(t => t.AgeRanges.Select(l => l.AgeRangeTypeId).ToList()))
                .ForMember(e => e.Sources, e => e.MapFrom(t => t.Sources.Select(l => l.CostumeSourceTypeId).ToList()))
                .ForMember(e => e.ImageFileName, e => e.Condition(t => !t.IsSourceValueNull))
                .ForMember(e => e.Id, e => e.MapFrom(t => t.CostumeId));

            Mapper.CreateMap<CostumeQuestion, QuestionViewModel>();

            // View model to entity maps

            Mapper.CreateMap<CostumeViewModel, Costume>()
                .ForMember(e => e.ImageFileName, e => e.Condition(t => !t.IsSourceValueNull))
                .ForMember(e => e.CostumeId, e => e.MapFrom(t => t.Id))
                .ForMember(e => e.AgeRanges, e => e.Ignore())
                .ForMember(e => e.HairColors, e => e.Ignore())
                .ForMember(e => e.HairLengths, e => e.Ignore())
                .ForMember(e => e.Sources, e => e.Ignore())
                .AfterMap((m, e) =>
                {
                    // Remove old ones
                    e.AgeRanges.RemoveAll(t => !m.AgeRanges.Contains(t.AgeRangeTypeId));
                    e.HairLengths.RemoveAll(t => !m.HairLengths.Contains(t.HairLengthTypeId));
                    e.HairColors.RemoveAll(t => !m.HairColors.Contains(t.HairColorTypeId));
                    e.Sources.RemoveAll(t => !m.Sources.Contains(t.CostumeSourceTypeId));

                    // Add new ones
                    e.AgeRanges.AddRange(m.AgeRanges
                            .Where(t => e.AgeRanges.All(r => r.AgeRangeTypeId != t))
                            .Select(t => new CostumeAgeRange { AgeRangeTypeId = t }));
                    e.HairLengths.AddRange(m.HairLengths
                            .Where(t => e.HairLengths.All(r => r.HairLengthTypeId != t))
                            .Select(t => new CostumeHairLength { HairLengthTypeId = t }));
                    e.HairColors.AddRange(m.HairColors
                            .Where(t => e.HairColors.All(r => r.HairColorTypeId != t))
                            .Select(t => new CostumeHairColor { HairColorTypeId = t }));
                    e.Sources.AddRange(m.Sources
                            .Where(t => e.Sources.All(r => r.CostumeSourceTypeId != t))
                            .Select(t => new CostumeSource { CostumeSourceTypeId = t }));
                });
        }
    }
}