using System;
using System.Collections.Generic;

namespace MatchingAPI.Data.Entity;

public partial class TblDdlworkDesignation
{
    public long IntDesignationId { get; set; }

    public string StrDesignationName { get; set; } = null!;

    public bool? IsActive { get; set; }

    public DateTime? DteLastActionTime { get; set; }

    public long? IntPreferencyTypeId { get; set; }

    public virtual ICollection<TblUserPreferredWorkDesignation> TblUserPreferredWorkDesignations { get; set; } = new List<TblUserPreferredWorkDesignation>();
}
