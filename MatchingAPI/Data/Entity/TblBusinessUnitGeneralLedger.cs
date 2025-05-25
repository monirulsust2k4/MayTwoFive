using System;
using System.Collections.Generic;

namespace MatchingAPI.Data.Entity;

public partial class TblBusinessUnitGeneralLedger
{
    public long IntAutoId { get; set; }

    public long IntAccountId { get; set; }

    public long IntBusinessUnitId { get; set; }

    public long IntGeneralLedgerId { get; set; }

    public string? StrGeneralLedgerCode { get; set; }

    public string? StrGeneralLedgerName { get; set; }

    public decimal NumCurrentBalance { get; set; }

    public long IntActionBy { get; set; }

    public DateTime DteLastActionDateTime { get; set; }

    public DateTime DteServerDateTime { get; set; }

    public bool IsActive { get; set; }
}
