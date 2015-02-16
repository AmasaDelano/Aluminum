using System.Collections.Generic;

namespace Aluminum.Web.ViewModels
{
    public class QuestionViewModel
    {
        public QuestionViewModel()
        {
            Options = new List<OptionViewModel>();
        }

        public string Question { get; set; }
        public string Answered { get; set; }
        public string DataField { get; set; }
        public List<OptionViewModel> Options { get; set; }
    }
}