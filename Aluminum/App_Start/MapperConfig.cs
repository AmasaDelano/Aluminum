using System;
using System.Collections.Generic;
using System.Linq;
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
                .AfterMap(
                    (v, e) =>
                    {
                        Type costumeType = typeof(Costume);

                        foreach (var property in v.Properties)
                        {
                            var boolProperty = costumeType.GetProperty(property.Key);
                            boolProperty.SetValue(e, property.Value);
                        }

                        e.CostumeID = v.Id;
                    });

            Mapper.CreateMap<Costume, CostumeViewModel>()
                .AfterMap(
                    (e, v) =>
                    {
                        var boolProperties = typeof(Costume).GetProperties().Where(b => b.PropertyType == typeof(bool));

                        v.Properties = new Dictionary<string, bool>();

                        foreach (var boolProperty in boolProperties)
                        {
                            v.Properties.Add(boolProperty.Name, (bool) boolProperty.GetValue(e));
                        }

                        v.Id = e.CostumeID;
                    });

            Mapper.CreateMap<CostumeQuestion, QuestionViewModel>();
        }
    }
}