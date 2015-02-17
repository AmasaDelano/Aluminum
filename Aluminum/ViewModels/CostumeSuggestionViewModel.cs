using System;

namespace Aluminum.Web.ViewModels
{
    public class CostumeSuggestionViewModel
    {
        public long Id { get; set; }

        public string Suggestion { get; set; }

        public DateTime DateSent { get; set; }

        public string Email { get; set; }
    }
}