using System.ComponentModel.DataAnnotations;

namespace Aluminum.Data
{
    public enum CostumeOriginType : byte
    {
        Europe = 1,
        America = 2,
        Asia = 3,
        Africa = 4,

        [Display(Name = "Outer Space")]
        Space = 5
    }
}