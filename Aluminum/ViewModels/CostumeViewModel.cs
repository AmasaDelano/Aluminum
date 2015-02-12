using System.Collections.Generic;

namespace Aluminum.ViewModels
{
    public class CostumeViewModel
    {
        public CostumeViewModel()
        {
            Name = string.Empty;
            ImageFileName = string.Empty;
        }

        public short Id { get; set; }
        public string Name { get; set; }
        public string ImageFileName { get; set; }
        public Dictionary<string, short> Properties { get; set; }
    }
}