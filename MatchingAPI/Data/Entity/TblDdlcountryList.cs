using System;
using System.Collections.Generic;

namespace MatchingAPI.Data.Entity;

public partial class TblDdlcountryList
{
    public long IntCountryId { get; set; }

    public string StrCountryName { get; set; } = null!;

    public bool? IsActive { get; set; }

    public string? StrMotherLanguage { get; set; }

    public long? IntPreferencyTypeId { get; set; }

    public virtual ICollection<TblUserPreferredCountry> TblUserPreferredCountries { get; set; } = new List<TblUserPreferredCountry>();
}
