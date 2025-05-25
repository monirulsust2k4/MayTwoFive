using System.Data;
using System.Threading.Channels;
using Azure.Core;
using MatchingAPI.Data;
using MatchingAPI.Data.Entity;
using MatchingAPI.Data.Entity.iBOSDDD;
using MatchingAPI.DTO;
using MatchingAPI.Helper;
using MatchingAPI.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static MatchingAPI.DTO.CommonDTO;
using static MatchingAPI.Models.ExceptionMessage;

namespace MatchingAPI.Services
{
    public class ProfileInfo : IProfileInfo
    {

        private readonly PeopleDeskContext _dbContext;
        public ProfileInfo(PeopleDeskContext dbContext)
        {
            _dbContext = dbContext;
        }


     

        public async Task<CustomizeHelper> CreateUserProfileInfo(UserProfileDTO head)
        {
            CustomizeHelper msg = new CustomizeHelper();

            if (head == null)
            {
                msg.Message = "Invalid input data";
                msg.statuscode = 400;
                return msg;
            }

            string vPartnerCode = "";
            long MasterDataCodingID = 0;

            var existingProfile = await _dbContext.TblUserProfileSummeries
                .Where(x => x.StrName.Replace(" ", "").ToLower() == head.StrName.Replace(" ", "").ToLower()
                         && x.IntUnitId == head.IntUnitId
                         && x.IsActive == true)
                .FirstOrDefaultAsync();

            if (existingProfile != null)
            {
                msg.Message = "Business partner already exists.";
                msg.statuscode = 400;
                return msg;
            }

            var masterDataCoding = await _dbContext.TblMasterDataForCodes
                .Where(x => x.IntAccountId == 1 && x.IntMasterDataTypeId == 2 && x.IntSubTypeId == 2 && x.IsActive == true)
                .FirstOrDefaultAsync();

            if (masterDataCoding == null)
            {
                var newMasterDataCoding = new TblMasterDataForCode()
                {
                    IntAccountId = 1,
                    IntMasterDataTypeId = 2,
                    StrMasterDataTypeName = "Partner",
                    IntSubTypeId = 2,
                    StrSubTypeName = await _dbContext.TblCustomerTypes
                                        .Where(x => x.IntBusinessPartnerTypeId == 2)
                                        .Select(x => x.StrBusinessPartnerTypeName)
                                        .FirstOrDefaultAsync(),
                    StrTypePrefix = "2",
                    IntCounter = 1,
                    IsActive = true
                };

                await _dbContext.TblMasterDataForCodes.AddAsync(newMasterDataCoding);
                await _dbContext.SaveChangesAsync();

                MasterDataCodingID = newMasterDataCoding.IntId;
                vPartnerCode = $"{newMasterDataCoding.IntMasterDataTypeId}{newMasterDataCoding.IntSubTypeId}{newMasterDataCoding.StrTypePrefix}{newMasterDataCoding.IntAccountId}1";
            }
            else
            {
                MasterDataCodingID = masterDataCoding.IntId;
                vPartnerCode = $"{masterDataCoding.IntMasterDataTypeId}{masterDataCoding.IntSubTypeId}{masterDataCoding.StrTypePrefix}{masterDataCoding.IntAccountId}{masterDataCoding.IntCounter}";
            }

            try
            {
                var headerData = new TblUserProfileSummery
                {
                    StrName = head.StrName,
                    StrCode = vPartnerCode,
                    StrPresentAddress = head.StrPresentAddress,
                    StrPermanentAddress = head.StrPermanentAddress,
                    IntReligionId = head.IntReligionID,
                    StrEmail = head.StrEmail,
                    StrMobileNumber = head.StrMobileNumber,
                    IntCommunityId = head.IntCommunityID,
                    IntCountryId = head.IntCountryID,
                    StrCountryName = head.StrCountryName,
                    StrProfileFor = head.StrProfileFor,
                    StrGender = head.StrGender,
                    IntDistrictId = head.IntDistrictID,
                    IntThanaId = head.IntThanaID,
                    IntResidencyStatusId = head.IntResidencyStatusID,
                    IntSubCommunityId = head.IntSubCommunityID,
                    IsPartnerCommunityPreference = head.IsPartnerCommunityPreference,
                    IntMaritalStatusId = head.IntMaritalStatusID,
                    DecHeight = (long?)head.DecHeight,
                    StrDiet = head.StrDiet,
                    IntHighestQualificationId = head.IntHighestQualificationID,
                    StrCollege = head.StrCollege,
                    StrHobbiesAndInterests = head.StrHobbiesAndInterests,
                    DecAnnualIncome = head.DecAnnualIncome,
                    IntWorkDesignationId = head.IntWorkDesignationID,
                    IntWorkIndustryId = head.IntWorkIndustryID,
                    IntMotherOccupationId = head.IntMotherOccupationID,
                    IntFatherDetailsId = head.IntFatherDetailsID,
                    IntNoOfSisters = head.IntNoOfSisters,
                    IntNoOfBrothers = head.IntNoOfBrothers,
                    IntUnitId = head.IntUnitId,
                    DteLastActionDate = DateTime.Now,
                    IsActive = true,
                    IsApprove = false,
                    DteApproveDate = DateTime.Now,
                    IntApproveBy = head.IntApproveBy,
                };

                await _dbContext.TblUserProfileSummeries.AddAsync(headerData);
                await _dbContext.SaveChangesAsync();

                //long generatedUserId = headerData.IntUserId;



                var rowlistEducation=new List<TblUserEducationInformation>();
               
                if (head.EducationRows != null && head.EducationRows.Any())
                {
                     rowlistEducation =( from edu in head.EducationRows
                                            select new TblUserEducationInformation
                                            
                                            {
                        
                                                IntUserId = headerData.IntUserId, 
                                                StrQualification = edu.Qualification,
                                                StrInstitute= edu.Institute,
                                                PassingYear= edu.Sesson,
                                                DteInsertDate=DateTime.Now,

                                                IsActive = true
                                            }).ToList();

                    await _dbContext.TblUserEducationInformations.AddRangeAsync(rowlistEducation);
                    await _dbContext.SaveChangesAsync();
                }


                var rowWorkInfo = new List<TblUserWorkInformation>();

                if (head.WorkInfoRows != null && head.WorkInfoRows.Any())
                {
                    rowWorkInfo= (from w in head.WorkInfoRows
                                  select new TblUserWorkInformation
                                  {
                                      IntUserId= headerData.IntUserId,
                                      StrCompanyName= w.CompanyName,
                                      StrDesignation=w.DesignationName,
                                      IntDesignationId= w.DesignationId,
                                      IntIndustryId= w.IndustryId,
                                      StrIndustry=w.IndustryName,
                                      StrCurrencyCode= w.CurrencyCode,
                                      DteFromDate= w.FromDate,
                                      DteToDate= w.ToDate,
                                      IsWorkFromHome=w.IsWork,
                                      IsActive=true


                                  }).ToList();
                    await _dbContext.TblUserWorkInformations.AddRangeAsync(rowWorkInfo);
                    await _dbContext.SaveChangesAsync();

                }






                var rowList1 = new List<TblUserHobbiesInterest>();
                if (head.ServiceRows != null && head.ServiceRows.Any())
                {
                    rowList1 = (from r in head.ServiceRows
                                select new TblUserHobbiesInterest
                                {
                                    StrHobbyName = r.HobbiesName,
                                    StrSection = r.Section,
                                    DteLastActionDate = DateTime.Now,
                                    IsActive = true,
                                    IntUserId = headerData.IntUserId

                                }).ToList();
                    await _dbContext.TblUserHobbiesInterests.AddRangeAsync(rowList1);
                    await _dbContext.SaveChangesAsync();

                }


                // Update Master Data Counter
                var partnerConf = await _dbContext.TblMasterDataForCodes.FirstOrDefaultAsync(x => x.IntId == MasterDataCodingID);
                if (partnerConf != null)
                {
                    partnerConf.IntCounter += 1;
                    _dbContext.TblMasterDataForCodes.Update(partnerConf);
                    await _dbContext.SaveChangesAsync();
                }






                msg.Message = "Data inserted successfully.";
                msg.statuscode = 200;
            }
            catch (Exception ex)
            {
                msg.Message = $"Error: {ex.Message}";
                msg.statuscode = 500;
            }

            return msg;
        }


        
        public async  Task<CustomizeHelper> EditUserProfileInfo( UserProfileSummeryDTO editinfo)
        {
            try
            {
                CustomizeHelper msg = new CustomizeHelper();

                if (editinfo == null)
                {
                    throw new Exception("Edit info can not be blank");
                }

                var result = _dbContext.TblUserProfileSummeries.Where(x =>
                                  //x.StrName == editinfo.StrName &&
                                  x.IntUnitId == editinfo.IntUnitId
                                 // && x.IntBusinessPartnerTypeId == objEdit.BusinessPartnerTypeId
                                 && x.IsActive == true && x.IntUserId == editinfo.UserID).FirstOrDefault();

                if (result == null)
                {
                    throw new Exception("User Info not found");
                }

                List<TblUserEducationInformation> UpdateListEducation = new List<TblUserEducationInformation>();


                TblUserProfileSummery existingUser = _dbContext.TblUserProfileSummeries.First(x => x.IntUserId == editinfo.UserID);

                // Update User Main Details
                existingUser.StrName = editinfo.StrName;
                // existingUser.DteDateOfBirth = editinfo.DteDateOfBirth;
                existingUser.StrPresentAddress = editinfo.StrPresentAddress;
                existingUser.StrPermanentAddress = editinfo.StrPermanentAddress;
                existingUser.IntReligionId = editinfo.IntReligionID;
                existingUser.StrEmail = editinfo.StrEmail;
                existingUser.StrMobileNumber = editinfo.StrMobileNumber;
                existingUser.IntCommunityId = editinfo.IntCommunityID;
                existingUser.IntCountryId = editinfo.IntCountryID;
                existingUser.StrCountryName = editinfo.StrCountryName;
                existingUser.StrProfileFor = editinfo.StrProfileFor;
                existingUser.StrGender = editinfo.StrGender;
                existingUser.IntDistrictId = editinfo.IntDistrictID;
                existingUser.IntThanaId = editinfo.IntThanaID;
                existingUser.IntResidencyStatusId = editinfo.IntResidencyStatusID;
                existingUser.IntSubCommunityId = editinfo.IntSubCommunityID;
                existingUser.IsPartnerCommunityPreference = editinfo.IsPartnerCommunityPreference;
                existingUser.IntMaritalStatusId = editinfo.IntMaritalStatusID;
                //existingUser.DecHeight = editinfo.DecHeight;
                existingUser.StrDiet = editinfo.StrDiet;
                existingUser.IntHighestQualificationId = editinfo.IntHighestQualificationID;
                existingUser.StrCollege = editinfo.StrCollege;
                existingUser.StrHobbiesAndInterests = editinfo.StrHobbiesAndInterests;
                existingUser.DecAnnualIncome = editinfo.DecAnnualIncome;
                existingUser.IntWorkDesignationId = editinfo.IntWorkDesignationID;
                existingUser.IntWorkIndustryId = editinfo.IntWorkIndustryID;
                existingUser.IntMotherOccupationId = editinfo.IntMotherOccupationID;
                existingUser.IntFatherDetailsId = editinfo.IntFatherDetailsID;
                existingUser.IntNoOfSisters = editinfo.IntNoOfSisters;
                existingUser.IntNoOfBrothers = editinfo.IntNoOfBrothers;
             
                existingUser.DteLastActionDate = editinfo.DteLastActionDate;
               
                _dbContext.TblUserProfileSummeries.Update(existingUser);
                _dbContext.SaveChangesAsync();


                    msg.Message = "Data inserted successfully.";
                    msg.statuscode = 200;


                return msg;
            }

            catch (Exception ex) {
                throw ex;
            }
           

        }

