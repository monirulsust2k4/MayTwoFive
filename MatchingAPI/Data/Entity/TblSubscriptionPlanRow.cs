using System;
using System.Collections.Generic;

namespace MatchingAPI.Data.Entity;

public partial class TblSubscriptionPlanRow
{
    public long IntChangeRequestId { get; set; }

    public long IntMembershipId { get; set; }

    public long IntUserId { get; set; }

    public long IntCurrentPlan { get; set; }

    public string StrCurrentPlan { get; set; } = null!;

    public long IntRequestedPlan { get; set; }

    public string StrRequestedPlan { get; set; } = null!;

    public DateTime DteChangeRequestDate { get; set; }

    public DateTime? DteChangeProcessedDate { get; set; }

    public string StrChangeStatus { get; set; } = null!;

    public string? StrReasonForChange { get; set; }

    public string? StrAdminNotes { get; set; }

    public string? StrPaymentStatus { get; set; }

    public bool IsChangeCompleted { get; set; }

    public DateTime DteCreatedAt { get; set; }

    public DateTime DteUpdatedAt { get; set; }
}
