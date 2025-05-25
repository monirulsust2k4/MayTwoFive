using System;
using System.Collections.Generic;

namespace MatchingAPI.Data.Entity;

public partial class User
{
    public long IntUserId { get; set; }

    public string StrLoginId { get; set; } = null!;

    public string StrPassword { get; set; } = null!;

    public string? StrOldPassword { get; set; }

    public string StrDisplayName { get; set; } = null!;

    public long IntUserTypeId { get; set; }

    public long? IntRefferenceId { get; set; }

    public bool? IsOfficeAdmin { get; set; }

    public bool? IsSuperuser { get; set; }

    public DateTime? DteLastLogin { get; set; }

    public bool? IsActive { get; set; }

    public long IntUrlId { get; set; }

    public long IntAccountId { get; set; }

    public DateTime DteCreatedAt { get; set; }

    public long? IntCreatedBy { get; set; }

    public DateTime? DteUpdatedAt { get; set; }

    public long? IntUpdatedBy { get; set; }

    public bool IsOwner { get; set; }

    public string? StrLoginGmailId { get; set; }

    public string? StrLoginFacbookId { get; set; }
}
