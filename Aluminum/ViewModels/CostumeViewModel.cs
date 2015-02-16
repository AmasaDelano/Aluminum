using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Aluminum.Data;
using Aluminum.Web.Extensions;

namespace Aluminum.Web.ViewModels
{
    public class CostumeViewModel
    {
        public short Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string ImageFileName { get; set; }

        #region Properties

        [CostumeEnum]
        [DisplayName("Gender")]
        public GenderType? GenderTypeId { get; set; }

        [CostumeEnum]
        [DisplayName("Age Range")]
        public AgeRangeType? AgeRangeTypeId { get; set; }

        [CostumeEnum]
        [DisplayName("Hair Length")]
        public HairLengthType? HairLengthTypeId { get; set; }

        [CostumeEnum]
        [DisplayName("Hair Color")]
        public HairColorType? HairColorTypeId { get; set; }

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

        [CostumeCheckBox]
        [DisplayName("Has Glasses")]
        public bool HasEyeglasses { get; set; }

        #endregion Properties
    }
}