        public async Task<CustomizeHelper> EditUserProfileEducationInfo(List<CreateUserEducationRowDTO> editEducationinfo)
        {
            try
            {
                CustomizeHelper msg = new CustomizeHelper();

                if (editEducationinfo == null)
                {
                    throw new Exception("Edit info can not be blank"); 
                }


                List<TblUserEducationInformation> UpdateListEducation = new List<TblUserEducationInformation>();

                foreach (var item in editEducationinfo)
                {

                    if (item.UserProfessionDetId > 0)
                    {
                       var updateData = await _dbContext.TblUserEducationInformations
                                    .Where(x=>x.IsActive == true && x.IntUserId == item.UserId).FirstOrDefaultAsync();


                        if (updateData == null)
                            throw new Exception("Data Not Found");

                        updateData.StrInstitute=item.Institute;
                        updateData.IntUserId = item.UserId;
                        updateData.StrQualification = item.Qualification;
                        updateData.DteInsertDate = DateTime.Now;

                        UpdateListEducation.Add(updateData);
                    }

                    

                }
                if (UpdateListEducation.Count>0) {
                    _dbContext.TblUserEducationInformations.UpdateRange(UpdateListEducation);
                    _dbContext.SaveChangesAsync();

                }



                msg.Message = "Data Updated successfully.";
                msg.statuscode = 200;


                return msg;
            }

            catch (Exception ex)
            {
                throw ex;
            }


        }


