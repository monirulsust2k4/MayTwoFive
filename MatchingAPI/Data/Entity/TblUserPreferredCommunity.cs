using System;
using System.Collections.Generic;

namespace MatchingAPI.Data.Entity;

public partial class TblUserPreferredCommunity
{
    public long IntId { get; set; }

    public long IntUserPreferenceId { get; set; }

    public long IntCommunityId { get; set; }

    public bool? IsActive { get; set; }

    public DateTime? DteLastActionDateTime { get; set; }

    public virtual TblDdlcommunity IntCommunity { get; set; } = null!;

    public virtual TblUserPreferenceSummery IntUserPreference { get; set; } = null!;
}
