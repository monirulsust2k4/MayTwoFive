using System;
using System.Collections.Generic;

namespace MatchingAPI.Data.Entity;

public partial class TblDdlsubCommunity
{
    public long IntCommunityId { get; set; }

    public long IntReligionId { get; set; }

    public string StrSubCommunityName { get; set; } = null!;

    public bool? IsActive { get; set; }

    public long? IntPreferencyTypeId { get; set; }

    public virtual ICollection<TblUserPreferredSubCommunity> TblUserPreferredSubCommunities { get; set; } = new List<TblUserPreferredSubCommunity>();
}
