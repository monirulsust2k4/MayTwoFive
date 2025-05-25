using System;
using System.Collections.Generic;

namespace MatchingAPI.Data.Entity;

public partial class Url
{
    public long IntUrlId { get; set; }

    public string StrDomainName { get; set; } = null!;

    public string StrUrl { get; set; } = null!;

    public string? StrIpaddress { get; set; }

    public bool? IsActive { get; set; }
}
