using System.ComponentModel.DataAnnotations;

namespace Aluminum.Extensions
{
    public class CostumeEnumAttribute : UIHintAttribute
    {
        public CostumeEnumAttribute()
            : base("_EditCostumeEnum")
        {
        }
    }
}