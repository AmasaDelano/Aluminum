using System.ComponentModel.DataAnnotations;

namespace Aluminum.Web.Extensions
{
    public class CostumeEnumAttribute : UIHintAttribute
    {
        public CostumeEnumAttribute()
            : base("_EditCostumeEnum")
        {
        }
    }
}