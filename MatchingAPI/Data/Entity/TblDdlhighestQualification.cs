using System;
using System.Collections.Generic;

namespace MatchingAPI.Data.Entity;

public partial class TblDdlhighestQualification
{
    public long IntQualificationId { get; set; }

    public string StrQualificationName { get; set; } = null!;

    public string StrQualificationType { get; set; } = null!;

    public string StrFaculty { get; set; } = null!;

    public long StrSortOrder { get; set; }

    public bool IsActive { get; set; }

    public DateTime? DteCreatedDate { get; set; }

    public DateTime? DteUpdatedDate { get; set; }

    public long? IntPreferencyTypeId { get; set; }

    public virtual ICollection<TblUserPreferredQualification> TblUserPreferredQualifications { get; set; } = new List<TblUserPreferredQualification>();
}
