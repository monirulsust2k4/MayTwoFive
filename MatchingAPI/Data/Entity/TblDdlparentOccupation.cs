using System;
using System.Collections.Generic;

namespace MatchingAPI.Data.Entity;

public partial class TblDdlparentOccupation
{
    public long IntOccupationId { get; set; }

    public string StrOccupationName { get; set; } = null!;

    public string StrParentType { get; set; } = null!;

    public bool? IsActive { get; set; }

    public DateTime? DteLastActionDateTime { get; set; }

    public long? IntPreferencyTypeId { get; set; }

    public virtual ICollection<TblUserPreferredParentOccupation> TblUserPreferredParentOccupations { get; set; } = new List<TblUserPreferredParentOccupation>();
}
