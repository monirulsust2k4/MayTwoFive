using System;
using System.Collections.Generic;

namespace MatchingAPI.Data.Entity;

public partial class NotificationCategory
{
    public long IntId { get; set; }

    public string StrCategoriesName { get; set; } = null!;

    public string? StrGenericMessageText { get; set; }

    public string? StrImageUrl { get; set; }

    public long? IntCreatedBy { get; set; }

    public DateTime? DteCreatedAt { get; set; }

    public long? IntUpdatedBy { get; set; }

    public DateTime? DteUpdatedAt { get; set; }

    public bool? IsActive { get; set; }
}
