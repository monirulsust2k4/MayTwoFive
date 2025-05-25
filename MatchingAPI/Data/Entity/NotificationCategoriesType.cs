using System;
using System.Collections.Generic;

namespace MatchingAPI.Data.Entity;

public partial class NotificationCategoriesType
{
    public long IntId { get; set; }

    public string StrTypeName { get; set; } = null!;

    public long? IntCreatedBy { get; set; }

    public DateTime? DteCreatedAt { get; set; }

    public long? IntUpdatedBy { get; set; }

    public DateTime? DteUpdatedAt { get; set; }

    public bool? IsActive { get; set; }
}
