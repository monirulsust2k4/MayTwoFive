using System;
using System.Collections.Generic;

namespace MatchingAPI.Data.Entity;

public partial class NotifySendFailedLog
{
    public long IntId { get; set; }

    public long? IntEmployeeId { get; set; }

    public long? IntFeatureTableAutoId { get; set; }

    public string? StrFeature { get; set; }

    public DateTime? DteCreatedAt { get; set; }

    public long? IntCreatedBy { get; set; }
}
