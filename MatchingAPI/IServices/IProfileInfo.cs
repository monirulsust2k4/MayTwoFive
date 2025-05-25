using MatchingAPI.Data.Entity;
using MatchingAPI.Data.Entity.iBOSDDD;
using MatchingAPI.DTO;
using MatchingAPI.Helper;
using static MatchingAPI.DTO.CommonDTO;

namespace MatchingAPI.IServices
{
    public interface IProfileInfo
    {
        //   public Task<List<GetCommonDTODDL>> GetSalesOrderTypeDDL();

        public Task<CustomizeHelper> CreateUserProfileInfo(UserProfileDTO head);
        public Task<CustomizeHelper> EditUserProfileInfo(UserProfileSummeryDTO editinfo);

        public Task<CustomizeHelper> EditUserProfileEducationInfo(List<CreateUserEducationRowDTO> editEducationinfo);
        public Task<CustomizeHelper> EditUserProfileWorkInfo(List<CreateUserWorkInfoRowDTO> editWorkinfo);
        public Task<CustomizeHelper> EditUserHobbiesNInterestInfo(List<CreateUserRowDTO> editHobbiesinfo);
        Task<List<TblSubscriptionPlan>> GetSubcriptionPlanList();
        public Task<List<GetCommonDTODDL>> GetDivisionDDL(long CountryID);
        public Task<List<GetCommonDTODDL>> GetDistrictDDL(long DivisionID);
        public Task<List<GetCommonDTODDL>> GetThanaDDL(long DistriID);

        public Task<List<GetCommonDTODDL>> GetRegionDDL();

        public Task<List<GetCommonDTODDL>> GetCommunityDDL();
        public Task<List<GetCommonDTODDL>> GetCountryDDL();

        public Task<List<GetCommonDTODDL>> GetDietPreferenceDDL();
        public Task<List<GetCommonDTODDL>> GetHightestQualification();
         public Task<List<GetCommonDTODDL>> GetHobbiesNInterest(string CategoryName);

        public Task<List<GetCommonDTODDL>> GetMaritalStatus();
        public Task<List<GetCommonDTODDL>> GetParentOccupation(string strParentType);

        public Task<List<GetCommonDTODDL>> GetResidencyStatus();

        public Task<List<GetCommonDTODDL>> GetSubCommunity(long ReligiousID);

        public Task<List<GetCommonDTODDL>> GetWorkDesignation();

        public Task<List<GetCommonDTODDL>> GetWorkIndustry();
    }
}
