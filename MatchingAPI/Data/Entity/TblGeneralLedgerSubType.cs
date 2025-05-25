using System;
using System.Collections.Generic;

namespace MatchingAPI.Data.Entity;

public partial class TblGeneralLedgerSubType
{
    public long IntGeneralLedgerSubTypeId { get; set; }

    public string StrGeneralLedgerSubTypeName { get; set; } = null!;

    public bool IsActive { get; set; }
}
