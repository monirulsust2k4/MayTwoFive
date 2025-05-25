using System.ComponentModel.DataAnnotations;

namespace MatchingAPI.DTO
{
    public class UserProfileDTO
    {
        [Required]
        public string StrName { get; set; }
        public long UserID { get; set; }
        public DateTime? DteDateOfBirth { get; set; }
        public string StrPresentAddress { get; set; }
        public string StrPermanentAddress { get; set; }
        public int? IntReligionID { get; set; }
        public string StrEmail { get; set; }
        public string StrMobileNumber { get; set; }
        public int? IntCommunityID { get; set; }
        public int? IntCountryID { get; set; }
        public string StrCountryName { get; set; }
        public string StrProfileFor { get; set; }
        public string StrGender { get; set; }
        public int? IntDistrictID { get; set; }
        public int? IntThanaID { get; set; }
        public int? IntResidencyStatusID { get; set; }
        public int? IntSubCommunityID { get; set; }
        public bool IsPartnerCommunityPreference { get; set; }
        public int? IntMaritalStatusID { get; set; }
        public decimal? DecHeight { get; set; }
        public string StrDiet { get; set; }
        public int? IntHighestQualificationID { get; set; }
        public string StrCollege { get; set; }
        public string StrHobbiesAndInterests { get; set; }
        public decimal? DecAnnualIncome { get; set; }
        public int? IntWorkDesignationID { get; set; }
        public int? IntWorkIndustryID { get; set; }
        public int? IntMotherOccupationID { get; set; }
        public int? IntFatherDetailsID { get; set; }
        public int? IntNoOfSisters { get; set; }
        public int? IntNoOfBrothers { get; set; }
        public int? IntUnitId { get; set; }
        public DateTime? DteLastActionDate { get; set; }
        public bool IsActive { get; set; }
        public bool IsApprove { get; set; }
        public DateTime? DteApproveDate { get; set; }
        public int? IntApproveBy { get; set; }

        public List<CreateUserRowDTO> ServiceRows { get; set; }
        public List<CreateUserEducationRowDTO> EducationRows { get; set; }
        public List<CreateUserWorkInfoRowDTO> WorkInfoRows { get; set; }
        //public string jwtToken;

        public bool? IsUpdateEducationInfo { get; set; }
        public bool? IsUpdateWorkInfo { get; set; }
        public bool? IsUpdateHobbiesInfo { get; set; }
    }


    public class CreateUserRowDTO
    {
        public int UserId { get; set; }
        public string Section { get; set; }
        public string HobbiesName { get; set; }
        public bool Active { get; set; }
        public DateTime? LastActionDate { get; set; }



    }
    public class CreateUserEducationRowDTO
    {
        public long UserProfessionDetId { get; set; }

        public long? UserId { get; set; }

        public string Qualification { get; set; } = null!;

        public string Institute { get; set; } = null!;

        public long? Sesson { get; set; }



    }

    public class CreateUserWorkInfoRowDTO
    {
        public long UserId { get; set; }

        public string CompanyName { get; set; } = null!;

        public long DesignationId { get; set; }

        public string DesignationName { get; set; } = null!;

        public long IndustryId { get; set; }

        public string? IndustryName { get; set; }

        public decimal? Income { get; set; }

        public string? CurrencyCode { get; set; }

        public bool? IsWork { get; set; }

        public DateTime? FromDate { get; set; }

        public DateTime? ToDate { get; set; }

        public bool? ActiveStatus { get; set; }

        public DateTime? CreatedAt { get; set; }




    }

    public class UserProfileSummeryDTO
    {
        [Required]
        public string StrName { get; set; }
        public long UserID { get; set; }
        public DateTime? DteDateOfBirth { get; set; }
        public string StrPresentAddress { get; set; }
        public string StrPermanentAddress { get; set; }
        public int? IntReligionID { get; set; }
        public string StrEmail { get; set; }
        public string StrMobileNumber { get; set; }
        public int? IntCommunityID { get; set; }
        public int? IntCountryID { get; set; }
        public string StrCountryName { get; set; }
        public string StrProfileFor { get; set; }
        public string StrGender { get; set; }
        public int? IntDistrictID { get; set; }
        public int? IntThanaID { get; set; }
        public int? IntResidencyStatusID { get; set; }
        public int? IntSubCommunityID { get; set; }
        public bool IsPartnerCommunityPreference { get; set; }
        public int? IntMaritalStatusID { get; set; }
        public decimal? DecHeight { get; set; }
        public string StrDiet { get; set; }
        public int? IntHighestQualificationID { get; set; }
        public string StrCollege { get; set; }
        public string StrHobbiesAndInterests { get; set; }
        public decimal? DecAnnualIncome { get; set; }
        public int? IntWorkDesignationID { get; set; }
        public int? IntWorkIndustryID { get; set; }
        public int? IntMotherOccupationID { get; set; }
        public int? IntFatherDetailsID { get; set; }
        public int? IntNoOfSisters { get; set; }
        public int? IntNoOfBrothers { get; set; }
        public int? IntUnitId { get; set; }
        public DateTime? DteLastActionDate { get; set; }
        public bool IsActive { get; set; }
        public bool IsApprove { get; set; }
        public DateTime? DteApproveDate { get; set; }
        public int? IntApproveBy { get; set; }

        
        public bool? IsUpdateEducationInfo { get; set; }
        public bool? IsUpdateWorkInfo { get; set; }
        public bool? IsUpdateHobbiesInfo { get; set; }
    }

  
}
