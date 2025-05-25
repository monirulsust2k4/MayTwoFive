using System;
using System.Collections.Generic;

namespace MatchingAPI.Data.Entity;

public partial class TblUserPreferredParentOccupation
{
    public long IntId { get; set; }

    public long IntUserPreferenceId { get; set; }

    public long IntOccupationId { get; set; }

    public bool? IsActive { get; set; }

    public DateTime? DteLastActionDateTime { get; set; }

    public long? IntFamilyMembersTypeId { get; set; }

    public virtual TblDdlparentOccupation IntOccupation { get; set; } = null!;

    public virtual TblUserPreferenceSummery IntUserPreference { get; set; } = null!;
}
