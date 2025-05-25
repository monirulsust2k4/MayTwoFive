using System;
using System.Collections.Generic;

namespace MatchingAPI.Data.Entity;

public partial class TblUserWorkInformation
{
    public long IntWorkId { get; set; }

    public long IntUserId { get; set; }

    public string StrCompanyName { get; set; } = null!;

    public long IntDesignationId { get; set; }

    public string StrDesignation { get; set; } = null!;

    public long IntIndustryId { get; set; }

    public string? StrIndustry { get; set; }

    public decimal? DecIncome { get; set; }

    public string? StrCurrencyCode { get; set; }

    public bool? IsWorkFromHome { get; set; }

    public DateTime? DteFromDate { get; set; }

    public DateTime? DteToDate { get; set; }

    public bool? IsActive { get; set; }

    public DateTime? DteCreatedAt { get; set; }

    public DateTime? DteUpdatedAt { get; set; }
}
