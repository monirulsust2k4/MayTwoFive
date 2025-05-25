using System;
using System.Collections.Generic;

namespace MatchingAPI.Data.Entity;

public partial class TblAccountGroup
{
    public long IntAccountGroupId { get; set; }

    public string StrAccountGroupCode { get; set; } = null!;

    public string StrAccountGroupName { get; set; } = null!;

    public bool IsIncomeStatementAccount { get; set; }

    public int IntAccountType { get; set; }

    public bool IsActive { get; set; }
}