        public async Task<CustomizeHelper> EditUserProfileWorkInfo(List<CreateUserWorkInfoRowDTO> editWorkinfo)
        {
            try
            {
                CustomizeHelper msg = new CustomizeHelper();

                if (editWorkinfo == null)
                {
                    throw new Exception("Edit info can not be blank");
                }


                List<TblUserWorkInformation> UpdateListWorkList = new List<TblUserWorkInformation>();

                foreach (var item in editWorkinfo)
                {

                    if (item.UserId > 0)
                    {
                        var updateData = await _dbContext.TblUserWorkInformations
                                     .Where(x => x.IsActive == true && x.IntUserId == item.UserId).FirstOrDefaultAsync();


                        if (updateData == null)
                            throw new Exception("Data Not Found");

                        updateData.StrDesignation = item.DesignationName;
                        updateData.StrCompanyName = item.CompanyName;
                        updateData.StrIndustry = item.IndustryName;
                        updateData.IntDesignationId = item.DesignationId;
                        updateData.IntIndustryId = item.IndustryId;
                        updateData.DecIncome=item.Income;
                        UpdateListWorkList.Add(updateData);

                    }



                }
                if (UpdateListWorkList.Count > 0)
                {
                    _dbContext.TblUserWorkInformations.UpdateRange(UpdateListWorkList);
                    _dbContext.SaveChangesAsync();

                }



                msg.Message = "Data Updated successfully.";
                msg.statuscode = 200;


                return msg;
            }

            catch (Exception ex)
            {
                throw ex;
            }


        }

