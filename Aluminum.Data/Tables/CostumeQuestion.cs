using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aluminum.Data
{
    public partial class CostumeQuestion
    {
        public string Question { get; set; }

        public string Answered { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string DataField { get; set; }
    }
}