using System;
using System.Collections.Generic;

namespace MatchingAPI.Data.Entity;

public partial class TblPriceStructureGl
{
    public long IntId { get; set; }

    public long IntAccountId { get; set; }

    public long? IntPriceComponentId { get; set; }

    public string StrPriceComponentName { get; set; } = null!;

    public long IntGeneralLedgerId { get; set; }

    public int? IsFactor { get; set; }

    public long? IntActionBy { get; set; }

    public DateTime? DteActionTime { get; set; }

    public bool? IsActive { get; set; }
}
