using System.Collections.Generic;
using System.Web.Http;
using Aluminum.Models;
using Aluminum.ViewModels;

namespace Aluminum.Controllers
{
    public class CostumeApiController : ApiController
    {
        private readonly CostumeService _costumeService;

        public CostumeApiController(CostumeService costumeService)
        {
            _costumeService = costumeService;
        }

        [HttpGet]
        public List<QuestionViewModel> GetQuestions()
        {
            var questions = _costumeService.GetQuestions();

            return questions;
        }

        [HttpGet]
        public List<CostumeViewModel> GetCostumes()
        {
            var costumes = _costumeService.GetCostumes();

            return costumes;
        }
    }
}
