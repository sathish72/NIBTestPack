using System.ComponentModel;
using System.Runtime.Serialization;

namespace BusinessService.Enums
{
    public enum ExpenseTypeEnum
    {
        [Description("Lease")]
        [EnumMember]
        Lease = 1,

        [Description("Child Support")]
        [EnumMember]
        ChildSupport = 2
    }
}
