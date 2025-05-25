using System;
using System.Collections.Generic;

namespace MatchingAPI.Data.Entity;

public partial class TblUserPreferenceSummery
{
    public long IntUsererenceId { get; set; }

    public long IntUserId { get; set; }

    public long IntUnitId { get; set; }

    public long IntAgeMin { get; set; }

    public long IntAgeMax { get; set; }

    public decimal? DecHeightMin { get; set; }

    public decimal? DecHeightMax { get; set; }

    public long? IntMaritalStatusId { get; set; }

    public long? IntReligionId { get; set; }

    public bool? IsCommunitPreperence { get; set; }

    public long? IntCommunityId { get; set; }

    public long? IntSubCommunityId { get; set; }

    public long? IntCountryId { get; set; }

    public long? IntDistrictId { get; set; }

    public long? IntThanaId { get; set; }

    public long? IntResidencyStatusId { get; set; }

    public long? IntHighestQualificationId { get; set; }

    public long? IntWorkDesignationId { get; set; }

    public long? IntWorkIndustryId { get; set; }

    public decimal? DecAnnualIncomeMin { get; set; }

    public decimal? DecAnnualIncomeMax { get; set; }

    public string? StrDiet { get; set; }

    public string? StrHobbiesAndInterests { get; set; }

    public long? IntMotherOccupationId { get; set; }

    public long? IntFatherOccupationId { get; set; }

    public long? IntNoOfSisters { get; set; }

    public long? IntNoOfBrothers { get; set; }

    public bool? IsActive { get; set; }

    public DateTime? DteCreatedDate { get; set; }

    public DateTime? DteUpdatedDate { get; set; }

    public string? StrGender { get; set; }

    public virtual ICollection<TblUserPreferredCommunity> TblUserPreferredCommunities { get; set; } = new List<TblUserPreferredCommunity>();

    public virtual ICollection<TblUserPreferredCountry> TblUserPreferredCountries { get; set; } = new List<TblUserPreferredCountry>();

    public virtual ICollection<TblUserPreferredDiet> TblUserPreferredDiets { get; set; } = new List<TblUserPreferredDiet>();

    public virtual ICollection<TblUserPreferredHobby> TblUserPreferredHobbies { get; set; } = new List<TblUserPreferredHobby>();

    public virtual ICollection<TblUserPreferredMaritalStatus> TblUserPreferredMaritalStatuses { get; set; } = new List<TblUserPreferredMaritalStatus>();

    public virtual ICollection<TblUserPreferredParentOccupation> TblUserPreferredParentOccupations { get; set; } = new List<TblUserPreferredParentOccupation>();

    public virtual ICollection<TblUserPreferredQualification> TblUserPreferredQualifications { get; set; } = new List<TblUserPreferredQualification>();

    public virtual ICollection<TblUserPreferredResidencyStatus> TblUserPreferredResidencyStatuses { get; set; } = new List<TblUserPreferredResidencyStatus>();

    public virtual ICollection<TblUserPreferredSubCommunity> TblUserPreferredSubCommunities { get; set; } = new List<TblUserPreferredSubCommunity>();

    public virtual ICollection<TblUserPreferredWorkDesignation> TblUserPreferredWorkDesignations { get; set; } = new List<TblUserPreferredWorkDesignation>();

    public virtual ICollection<TblUserPreferredWorkIndustry> TblUserPreferredWorkIndustries { get; set; } = new List<TblUserPreferredWorkIndustry>();
}
