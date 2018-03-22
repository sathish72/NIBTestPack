using System.ComponentModel;
using System.Runtime.Serialization;

namespace BusinessService.Enums
{
    public enum FrequencyEnum
    {
        [Description("Weekly")]
        [EnumMember]
        Weekly = 1,

        [Description("Monthly")]
        [EnumMember]
        Monthly = 2,

        [Description("Fortnightly")]
        [EnumMember]
        Fortnightly = 3
    }
}
