using System.Runtime.Serialization;

namespace ApexClearing.SDK.Models.Enums
{
    public enum StatusType
    {
        [EnumMember(Value = "PENDING")]
        Pending,

        [EnumMember(Value = "PENDING_NEW")]
        PendingNew,

        [EnumMember(Value = "REJECTED")]
        Rejected,

        [EnumMember(Value = "FILLED")]
        Filled,

        [EnumMember(Value = "CANCELED")]
        Canceled,

        [EnumMember(Value = "CANCEL_REJECT")]
        Cancel_Reject
    }
}