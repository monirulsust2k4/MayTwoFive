using System;
using System.Collections.Generic;

namespace MatchingAPI.Data.Entity;

public partial class TblThana
{
    public long IntThanaId { get; set; }

    public string StrThanaName { get; set; } = null!;

    public long IntDistrictId { get; set; }

    public long IntDivisionId { get; set; }

    public long IntCountryId { get; set; }

    public string StrThanaBanglaName { get; set; } = null!;

    public string? StrSubOffice { get; set; }

    public string StrPostCode { get; set; } = null!;

    public bool IsActive { get; set; }
}
