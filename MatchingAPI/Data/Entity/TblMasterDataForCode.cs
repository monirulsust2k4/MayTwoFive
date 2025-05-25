using System;
using System.Collections.Generic;

namespace MatchingAPI.Data.Entity;

public partial class TblMasterDataForCode
{
    public long IntId { get; set; }

    public long IntAccountId { get; set; }

    public long IntMasterDataTypeId { get; set; }

    public string StrMasterDataTypeName { get; set; } = null!;

    public long IntSubTypeId { get; set; }

    public string StrSubTypeName { get; set; } = null!;

    public string StrTypePrefix { get; set; } = null!;

    public long IntCounter { get; set; }

    public bool IsActive { get; set; }
}
