using System;
using System.Collections.Generic;

namespace MatchingAPI.Data.Entity;

public partial class TblSubscriptionPlan
{
    public long IntPlanId { get; set; }

    public string StrPlanName { get; set; } = null!;

    public decimal DecPrice { get; set; }

    public string StrDuration { get; set; } = null!;

    public string StrProfileVisibility { get; set; } = null!;

    public bool IsIncreasedMatchScore { get; set; }

    public long? IntNumberOfMatches { get; set; }

    public long? IntMessageLimit { get; set; }

    public bool IsAccessToPremiumProfiles { get; set; }

    public bool IsPrioritySupport { get; set; }

    public bool IsAccessToAdvancedFilters { get; set; }

    public decimal? DecDiscountPercentage { get; set; }

    public string? StrAdditionalBenefits { get; set; }

    public bool? IsActive { get; set; }

    public DateTime? DteLastActionDateTime { get; set; }

    public DateTime? DteServerDateTime { get; set; }

    public long? IntActionBy { get; set; }

    public DateTime? DteStartDate { get; set; }

    public DateTime? DteEndDate { get; set; }
}
