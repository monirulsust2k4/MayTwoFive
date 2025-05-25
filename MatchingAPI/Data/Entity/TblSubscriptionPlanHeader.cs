using System;
using System.Collections.Generic;

namespace MatchingAPI.Data.Entity;

public partial class TblSubscriptionPlanHeader
{
    public long IntMembershipId { get; set; }

    public long IntUserId { get; set; }

    public long IntPlanId { get; set; }

    public DateTime DteStartDate { get; set; }

    public DateTime DteEndDate { get; set; }

    public bool? IsActive { get; set; }

    public long? IntActionBy { get; set; }

    public DateTime? DteLastActionDateTime { get; set; }

    public DateTime? DteServerDateTime { get; set; }

    public long? IntUnitId { get; set; }

    public long? IntCustomerId { get; set; }
}
