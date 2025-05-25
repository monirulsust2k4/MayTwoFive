using MatchingAPI.Data;
using MatchingAPI.Data.Entity;
using MatchingAPI.DTO;
using MatchingAPI.Helper;
using MatchingAPI.IServices;
using Microsoft.EntityFrameworkCore;

namespace MatchingAPI.Services
{
    public class Preference : IPreferenceInfo
    {

        private readonly PeopleDeskContext _dbContext;

        public Preference(PeopleDeskContext dbContext)
        {
          _dbContext = dbContext;
        }

        public async Task<CustomizeHelper> CreateUserPreferenceInfo(UserPreferenceDTO preference)
        {
            CustomizeHelper msg = new CustomizeHelper();

            if (preference == null)
            {
                msg.Message = "Invalid input data";
                msg.statuscode = 400;
                return msg;
            }

            try
            {
            
               var existingPreference = await _dbContext.TblUserPreferenceSummeries
                   .Where(x => x.IntUnitId==preference.UnitId && x.IsActive==true && x.IntUserId==preference.UserId)
                   .FirstOrDefaultAsync();

                if (existingPreference != null)
                {
                    msg.Message = "User preference already exists.";
                    msg.statuscode = 400;
                    return msg;
                }

              
               var newPreference = new TblUserPreferenceSummery
               {
                   IntUserId = preference.UserId,   
                   IntUnitId = preference.UnitId,
                   IntAgeMin = preference.AgeMin,
                   IntAgeMax = preference.AgeMax,
                   DecHeightMin = preference.DecHeightMin,
                   DecHeightMax = preference.DecHeightMax,
                   IntMaritalStatusId = preference.MaritalStatusId,
                   IntReligionId = preference.ReligionId,
                   IsCommunitPreperence = preference.IsCommunitPreperence,
                   IntCommunityId = preference.CommunityId,
                   IntSubCommunityId = preference.SubCommunityId,
                   IntCountryId = preference.CountryId,
                   IntDistrictId = preference.DistrictId,
                   IntThanaId = preference.ThanaId,
                   IntResidencyStatusId = preference.ResidencyStatusId,
                   IntHighestQualificationId = preference.HighestQualificationId,
                   IntWorkDesignationId = preference.WorkDesignationId,
                   IntWorkIndustryId = preference.WorkIndustryId,
                   DecAnnualIncomeMin = preference.DecAnnualIncomeMin,
                   DecAnnualIncomeMax = preference.DecAnnualIncomeMax,
                   StrDiet = preference.StrDiet,
                   StrHobbiesAndInterests = preference.StrHobbiesAndInterests,
                   IntMotherOccupationId = preference.MotherOccupationId,
                   IntFatherOccupationId = preference.FatherOccupationId,
                   IntNoOfSisters = preference.NoOfSisters,
                   IntNoOfBrothers = preference.NoOfBrothers,
                   IsActive = preference.IsActive,
                   DteCreatedDate = DateTime.Now,
                   DteUpdatedDate = DateTime.Now,
                   StrGender = preference.StrGender,
               };

                await _dbContext.TblUserPreferenceSummeries.AddAsync(newPreference);
                await _dbContext.SaveChangesAsync();
                long generatedReferenceID = newPreference.IntUsererenceId;


                var communityList = new List<TblUserPreferredCommunity>();

                if (preference.CommunityROW != null && preference.CommunityROW.Any())
                {
                     communityList = (from community in preference.CommunityROW
                                         select new TblUserPreferredCommunity
                                         {
                                             IntUserPreferenceId = generatedReferenceID,
                                             IntCommunityId = community.IntCommunityId,
                                             IsActive = true,
                                             DteLastActionDateTime = DateTime.Now
                                         }).ToList();

                    await _dbContext.TblUserPreferredCommunities.AddRangeAsync(communityList);
                    await _dbContext.SaveChangesAsync();
                }



                var countryList = new List<TblUserPreferredCountry>();
                var dietList = new List<TblUserPreferredDiet>();
                var hobbyList = new List<TblUserPreferredHobby>();
                var maritalStatusList = new List<TblUserPreferredMaritalStatus>();
                var parentoccupationList = new List<TblUserPreferredParentOccupation>();
                var qualificationList = new List<TblUserPreferredQualification>();
                var residencyList = new List<TblUserPreferredResidencyStatus>();
                var subCommunityList=new List<TblUserPreferredSubCommunity>();
                var workdesgnatilList = new List<TblUserPreferredWorkDesignation>();
                var workIndustryList=new List<TblUserPreferredWorkIndustry>();
                    
                if (preference.CountryROW != null && preference.CountryROW.Any())
                {
                    countryList = (from country in preference.CountryROW
                                   select new TblUserPreferredCountry
                                   {
                                       IntUserPreferenceId = generatedReferenceID,
                                       IntCountryId = country.IntCountryId,
                                       IsActive = true,
                                       DteLastActionDateTime = DateTime.Now
                                   }).ToList();
                }

                if (preference.DietROW != null && preference.DietROW.Any())
                {
                    dietList = (from diet in preference.DietROW
                                select new TblUserPreferredDiet
                                {
                                    IntUserPreferenceId = generatedReferenceID,
                                    IntDietId = diet.IntDietId,
                                    IsActive = true,
                                    DteLastActionDateTime = DateTime.Now
                                }).ToList();
                }

                if (preference.HobbyROW != null && preference.HobbyROW.Any())
                {
                    hobbyList = (from hobby in preference.HobbyROW
                                 select new TblUserPreferredHobby
                                 {
                                     IntUserPreferenceId = generatedReferenceID,
                                     IntHobbyId = hobby.IntHobbyId,
                                     IsActive = true,
                                     DteLastActionDateTime = DateTime.Now
                                 }).ToList();
                }

                if (preference.MaritalStatusROW != null && preference.MaritalStatusROW.Any())
                {
                    maritalStatusList = (from status in preference.MaritalStatusROW
                                         select new TblUserPreferredMaritalStatus
                                         {
                                             IntUserPreferenceId = generatedReferenceID,
                                             IntMaritalStatusId = status.IntMaritalStatusId,
                                             IsActive = true,
                                             DteLastActionDateTime = DateTime.Now
                                         }).ToList();
                }


            

                if (preference.OccupationROW != null && preference.OccupationROW.Any())
                {
                    parentoccupationList = preference.OccupationROW.Select(o => new TblUserPreferredParentOccupation
                    {
                        IntUserPreferenceId = generatedReferenceID, // Ensure this exists in tblUserPreferenceSummery
                        IntOccupationId = o.IntOccupationId,
                        IsActive = true,
                        DteLastActionDateTime = DateTime.UtcNow,
                        IntFamilyMembersTypeId=o.IntFamilyMemberTypeId
                    }).ToList();
                }

                if (preference.QualificationROW != null && preference.QualificationROW.Any())
                {
                    qualificationList = preference.QualificationROW.Select(o => new TblUserPreferredQualification
                    {


                        IntUserPreferenceId = generatedReferenceID,
                        IsActive = true,
                        DteLastActionDateTime = DateTime.UtcNow,
                        IntQualificationId = o.IntQualificationId,
                    }).ToList();
                }

                if (preference.ResidencyStatusROW !=null && preference.ResidencyStatusROW.Any())
                {
                    residencyList = preference.ResidencyStatusROW.Select(o => new TblUserPreferredResidencyStatus
                    {
                        IntUserPreferenceId = generatedReferenceID,
                        IsActive = true,
                        DteLastActionDateTime = DateTime.UtcNow,
                        IntResidencyId = o.IntResidencyId,

                    }).ToList();
                }

                if(preference.SubCommunityROW !=null && preference.SubCommunityROW.Any())
                {
                    subCommunityList=preference.SubCommunityROW.Select(o=> new TblUserPreferredSubCommunity
                    {


                        IntUserPreferenceId = generatedReferenceID,
                        IsActive = true,
                        DteLastActionDateTime = DateTime.UtcNow,
                        IntSubCommunityId = o.IntSubCommunityId
                    }).ToList();
                }

                if(preference.WorkDesignationROW !=null  && preference.WorkDesignationROW.Any())
                {
                    workdesgnatilList = preference.WorkDesignationROW.Select(o => new TblUserPreferredWorkDesignation
                    {
                            
                        IntUserPreferenceId = generatedReferenceID,
                        IsActive = true,
                        DteLastActionDateTime= DateTime.UtcNow,
                        IntDesignationId = o.IntDesignationId,

                    }).ToList() ;
                    
                }

                if (preference.WorkIndustryROW != null && preference.WorkIndustryROW.Any())
                {

                    workIndustryList=preference.WorkIndustryROW.Select(o => new TblUserPreferredWorkIndustry
                    {
                        IntUserPreferenceId = generatedReferenceID,
                        IsActive = true,
                        DteLastActionDateTime= DateTime.UtcNow,
                        IntWorkIndustryId = o.IntWorkIndustryId,

                    }).ToList();
                }

                // Insert all data in parallel
                if (countryList.Any()) await _dbContext.TblUserPreferredCountries.AddRangeAsync(countryList);
                if (dietList.Any()) await _dbContext.TblUserPreferredDiets.AddRangeAsync(dietList);
                if (hobbyList.Any()) await _dbContext.TblUserPreferredHobbies.AddRangeAsync(hobbyList);
                if (maritalStatusList.Any()) await _dbContext.TblUserPreferredMaritalStatuses.AddRangeAsync(maritalStatusList);
                if(qualificationList.Any()) await _dbContext.TblUserPreferredQualifications.AddRangeAsync(qualificationList);
                if (residencyList.Any()) await _dbContext.TblUserPreferredResidencyStatuses.AddRangeAsync(residencyList);
                if(subCommunityList.Any())await _dbContext.TblUserPreferredSubCommunities.AddRangeAsync(subCommunityList);  
                if(workdesgnatilList.Any()) await _dbContext.TblUserPreferredWorkDesignations.AddRangeAsync(workdesgnatilList); 
                if(workIndustryList.Any()) await _dbContext.TblUserPreferredWorkIndustries.AddRangeAsync(workIndustryList);


                await _dbContext.TblUserPreferredParentOccupations.AddRangeAsync(parentoccupationList);




                await _dbContext.SaveChangesAsync();










                msg.Message = "User preference inserted successfully.";
                msg.statuscode = 200;
            }
            catch (Exception ex)
            {
                msg.Message = $"Error: {ex.Message}";
                msg.statuscode = 500;
            }

            return msg;
        }


    }
}
