using System;
using System.Collections.Generic;

namespace MatchingAPI.Data.Entity;

public partial class NotificationDetail
{
    public long IntId { get; set; }

    public long? IntMasterId { get; set; }

    public string? StrReceiver { get; set; }

    public string? StrCreatedBy { get; set; }

    public DateTime? DteCreatedAt { get; set; }

    public bool? IsActive { get; set; }
}
