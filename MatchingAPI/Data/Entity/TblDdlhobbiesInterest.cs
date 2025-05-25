using System;
using System.Collections.Generic;

namespace MatchingAPI.Data.Entity;

public partial class TblDdlhobbiesInterest
{
    public long IntHobbyId { get; set; }

    public string StrHobbyName { get; set; } = null!;

    public string StrCategory { get; set; } = null!;

    public bool? IsActive { get; set; }

    public DateTime? DteLastActionTime { get; set; }

    public DateTime? DteServerDateTime { get; set; }

    public long? IntPreferencyTypeId { get; set; }

    public virtual ICollection<TblUserPreferredHobby> TblUserPreferredHobbies { get; set; } = new List<TblUserPreferredHobby>();
}
