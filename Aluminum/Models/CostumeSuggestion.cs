using System;
using System.ComponentModel.DataAnnotations;

namespace Aluminum.Models
{
    public class CostumeSuggestion
    {
        public long CostumeSuggestionId { get; set; }

        public DateTime DateSent { get; private set; }

        [MaxLength(2000)]
        public string Suggestion { get; set; }

        [MaxLength(254)]
        public string EmailAddress { get; set; }

        public int? HiddenByUserId { get; set; }
    }
}