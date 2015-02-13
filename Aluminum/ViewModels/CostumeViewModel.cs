using System.ComponentModel;
using Aluminum.Extensions;
using Aluminum.Models;

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

        #region Properties

        [CostumeEnum]
        [DisplayName("Gender")]
        public GenderType? GenderTypeId { get; set; }

        [CostumeCheckBox]
        [DisplayName("Has Facial Hair")]
        public bool HasFacialHair { get; set; }

        [CostumeCheckBox]
        [DisplayName("Has Magic")]
        public bool HasMagic { get; set; }

        [CostumeCheckBox]
        [DisplayName("Has Super Powers")]
        public bool HasSuperPowers { get; set; }

        [CostumeCheckBox]
        [DisplayName("Is Fictional")]
        public bool IsFictional { get; set; }

        [CostumeCheckBox]
        [DisplayName("Is Human")]
        public bool IsHuman { get; set; }

        #endregion
    }
}