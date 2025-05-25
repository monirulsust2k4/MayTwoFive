using System;
using System.Collections.Generic;

namespace MatchingAPI.Data.Entity;

public partial class TblUserHobbiesInterest
{
    public long IntAutoId { get; set; }

    public long IntUserId { get; set; }

    public string StrSection { get; set; } = null!;

    public string StrHobbyName { get; set; } = null!;

    public bool? IsActive { get; set; }

    public DateTime? DteLastActionDate { get; set; }
}
