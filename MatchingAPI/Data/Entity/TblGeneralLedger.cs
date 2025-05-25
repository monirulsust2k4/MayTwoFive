using System;
using System.Collections.Generic;

namespace MatchingAPI.Data.Entity;

public partial class TblGeneralLedger
{
    public long IntGeneralLedgerId { get; set; }

    public long IntAccountId { get; set; }

    public long IntAccountGroupId { get; set; }

    public long IntAccountClassId { get; set; }

    public long IntAccountCategoryId { get; set; }

    public string StrGeneralLedgerCode { get; set; } = null!;

    public string StrGeneralLedgerName { get; set; } = null!;

    public long IntGeneralLedgerTypeId { get; set; }

    public bool? IsScheduleView { get; set; }

    public bool? IsSubGlallowed { get; set; }

    public long IntActionBy { get; set; }

    public DateTime DteLastActionDateTime { get; set; }

    public DateTime DteServerDateTime { get; set; }

    public bool IsActive { get; set; }
}