        public async Task<CustomizeHelper> EditUserHobbiesNInterestInfo(List<CreateUserRowDTO> editHobbiesinfo)
        {
            try
            {
                CustomizeHelper msg = new CustomizeHelper();

                if (editHobbiesinfo == null)
                {
                    throw new Exception("Edit info can not be blank");
                }


                List<TblUserHobbiesInterest> UpdateHobbiesList = new List<TblUserHobbiesInterest>();

                foreach (var item in editHobbiesinfo)
                {

                    if (item.UserId > 0)
                    {
                        var updateData = await _dbContext.TblUserHobbiesInterests
                                     .Where(x => x.IsActive == true && x.IntUserId == item.UserId).FirstOrDefaultAsync();


                        if (updateData == null)
                            throw new Exception("Data Not Found");

                        updateData.StrHobbyName = item.HobbiesName;
                        updateData.StrSection = item.Section;
                        updateData.IsActive = item.Active;
                        updateData.DteLastActionDate =DateTime.Now;

                        UpdateHobbiesList.Add(updateData);

                    }



                }
                if (UpdateHobbiesList.Count > 0)
                {
                    _dbContext.TblUserHobbiesInterests.UpdateRange(UpdateHobbiesList);
                    _dbContext.SaveChangesAsync();

                }



                msg.Message = "Data Updated successfully.";
                msg.statuscode = 200;


                return msg;
            }

            catch (Exception ex)
            {
                throw ex;
            }


        }







