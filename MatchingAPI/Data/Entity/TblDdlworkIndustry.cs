using System;
using System.Collections.Generic;

namespace MatchingAPI.Data.Entity;

public partial class TblDdlworkIndustry
{
    public long IntWorkId { get; set; }

    public string StrWorkType { get; set; } = null!;

    public bool? IsActive { get; set; }

    public DateTime? DteLastActionDate { get; set; }

    public long? IntPreferencyTypeId { get; set; }

    public virtual ICollection<TblUserPreferredWorkIndustry> TblUserPreferredWorkIndustries { get; set; } = new List<TblUserPreferredWorkIndustry>();
}
