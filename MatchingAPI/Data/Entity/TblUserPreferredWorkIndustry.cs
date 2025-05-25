using System;
using System.Collections.Generic;

namespace MatchingAPI.Data.Entity;

public partial class TblUserPreferredWorkIndustry
{
    public long IntId { get; set; }

    public long IntUserPreferenceId { get; set; }

    public long IntWorkIndustryId { get; set; }

    public bool? IsActive { get; set; }

    public DateTime? DteLastActionDateTime { get; set; }

    public virtual TblUserPreferenceSummery IntUserPreference { get; set; } = null!;

    public virtual TblDdlworkIndustry IntWorkIndustry { get; set; } = null!;
}