        private IActionResult NotFound(string v)
        {
            throw new NotImplementedException();
        }

        private IActionResult BadRequest(string v)
        {
            throw new NotImplementedException();
        }

        public async Task<List<TblSubscriptionPlan>> GetSubcriptionPlanList()
        {
            var result = await _dbContext.TblSubscriptionPlans
                            .Where(x => x.IsActive == true)

                            .ToListAsync();
            return result;
        }

     
        public async Task<List<GetCommonDTODDL>> GetDivisionDDL(long CountryID)
        {
            var data = await Task.FromResult((from dv in _dbContext.TblDivisions
                                             where dv.IsActive == true
                                             && dv.IntCountryId == CountryID
                                             select new GetCommonDTODDL
                                             {
                                                 Value = dv.IntDivisionId,
                                                 Label=dv.StrDivision

                                             }).ToList());

            if (data == null) {
                throw new Exception("Division name not found");
            }
            return data;
        }

        public async Task<List<GetCommonDTODDL>> GetDistrictDDL(long DivisionID)
        {
            var data = await Task.FromResult((from dis in _dbContext.TblDistricts
                                              where dis.IsActive == true
                                              && dis.IntDivisionId == DivisionID
                                              select new GetCommonDTODDL
                                              {
                                                  Value = dis.IntDistrictId,
                                                  Label = dis.StrDistrictName
                                              }

                                             ).ToList());

            if (data == null)
            {
                throw new Exception("District name are not found");
            }
            return data;
        }


        public async Task<List<GetCommonDTODDL>> GetThanaDDL(long DistrictId)
        {
            var data =await Task.FromResult((from th  in _dbContext.TblThanas
                                            where th.IsActive == true
                                            && th.IntDistrictId == DistrictId

                                            select new GetCommonDTODDL
                                            {

                                                Value = th.IntThanaId,  
                                                Label = th.StrThanaName
                                            }).ToList());

            if (data == null) {
                throw new Exception("Thana name not found");
                    
                              }

            return data;


        }

        public async Task<List<GetCommonDTODDL>> GetRegionDDL()
        {
            var data = await Task.FromResult((from rg in _dbContext.TblReligions
                                              where rg.IsActive == true
                                              select new GetCommonDTODDL
                                              {
                                                  Value = rg.IntReligionId,
                                                  Label = rg.StrReligionName
                                              }).ToList());
            if (data == null) {
            throw new Exception("Region name not found");
            }
            return data;

        }

        public async Task<List<GetCommonDTODDL>> GetCommunityDDL()
        {
            var data= await Task.FromResult((from com in _dbContext.TblDdlcommunities
                                            where com.IsActive == true
                                            select new GetCommonDTODDL
                                            {
                                                Value=com.IntCommunityId,
                                                Label = com.StrCommunityName
                                            }).ToList());
            if (data == null) {
                throw new Exception("No data found");
            }
            return data;

        }

        public async Task<List<GetCommonDTODDL>> GetCountryDDL()
        {

            var data = await Task.FromResult((from cnt in _dbContext.TblDdlcountryLists
                                             where cnt.IsActive == true
                                             select new GetCommonDTODDL
                                             {
                                                 Value = cnt.IntCountryId,
                                                 Label = cnt.StrCountryName
                                             }).ToList());

            if (data == null) {
                throw new Exception("No data found");
            }
            return data;
        }

        public async Task<List<GetCommonDTODDL>> GetDietPreferenceDDL()
        {
            var data=await Task.FromResult((from dp in _dbContext.TblDdldietPreferences
                                           where dp.IsActive == true
                                           select new GetCommonDTODDL
                                           {
                                               Value=dp.IntDietId,
                                               Label=dp.StrDietType
                                           }
                                           ).ToList());
            if (data == null) {
                throw new Exception("No data found");
                    }
            return data;
        }

