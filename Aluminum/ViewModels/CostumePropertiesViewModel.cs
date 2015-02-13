using Aluminum.Models;

namespace Aluminum.ViewModels
{
    public class CostumePropertiesViewModel
    {
        public GenderType GenderTypeId { get; set; }

        public bool HasFacialHair { get; set; }
        public bool HasMagic { get; set; }
        public bool HasSuperPowers { get; set; }
        public bool IsFictional { get; set; }
        public bool IsHuman { get; set; }
    }
}