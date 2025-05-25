using System;
using System.Collections.Generic;

namespace MatchingAPI.Data.Entity;

public partial class NotificationMaster
{
    public long IntId { get; set; }

    public long? IntOrgId { get; set; }

    public string? StrNotifyTitle { get; set; }

    public string? StrNotifyDetails { get; set; }

    public long? IntModuleId { get; set; }

    public string? StrModule { get; set; }

    public string? StrFeature { get; set; }

    public long? IntFeatureTableAutoId { get; set; }

    public long? IntEmployeeId { get; set; }

    public string? StrLoginId { get; set; }

    public bool? IsCommon { get; set; }

    public string? StrReceiver { get; set; }

    public bool? IsSeen { get; set; }

    public string? StrCreatedBy { get; set; }

    public DateTime? DteCreatedAt { get; set; }

    public bool? IsActive { get; set; }

    public long? IntUserId { get; set; }
}
