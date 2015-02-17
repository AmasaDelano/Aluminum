using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Web;
using Aluminum.Data;
using Aluminum.Web.Extensions;
using Aluminum.Web.ViewModels;
using AutoMapper;

namespace Aluminum.Web.Models
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
                    // If it ends with "Id", it's a type column and therefore an enum.
                    if (e.DataField.EndsWith("Id"))
                    {
                        string enumName = e.DataField.Remove(e.DataField.Length - "Id".Length);
                        var enumType = Assembly.GetAssembly(typeof(RoomOfRequirement))
                            .GetType("Aluminum.Data." + enumName);
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
            var costumeEntities = _context.Costumes
                .Include(e => e.AgeRanges)
                .Include(e => e.HairColors)
                .Include(e => e.HairLengths)
                .Include(e => e.Sources)
                .OrderBy(e => e.Name).ToList();

            var costumes = Mapper.Map<List<CostumeViewModel>>(costumeEntities);

            return costumes;
        }

        public void DeleteCostume(short costumeId)
        {
            var costume = _context.Costumes.Single(e => e.CostumeId == costumeId);
            _context.Costumes.Remove(costume);
            Save();
        }

        public void SaveCostume(CostumeViewModel costume, HttpPostedFileBase imageFile, HttpServerUtilityBase server)
        {
            if (imageFile != null && imageFile.ContentLength > 0)
            {
                string fileName = UploadFile(imageFile, costume.Name, server);

                costume.ImageFileName = fileName;
            }

            SaveCostume(costume);
        }

        public CostumeViewModel GetCostume(short costumeId)
        {
            var costumeEntity = _context.Costumes
                .Include(e => e.AgeRanges)
                .Include(e => e.HairColors)
                .Include(e => e.HairLengths)
                .Include(e => e.Sources)
                .FirstOrDefault(e => e.CostumeId == costumeId) ?? new Costume();

            var costume = Mapper.Map<CostumeViewModel>(costumeEntity);

            return costume;
        }

        public void SendSuggestion(string suggestion, string emailAddress)
        {
            var costumeSuggestion = new CostumeSuggestion
            {
                EmailAddress = emailAddress,
                Suggestion = suggestion
            };

            _context.CostumeSuggestions.Add(costumeSuggestion);
            Save();
        }

        public void HideSuggestion(long suggestionId, string userName)
        {
            int userId = _context.Users.Single(e => e.UserName == userName).UserId;

            var suggestion = new CostumeSuggestion
            {
                CostumeSuggestionId = suggestionId
            };

            _context.CostumeSuggestions.Attach(suggestion);

            suggestion.HiddenByUserId = userId;

            Save();
        }

        private string UploadFile(HttpPostedFileBase imageFile, string costumeName, HttpServerUtilityBase server)
        {
            string cleanedCostumeName = Regex.Replace(costumeName, @"[^\w]+", "").ToLower();
            string fileName = cleanedCostumeName + Path.GetExtension(imageFile.FileName);
            string folderPath = server.MapPath("~" + ConfigurationExtensions.GetCostumeImagesPath());

            var directory = new DirectoryInfo(folderPath);
            if (!directory.Exists)
            {
                directory.Create();
            }

            string path = Path.Combine(folderPath, fileName);
            imageFile.SaveAs(path);

            return fileName;
        }

        private void SaveCostume(CostumeViewModel costume)
        {
            if (string.IsNullOrEmpty(costume.Name))
            {
                throw new ArgumentException("Costume name cannot be empty!", "costume");
            }

            if (costume.Id == 0)
            {
                costume.ImageFileName = costume.ImageFileName ?? string.Empty;
                var costumeEntity = Mapper.Map<Costume>(costume);
                _context.Costumes.Add(costumeEntity);
            }
            else
            {
                var costumeEntity = _context.Costumes
                    .Include(e => e.AgeRanges)
                    .Include(e => e.HairColors)
                    .Include(e => e.HairLengths)
                    .Include(e => e.Sources)
                    .Single(e => e.CostumeId == costume.Id);
                Mapper.Map(costume, costumeEntity);
            }
            Save();
        }

        private void Save()
        {
            _context.SaveChanges();
        }

        public List<CostumeSuggestionViewModel> GetSuggestions()
        {
            var suggestions = _context.CostumeSuggestions
                .Where(e => e.HiddenByUserId == null)
                .OrderByDescending(e => e.DateSent)
                .Select(e => new CostumeSuggestionViewModel
                {
                    Id = e.CostumeSuggestionId,
                    DateSent = e.DateSent,
                    Email = e.EmailAddress,
                    Suggestion = e.Suggestion
                })
                .ToList();

            return suggestions;
        }
    }
}