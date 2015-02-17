using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aluminum.Data
{
    public class CostumeSource
    {
        [Key, Column(Order = 1)]
        public short CostumeId { get; set; }

        [Key, Column(Order = 2)]
        public CostumeSourceType CostumeSourceTypeId { get; set; }
    }
}