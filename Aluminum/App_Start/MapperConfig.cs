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

                        foreach (var propertyName in v.Properties)
                        {
                            var property = costumeType.GetProperty(propertyName.Key);
                            property.SetValue(e, propertyName.Value);
                        }

                        e.CostumeID = v.Id;
                        e.GenderTypeID = (byte) GenderType.Male;
                    });

            Mapper.CreateMap<Costume, CostumeViewModel>()
                .AfterMap(
                    (e, v) =>
                    {
                        var properties = typeof(Costume).GetProperties()
                            .Where(b =>
                                b.PropertyType == typeof(bool) ||
                                b.PropertyType == typeof(byte));

                        v.Properties = new Dictionary<string, short>();

                        foreach (var property in properties)
                        {
                            v.Properties.Add(property.Name, Convert.ToInt16(property.GetValue(e)));
                        }

                        v.Id = e.CostumeID;
                    });

            Mapper.CreateMap<CostumeQuestion, QuestionViewModel>();
        }
    }
}