using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aluminum.Data
{
    public class CostumeHairLength
    {
        [Key, Column(Order = 1)]
        public short CostumeId { get; set; }

        [Key, Column(Order = 2)]
        public HairLengthType HairLengthTypeId { get; set; }
    }
}