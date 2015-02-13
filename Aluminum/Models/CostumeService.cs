using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Aluminum.ViewModels;
using AutoMapper;

namespace Aluminum.Models
{
    public class CostumeService
    {
        private readonly DbContext _dbContext;

        private DbSet<Costume> Costumes
        {
            get { return _dbContext.Set<Costume>(); }
        }

        private DbSet<CostumeQuestion> Questions
        {
            get { return _dbContext.Set<CostumeQuestion>(); }
        }

        public CostumeService(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<QuestionViewModel> GetQuestions()
        {
            var questionEntities = Questions
                .OrderBy(e => e.DataField)
                .ToList();

            var questions = Mapper.Map<List<QuestionViewModel>>(questionEntities);

            questions.ForEach(
                e =>
                {
                    e.DataField = e.DataField.Substring(0, 1).ToLower() + e.DataField.Substring(1);
                });

            return questions;
        }

        public List<CostumeViewModel> GetCostumes()
        {
            var costumeEntities = Costumes
                .ToList();

            var costumes = Mapper.Map<List<CostumeViewModel>>(costumeEntities);

            return costumes;
        }

        public void DeleteCostume(short costumeId)
        {
            var costume = Costumes.Single(e => e.CostumeID == costumeId);
            Costumes.Remove(costume);
            Save();
        }

        public void SaveCostume(CostumeViewModel costume)
        {
            if (costume.Id == 0)
            {
                var costumeEntity = Mapper.Map<Costume>(costume);
                Costumes.Add(costumeEntity);
            }
            else
            {
                var costumeEntity = Costumes.Single(e => e.CostumeID == costume.Id);
                Mapper.Map(costume, costumeEntity);
            }
            Save();
        }

        public CostumeViewModel GetCostume(short costumeId)
        {
            var costumeEntity = Costumes
                .FirstOrDefault(e => e.CostumeID == costumeId) ?? new Costume();

            var costume = Mapper.Map<CostumeViewModel>(costumeEntity);

            return costume;
        }

        private void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}