using System;
using System.Collections.Generic;

namespace MatchingAPI.Data.Entity;

public partial class TblUserPreferredCountry
{
    public long IntId { get; set; }

    public long IntUserPreferenceId { get; set; }

    public long IntCountryId { get; set; }

    public bool? IsActive { get; set; }

    public DateTime? DteLastActionDateTime { get; set; }

    public virtual TblDdlcountryList IntCountry { get; set; } = null!;

    public virtual TblUserPreferenceSummery IntUserPreference { get; set; } = null!;
}
