using System.Collections.Generic;

namespace Aluminum.ViewModels
{
    public class CostumeViewModel
    {
        public string Name { get; set; }
        public string ImageFileName { get; set; }
        public Dictionary<string, bool> Properties { get; set; } 
    }
}