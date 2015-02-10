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

            //var costumes = new List<CostumeViewModel>
            //{
            //    new CostumeViewModel
            //    {
            //        Name = "Spiderman",
            //        HasSuperPowers = true,
            //        HasPants = true,
            //        IsHuman = true
            //    },
            //    new CostumeViewModel
            //    {
            //        Name = "Spiderman",
            //        HasSuperPowers = true,
            //        HasPants = true,
            //        IsHuman = true
            //    },
            //    new CostumeViewModel
            //    {
            //        Name = "Phillip Fry",
            //        HasSuperPowers = false,
            //        HasPants = true,
            //        IsHuman = true
            //    },
            //    new CostumeViewModel
            //    {
            //        Name = "Wonder Woman",
            //        HasSuperPowers = true,
            //        HasPants = false,
            //        IsHuman = true
            //    },
            //    new CostumeViewModel
            //    {
            //        Name = "Superman",
            //        HasSuperPowers = true,
            //        HasPants = true,
            //        IsHuman = false
            //    },
            //    new CostumeViewModel
            //    {
            //        Name = "Cinderella",
            //        HasSuperPowers = false,
            //        HasPants = false,
            //        IsHuman = true
            //    },
            //    new CostumeViewModel
            //    {
            //        Name = "Kif Kroker",
            //        HasSuperPowers = false,
            //        HasPants = true,
            //        IsHuman = false
            //    },
            //    new CostumeViewModel
            //    {
            //        Name = "Gandalf",
            //        HasSuperPowers = true,
            //        HasPants = false,
            //        IsHuman = false
            //    },
            //    new CostumeViewModel
            //    {
            //        Name = "Gary the Snail",
            //        HasSuperPowers = false,
            //        HasPants = false,
            //        IsHuman = false
            //    }
            //};

            return costumes;
        }
    }
}
