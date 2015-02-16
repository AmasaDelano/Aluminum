using System.Collections.Generic;

namespace Aluminum.ViewModels
{
    public class CostumeAdminScreenViewModel
    {
        public List<CostumeViewModel> Costumes { get; set; }

        public List<CostumeSuggestionViewModel> Suggestions { get; set; }
    }
}