        public async Task<List<GetCommonDTODDL>> GetHightestQualification ()
        {
            var data= await Task.FromResult((from hq in _dbContext.TblDdlhighestQualifications
                                            where hq.IsActive == true
                                            select new GetCommonDTODDL
                                            {
                                                Value=hq.IntQualificationId,
                                                Label=hq.StrQualificationName
                                            }).ToList());
            if (data == null) { throw new Exception("No data found"); }
            return data;


        }


        public async Task<List<GetCommonDTODDL>> GetHobbiesNInterest(string CategoryName)
        {
            var data = await Task.FromResult((from hq in _dbContext.TblDdlhobbiesInterests
                                              where hq.IsActive == true
                                              && hq.StrCategory==CategoryName
                                              select new GetCommonDTODDL
                                              {
                                                  Value = hq.IntHobbyId,
                                                  Label = hq.StrHobbyName
                                              }).ToList());
            if (data == null) { throw new Exception("No data found"); }
            return data;


        }

        public async Task<List<GetCommonDTODDL>> GetMaritalStatus()
        {
            var data = await Task.FromResult((from hq in _dbContext.TblDdlmaritalStatuses
                                              where hq.IsActive == true
                                          
                                              select new GetCommonDTODDL
                                              {
                                                  Value = hq.IntMaritalStatusId,
                                                  Label = hq.StrStatusName
                                              }).ToList());
            if (data == null) { throw new Exception("No data found"); }
            return data;


        }

        public async Task<List<GetCommonDTODDL>> GetParentOccupation( string strParentType)
        {
            var data = await Task.FromResult((from hq in _dbContext.TblDdlparentOccupations
                                              where hq.IsActive == true
                                              && hq.StrParentType==strParentType

                                              select new GetCommonDTODDL
                                              {
                                                  Value = hq.IntOccupationId,
                                                  Label = hq.StrOccupationName
                                              }).ToList());
            if (data == null) { throw new Exception("No data found"); }
            return data;


        }


        public async Task<List<GetCommonDTODDL>> GetResidencyStatus()
        {
            var data = await Task.FromResult((from hq in _dbContext.TblDdlresidencyStatuses
                                              where hq.IsActive == true
                                             
                                              select new GetCommonDTODDL
                                              {
                                                  Value = hq.IntResidencyId,
                                                  Label = hq.StrResidencyType
                                              }).ToList());
            if (data == null) { throw new Exception("No data found"); }
            return data;


        }

        public async Task<List<GetCommonDTODDL>> GetSubCommunity(long ReligiousID)
        {
            var data = await Task.FromResult((from hq in _dbContext.TblDdlsubCommunities
                                              where hq.IsActive == true
                                              && hq.IntReligionId == ReligiousID

                                              select new GetCommonDTODDL
                                              {
                                                  Value = hq.IntCommunityId,
                                                  Label = hq.StrSubCommunityName
                                              }).ToList());
            if (data == null) { throw new Exception("No data found"); }
            return data;


        }


        public async Task<List<GetCommonDTODDL>> GetWorkDesignation()
        {
            var data = await Task.FromResult((from hq in _dbContext.TblDdlworkDesignations
                                              where hq.IsActive == true
                                          

                                              select new GetCommonDTODDL
                                              {
                                                  Value = hq.IntDesignationId,
                                                  Label = hq.StrDesignationName
                                              }).ToList());
            if (data == null) { throw new Exception("No data found"); }
            return data;


        }


        public async Task<List<GetCommonDTODDL>> GetWorkIndustry()
        {
            var data = await Task.FromResult((from hq in _dbContext.TblDdlworkIndustries
                                              where hq.IsActive == true


                                              select new GetCommonDTODDL
                                              {
                                                  Value = hq.IntWorkId,
                                                  Label = hq.StrWorkType
                                              }).ToList());
            if (data == null) { throw new Exception("No data found"); }
            return data;


        }








        public Task<List<TblSubscriptionPlan>> GetSubscriptionPlans()
        {
            throw new NotImplementedException();
        }
    }
}
