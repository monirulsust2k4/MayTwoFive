using System;
using System.Collections.Generic;

namespace MatchingAPI.Data.Entity.iBOSDDD;

public partial class TblEmailSend
{
    public long IntEmailId { get; set; }

    public long? IntAccountId { get; set; }

    public long? IntUnitId { get; set; }

    public string? StrEmailProfile { get; set; }

    public string? StrEmailAdd { get; set; }

    public string? StrCcemailAdd { get; set; }

    public string? StrBcemailAdd { get; set; }

    public string? StrSubject { get; set; }

    public string? StrBody { get; set; }

    public string? StrFilePath { get; set; }

    public DateTime DteInsertTime { get; set; }

    public int IntMailTypeId { get; set; }

    public DateTime? DteSendTime { get; set; }

    public bool YsnHtml { get; set; }

    public long? IntPartnerId { get; set; }

    public string? StrPartnerName { get; set; }

    public int? IntPartnerTypeId { get; set; }
}
