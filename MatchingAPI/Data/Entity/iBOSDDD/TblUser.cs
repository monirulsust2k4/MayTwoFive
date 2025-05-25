using System;
using System.Collections.Generic;

namespace MatchingAPI.Data.Entity.iBOSDDD;

public partial class TblUser
{
    public long IntUserId { get; set; }

    public string? StrUserName { get; set; }

    public long IntAccountId { get; set; }

    public long? IntDefaultBusinessUnit { get; set; }

    public string? StrLoginId { get; set; }

    public string? StrPassword { get; set; }

    public string? StrEmailAddress { get; set; }

    public bool? IsDefaultPassword { get; set; }

    public string? StrContact { get; set; }

    public long? IntCountryId { get; set; }

    public string? StrCountryName { get; set; }

    public DateOnly? DtePasswordExpDate { get; set; }

    public long? IntUserType { get; set; }

    public long? IntUserReferenceId { get; set; }

    public string? StrUserReferenceNo { get; set; }

    public bool? IsSuperUser { get; set; }

    public bool? IsFeatureUser { get; set; }

    public long? IntActionBy { get; set; }

    public DateTime? DteLastActionDateTime { get; set; }

    public DateTime? DteServerDateTime { get; set; }

    public bool? IsActive { get; set; }

    public string? StrUserNidno { get; set; }

    public string? StrUserImageFile { get; set; }

    public bool? IsForceLogout { get; set; }

    public bool IsOtp { get; set; }

    public bool IsMgt { get; set; }

    public bool? IsApproveIhb { get; set; }

    public long? IntUpdatedBy { get; set; }
}
