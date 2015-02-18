using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using Aluminum.Data;
using Aluminum.Web.Extensions;
using Newtonsoft.Json;

namespace Aluminum.Web.ViewModels
{
    public class CostumeViewModel
    {
        public CostumeViewModel()
        {
            AgeRanges = new List<AgeRangeType>();
            HairLengths = new List<HairLengthType>();
            HairColors = new List<HairColorType>();
            Sources = new List<CostumeSourceType>();
        }

        public short Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string ImageFileName { get; set; }

        #region Properties

        [CostumeEnum]
        [DisplayName("Gender")]
        public GenderType? GenderTypeId { get; set; }

        [CostumeEnum]
        [DisplayName("Place of Origin")]
        public CostumeOriginType? CostumeOriginTypeId { get; set; }

        [CostumeEnum]
        [DisplayName("Kind of Job")]
        public JobType? JobTypeId { get; set; }

        [CostumeEnumList]
        [DisplayName("Age Range")]
        [JsonIgnore]
        public EnumList AgeRangeEnumList
        {
            get { return GetEnumList(e => e.AgeRanges); }
        }
        public List<AgeRangeType> AgeRanges { get; set; }

        [CostumeEnumList]
        [DisplayName("Hair Length")]
        [JsonIgnore]
        public EnumList HairLengthEnumList
        {
            get { return GetEnumList(e => e.HairLengths); }
        }
        public List<HairLengthType> HairLengths { get; set; }

        [CostumeEnumList]
        [DisplayName("Hair Color")]
        [JsonIgnore]
        public EnumList HairColorEnumList
        {
            get { return GetEnumList(e => e.HairColors); }
        }
        public List<HairColorType> HairColors { get; set; }

        [CostumeEnumList]
        [DisplayName("Source")]
        [JsonIgnore]
        public EnumList SourceEnumList
        {
            get { return GetEnumList(e => e.Sources); }
        }
        public List<CostumeSourceType> Sources { get; set; }

        [CostumeCheckBox]
        [DisplayName("Has Facial Hair")]
        public bool HasFacialHair { get; set; }

        [CostumeCheckBox]
        [DisplayName("Has Magic")]
        public bool HasMagic { get; set; }

        [CostumeCheckBox]
        [DisplayName("Has Super Powers")]
        public bool HasSuperPowers { get; set; }

        [CostumeCheckBox]
        [DisplayName("Is Fictional")]
        public bool IsFictional { get; set; }

        [CostumeCheckBox]
        [DisplayName("Is Human")]
        public bool IsHuman { get; set; }

        [CostumeCheckBox]
        [DisplayName("Has Glasses")]
        public bool HasEyeglasses { get; set; }

        #endregion Properties

        #region Private Helpers

        private EnumList GetEnumList<TEnum>(
            Expression<Func<CostumeViewModel,
            List<TEnum>>> enumListExpression)
            where TEnum : struct, IConvertible, IComparable, IFormattable
        {
            var enumList = new EnumList();
            enumList.Init(this, enumListExpression);
            return enumList;
        }

        #endregion Private Helpers
    }
}