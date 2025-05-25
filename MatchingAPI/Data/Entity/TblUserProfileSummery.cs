using System;
using System.Collections.Generic;

namespace MatchingAPI.Data.Entity;

public partial class TblUserProfileSummery
{
    public long IntUserId { get; set; }

    public string StrName { get; set; } = null!;

    public string? StrCode { get; set; }

    public DateOnly DteDateOfBirth { get; set; }

    public string StrPresentAddress { get; set; } = null!;

    public string StrPermanentAddress { get; set; } = null!;

    public long? IntReligionId { get; set; }

    public string? StrEmail { get; set; }

    public string? StrMobileNumber { get; set; }

    public long? IntCommunityId { get; set; }

    public long? IntCountryId { get; set; }

    public string? StrCountryName { get; set; }

    public string? StrProfileFor { get; set; }

    public string? StrGender { get; set; }

    public long? IntDistrictId { get; set; }

    public long? IntThanaId { get; set; }

    public long? IntResidencyStatusId { get; set; }

    public long? IntSubCommunityId { get; set; }

    public bool? IsPartnerCommunityPreference { get; set; }

    public long? IntMaritalStatusId { get; set; }

    public long? DecHeight { get; set; }

    public string? StrDiet { get; set; }

    public long? IntHighestQualificationId { get; set; }

    public string? StrCollege { get; set; }

    public string? StrHobbiesAndInterests { get; set; }

    public decimal? DecAnnualIncome { get; set; }

    public long? IntWorkDesignationId { get; set; }

    public long? IntWorkIndustryId { get; set; }

    public long? IntMotherOccupationId { get; set; }

    public long? IntFatherDetailsId { get; set; }

    public long? IntNoOfSisters { get; set; }

    public long? IntNoOfBrothers { get; set; }

    public long? IntUnitId { get; set; }

    public DateTime? DteLastActionDate { get; set; }

    public bool? IsActive { get; set; }

    public bool? IsApprove { get; set; }

    public DateTime? DteApproveDate { get; set; }

    public long? IntApproveBy { get; set; }
}
