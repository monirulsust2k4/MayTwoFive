using System;
using System.Collections.Generic;

namespace MatchingAPI.Data.Entity;

public partial class TblAccountCategory
{
    public long IntAccountCategoryId { get; set; }

    public long IntAccountId { get; set; }

    public long IntAccountGroupId { get; set; }

    public string StrAccountGroupCode { get; set; } = null!;

    public long IntAccountClassId { get; set; }

    public string StrAccountClassCode { get; set; } = null!;

    public string StrAccountCategoryCode { get; set; } = null!;

    public string StrAccountCategoryName { get; set; } = null!;

    public long IntActionBy { get; set; }

    public DateTime DteLastActionDateTime { get; set; }

    public DateTime DteServerDateTime { get; set; }

    public bool IsActive { get; set; }
}
