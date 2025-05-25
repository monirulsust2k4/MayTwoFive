using System;
using System.Collections.Generic;

namespace MatchingAPI.Data.Entity;

public partial class TblDdlmaritalStatus
{
    public long IntMaritalStatusId { get; set; }

    public string StrStatusName { get; set; } = null!;

    public bool? IsActive { get; set; }

    public DateTime? DteLastActionDate { get; set; }

    public long? IntPreferencyTypeId { get; set; }

    public virtual ICollection<TblUserPreferredMaritalStatus> TblUserPreferredMaritalStatuses { get; set; } = new List<TblUserPreferredMaritalStatus>();
}
