using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aluminum.Data
{
    public class CostumeHairColor
    {
        [Key, Column(Order = 1)]
        public short CostumeId { get; set; }

        [Key, Column(Order = 2)]
        public HairColorType HairColorTypeId { get; set; }
    }
}