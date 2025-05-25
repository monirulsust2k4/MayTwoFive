using System;
using System.Collections.Generic;

namespace MatchingAPI.Data.Entity;

public partial class TblUserProfessionalDetail
{
    public long IntUserProfessionDetId { get; set; }

    public long? IntUserId { get; set; }

    public string StrQualification { get; set; } = null!;

    public string StrInstitute { get; set; } = null!;

    public long? PassingYear { get; set; }

    public bool? IsActive { get; set; }

    public DateTime? DteInsertDate { get; set; }
}
