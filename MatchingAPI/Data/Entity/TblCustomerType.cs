using System;
using System.Collections.Generic;

namespace MatchingAPI.Data.Entity;

public partial class TblCustomerType
{
    public long IntBusinessPartnerTypeId { get; set; }

    public string StrBusinessPartnerTypeName { get; set; } = null!;

    public long IntActionBy { get; set; }

    public DateTime DteLastActionDateTime { get; set; }

    public DateTime DteServerDateTime { get; set; }

    public bool IsActive { get; set; }
}
