using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Aluminum.Extensions;
using Aluminum.ViewModels;
using AutoMapper;

namespace Aluminum.Models
{
    public class CostumeService
    {
        private readonly RoomOfRequirement _context;

        public CostumeService(RoomOfRequirement context)
        {
            _context = context;
        }

        public List<QuestionViewModel> GetQuestions()
        {
            var questionEntities = _context.CostumeQuestions
                .OrderBy(e => e.DataField)
                .ToList();

            var questions = Mapper.Map<List<QuestionViewModel>>(questionEntities);

            questions.ForEach(
                e =>
                {
                    // If it ends with "Id", it's a type column
                    // and therefore an enum.
                    if (e.DataField.EndsWith("Id"))
                    {
                        string enumName = e.DataField.Remove(e.DataField.Length - "Id".Length);
                        var enumType = Assembly.GetExecutingAssembly().GetType("Aluminum.Models." + enumName);
                        var enumMembers = EnumExtensions.GetEnumMembers(enumType);
                        e.Options = enumMembers.Select(
                            m =>
                                new OptionViewModel
                                {
                                    Name = m.ToString(),
                                    Value = Convert.ToByte(m)
                                })
                            .ToList();
                    }

                    e.DataField = e.DataField.Substring(0, 1).ToLower() + e.DataField.Substring(1);
                });

            return questions;
        }

        public List<CostumeViewModel> GetCostumes()
        {
            var costumeEntities = _context.Costumes.ToList();

            var costumes = Mapper.Map<List<CostumeViewModel>>(costumeEntities);

            return costumes;
        }

        public void DeleteCostume(short costumeId)
        {
            var costume = _context.Costumes.Single(e => e.CostumeID == costumeId);
            _context.Costumes.Remove(costume);
            Save();
        }

        public void SaveCostume(CostumeViewModel costume)
        {
            if (costume.Id == 0)
            {
                var costumeEntity = Mapper.Map<Costume>(costume);
                _context.Costumes.Add(costumeEntity);
            }
            else
            {
                var costumeEntity = _context.Costumes.Single(e => e.CostumeID == costume.Id);
                Mapper.Map(costume, costumeEntity);
            }
            Save();
        }

        public CostumeViewModel GetCostume(short costumeId)
        {
            var costumeEntity = _context.Costumes.FirstOrDefault(e => e.CostumeID == costumeId) ?? new Costume();

            var costume = Mapper.Map<CostumeViewModel>(costumeEntity);

            return costume;
        }

        private void Save()
        {
            _context.SaveChanges();
        }
    }
}