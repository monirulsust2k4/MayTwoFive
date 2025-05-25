using System;
using System.Collections.Generic;

namespace MatchingAPI.Data.Entity;

public partial class TblDdlcommunity
{
    public long IntCommunityId { get; set; }

    public string StrCountry { get; set; } = null!;

    public string StrCommunityName { get; set; } = null!;

    public bool? IsActive { get; set; }

    public DateTime? DteLastActionDate { get; set; }

    public long? IntPreferencyTypeId { get; set; }

    public virtual ICollection<TblUserPreferredCommunity> TblUserPreferredCommunities { get; set; } = new List<TblUserPreferredCommunity>();
}
