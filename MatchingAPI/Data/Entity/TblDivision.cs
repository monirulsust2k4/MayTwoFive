using System;
using System.Collections.Generic;

namespace MatchingAPI.Data.Entity;

public partial class TblDivision
{
    public long IntDivisionId { get; set; }

    public string StrDivisionGeocode { get; set; } = null!;

    public string StrDivision { get; set; } = null!;

    public long IntCountryId { get; set; }

    public string StrCountryName { get; set; } = null!;

    public bool IsActive { get; set; }

    public string StrDivitionBanglaName { get; set; } = null!;
}
