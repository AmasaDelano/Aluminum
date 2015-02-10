using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using Aluminum.ViewModels;
using AutoMapper;

namespace Aluminum.Models
{
    public class CostumeService
    {
        private readonly DataContext _dataContext;

        public CostumeService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public List<QuestionViewModel> GetQuestions()
        {
            var questionEntities = _dataContext
                .GetTable<CostumeQuestion>()
                .OrderBy(e => e.SortOrder)
                .ToList();

            var questions = Mapper.Map<List<QuestionViewModel>>(questionEntities);

            return questions;
        }

        public List<CostumeViewModel> GetCostumes()
        {
            var costumeEntities = _dataContext
                .GetTable<Costume>()
                .ToList();

            var costumes = Mapper.Map<List<CostumeViewModel>>(costumeEntities);

            return costumes;
        }
    }
}