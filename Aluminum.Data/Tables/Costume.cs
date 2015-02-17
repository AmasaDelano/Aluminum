using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Aluminum.Data
{
    public partial class Costume
    {
        public Costume()
        {
            AgeRanges = new List<CostumeAgeRange>();
            HairColors = new List<CostumeHairColor>();
            HairLengths = new List<CostumeHairLength>();
            Sources = new List<CostumeSource>();
        }

        public short CostumeId { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(50)]
        public string ImageFileName { get; set; }

        public GenderType? GenderTypeId { get; set; }

        public List<CostumeAgeRange> AgeRanges { get; set; }

        public List<CostumeHairColor> HairColors { get; set; }

        public List<CostumeHairLength> HairLengths { get; set; }

        public List<CostumeSource> Sources { get; set; }

        public bool IsFictional { get; set; }

        public bool IsHuman { get; set; }

        public bool HasSuperPowers { get; set; }

        public bool HasFacialHair { get; set; }

        public bool HasMagic { get; set; }

        public bool HasEyeglasses { get; set; }
    }
}