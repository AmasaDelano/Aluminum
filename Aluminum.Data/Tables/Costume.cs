using System.ComponentModel.DataAnnotations;
namespace Aluminum.Data
{
    public partial class Costume
    {
        public short CostumeId { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(50)]
        public string ImageFileName { get; set; }

        public GenderType? GenderTypeId { get; set; }

        public AgeRangeType? AgeRangeTypeId { get; set; }

        public HairColorType? HairColorTypeId { get; set; }

        public HairLengthType? HairLengthTypeId { get; set; }

        public bool IsFictional { get; set; }

        public bool IsHuman { get; set; }

        public bool HasSuperPowers { get; set; }

        public bool HasFacialHair { get; set; }

        public bool HasMagic { get; set; }

        public bool HasEyeglasses { get; set; }
    }
}