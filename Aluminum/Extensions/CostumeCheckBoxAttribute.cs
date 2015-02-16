using System.ComponentModel.DataAnnotations;

namespace Aluminum.Web.Extensions
{
    public class CostumeCheckBoxAttribute : UIHintAttribute
    {
        public CostumeCheckBoxAttribute()
            : base("_EditCostumeCheckbox")
        {
        }
    }
}