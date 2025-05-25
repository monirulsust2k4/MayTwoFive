using System;
using System.Collections.Generic;

namespace MatchingAPI.Data.Entity;

public partial class TblReligion
{
    public long IntReligionId { get; set; }

    public string StrReligionName { get; set; } = null!;

    public bool? IsActive { get; set; }

    public long? IntPreferencyTypeId { get; set; }
}
