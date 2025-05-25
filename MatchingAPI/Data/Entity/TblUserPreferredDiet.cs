using System;
using System.Collections.Generic;

namespace MatchingAPI.Data.Entity;

public partial class TblUserPreferredDiet
{
    public long IntId { get; set; }

    public long IntUserPreferenceId { get; set; }

    public long IntDietId { get; set; }

    public bool? IsActive { get; set; }

    public DateTime? DteLastActionDateTime { get; set; }

    public virtual TblDdldietPreference IntDiet { get; set; } = null!;

    public virtual TblUserPreferenceSummery IntUserPreference { get; set; } = null!;
}
