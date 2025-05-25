using System;
using System.Collections.Generic;

namespace MatchingAPI.Data.Entity;

public partial class TblDistrict
{
    public long IntDistrictId { get; set; }

    public long IntDivisionId { get; set; }

    public string StrDistrictGeocode { get; set; } = null!;

    public string StrDistrictName { get; set; } = null!;

    public long IntCountryId { get; set; }

    public long IntActionBy { get; set; }

    public DateTime DteLastActionDateTime { get; set; }

    public DateTime DteServerDateTime { get; set; }

    public bool IsActive { get; set; }
}
