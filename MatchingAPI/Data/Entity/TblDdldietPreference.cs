using System;
using System.Collections.Generic;

namespace MatchingAPI.Data.Entity;

public partial class TblDdldietPreference
{
    public long IntDietId { get; set; }

    public string StrDietType { get; set; } = null!;

    public bool? IsActive { get; set; }

    public DateTime? DteLastActionDate { get; set; }

    public long? IntPreferencyTypeId { get; set; }

    public virtual ICollection<TblUserPreferredDiet> TblUserPreferredDiets { get; set; } = new List<TblUserPreferredDiet>();
}
