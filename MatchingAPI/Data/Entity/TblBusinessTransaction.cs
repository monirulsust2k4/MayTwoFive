using System;
using System.Collections.Generic;

namespace MatchingAPI.Data.Entity;

public partial class TblBusinessTransaction
{
    public long IntBusinessTransactionId { get; set; }

    public string StrBusinessTransactionName { get; set; } = null!;

    public string StrBusinessTransactionCode { get; set; } = null!;

    public long IntAccountId { get; set; }

    public long IntBusinessUnitId { get; set; }

    public long IntGeneralLedgerId { get; set; }

    public string StrGeneralLedgerCode { get; set; } = null!;

    public string StrGeneralLedgerName { get; set; } = null!;

    public bool? IsInternalExpense { get; set; }

    public bool? IsDefault { get; set; }

    public long IntActionBy { get; set; }

    public DateTime DteLastActionDateTime { get; set; }

    public DateTime DteServerDateTime { get; set; }

    public bool IsActive { get; set; }
}
