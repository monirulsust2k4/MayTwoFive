using System;
using System.Collections.Generic;

namespace MatchingAPI.Data.Entity;

public partial class TblGeneralLedgerType
{
    public long IntGeneralLedgerTypeId { get; set; }

    public string IntGeneralLedgerTypeName { get; set; } = null!;

    public bool IsActive { get; set; }
}
