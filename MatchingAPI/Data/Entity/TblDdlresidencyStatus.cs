using System;
using System.Collections.Generic;

namespace MatchingAPI.Data.Entity;

public partial class TblDdlresidencyStatus
{
    public long IntResidencyId { get; set; }

    public string StrResidencyType { get; set; } = null!;

    public bool? IsActive { get; set; }

    public DateTime? DteLastActionDate { get; set; }

    public long? IntPreferencyTypeId { get; set; }

    public virtual ICollection<TblUserPreferredResidencyStatus> TblUserPreferredResidencyStatuses { get; set; } = new List<TblUserPreferredResidencyStatus>();
}
