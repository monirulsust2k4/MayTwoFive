using System.Data;
using MatchingAPI.Data;
using MatchingAPI.Data.Entity;
using MatchingAPI.DTO;
using MatchingAPI.IServices;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using static MatchingAPI.DTO.SucbcriptionPlanDTO;
using static MatchingAPI.Models.ExceptionMessage;
using MatchingAPI.Helper;

namespace MatchingAPI.Services
{
    public class SucbcriptionPlan: ISucbcriptionPlan
    {

        private readonly PeopleDeskContext _dbContext;
        public SucbcriptionPlan(PeopleDeskContext dbContext)
        {
            _dbContext = dbContext;
        }



        public async Task<MessageHelper> CreateUpdateSubscriptionPlan(SubscriptionPlanMainDTO objCreate)
        {
            try
            {
                var msg = new MessageHelper();

                if (objCreate.PlanId == 0)
                {
                    var details = new TblSubscriptionPlan()
                    {
                        StrPlanName = objCreate.PlanName,
                        DecPrice = objCreate.Price,
                        StrDuration = objCreate.Duration,
                        StrProfileVisibility = objCreate.ProfileVisibility,
                        IsIncreasedMatchScore = objCreate.IsIncreasedMatchScore,
                        IntNumberOfMatches = objCreate.NumberOfMatches,
                        IntMessageLimit = objCreate.MessageLimit,
                        IsAccessToPremiumProfiles = objCreate.IsAccessToPremiumProfiles,
                        IsPrioritySupport = objCreate.IsPrioritySupport,
                        IsAccessToAdvancedFilters = objCreate.IsAccessToAdvancedFilters,
                        DecDiscountPercentage = objCreate.DiscountPercentage,
                        StrAdditionalBenefits = objCreate.AdditionalBenefits,
                        IsActive = objCreate.IsActive,
                        DteLastActionDateTime = DateTime.UtcNow,
                        DteServerDateTime = DateTime.UtcNow,
                        IntActionBy = objCreate.ActionBy,
                        DteStartDate = objCreate.StartDate,
                        DteEndDate = objCreate.EndDate
                    };
                    await _dbContext.TblSubscriptionPlans.AddAsync(details);
                    await _dbContext.SaveChangesAsync();

                    msg.Message = "Created Successfully";
                    msg.StatusCode = 200;
                }
                else
                {
                    var planData = _dbContext.TblSubscriptionPlans.FirstOrDefault(c => c.IntPlanId == objCreate.PlanId);
                    if (planData == null)
                    {
                        throw new Exception("Subscription Plan Not Found");
                    }
                    else
                    {
                        planData.StrPlanName = objCreate.PlanName;
                        planData.DecPrice = objCreate.Price;
                        planData.StrDuration = objCreate.Duration;
                        planData.StrProfileVisibility = objCreate.ProfileVisibility;
                        planData.IsIncreasedMatchScore = objCreate.IsIncreasedMatchScore;
                        planData.IntNumberOfMatches = objCreate.NumberOfMatches;
                        planData.IntMessageLimit = objCreate.MessageLimit;
                        planData.IsAccessToPremiumProfiles = objCreate.IsAccessToPremiumProfiles;
                        planData.IsPrioritySupport = objCreate.IsPrioritySupport;
                        planData.IsAccessToAdvancedFilters = objCreate.IsAccessToAdvancedFilters;
                        planData.DecDiscountPercentage = objCreate.DiscountPercentage;
                        planData.StrAdditionalBenefits = objCreate.AdditionalBenefits;
                        planData.IsActive = objCreate.IsActive;
                        planData.DteLastActionDateTime = DateTime.UtcNow;
                        planData.DteServerDateTime = DateTime.UtcNow;
                        planData.IntActionBy = objCreate.ActionBy;
                        planData.DteStartDate = objCreate.StartDate;
                        planData.DteEndDate = objCreate.EndDate;

                        _dbContext.TblSubscriptionPlans.Update(planData);
                        await _dbContext.SaveChangesAsync();

                        msg.Message = "Updated Successfully";
                        msg.StatusCode = 200;
                    }
                }
                return msg;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<SubscriptionPlanMainDTO>> GetSubscriptionPlans()
        {
            try
            {
                var plans = await _dbContext.TblSubscriptionPlans
                    .Select(plan => new SubscriptionPlanMainDTO
                    {
                        PlanId = plan.IntPlanId,
                        PlanName = plan.StrPlanName,
                        Price = plan.DecPrice,
                        Duration = plan.StrDuration,
                        ProfileVisibility = plan.StrProfileVisibility,
                        IsIncreasedMatchScore = plan.IsIncreasedMatchScore,
                        NumberOfMatches = (long)plan.IntNumberOfMatches,
                        MessageLimit = (long)plan.IntMessageLimit,
                        IsAccessToPremiumProfiles = plan.IsAccessToPremiumProfiles,
                        IsPrioritySupport = plan.IsPrioritySupport,
                        IsAccessToAdvancedFilters = plan.IsAccessToAdvancedFilters,
                        DiscountPercentage = (decimal)plan.DecDiscountPercentage,
                        AdditionalBenefits = plan.StrAdditionalBenefits,
                        IsActive = (bool)plan.IsActive,
                        LastActionDateTime = plan.DteLastActionDateTime,
                        ServerDateTime = plan.DteServerDateTime,
                        ActionBy = (long)plan.IntActionBy,
                        StartDate = plan.DteStartDate,
                        EndDate = plan.DteEndDate
                    })
                    .ToListAsync();

                return plans;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<MessageHelper> CreateSubscriptionPlanInformationByUser(CreateSubscriptionPlanByUserCommonDTO createSubscriptionPlan)
        {
            try
            {
                var header = new TblSubscriptionPlanHeader
                {
                    IntUserId = createSubscriptionPlan.objHeaderDTO.UserId,
                    IntPlanId = createSubscriptionPlan.objHeaderDTO.PlanId,
                    DteStartDate = createSubscriptionPlan.objHeaderDTO.StartDate,
                    DteEndDate = createSubscriptionPlan.objHeaderDTO.EndDate,
                    IsActive = createSubscriptionPlan.objHeaderDTO.IsActive,
                    IntActionBy = createSubscriptionPlan.objHeaderDTO.ActionBy,
                    DteLastActionDateTime = DateTime.UtcNow,
                    DteServerDateTime = DateTime.UtcNow,
                    IntUnitId = createSubscriptionPlan.objHeaderDTO.UnitId,
                    IntCustomerId = createSubscriptionPlan.objHeaderDTO.CustomerId
                };

                await _dbContext.TblSubscriptionPlanHeaders.AddAsync(header);
                await _dbContext.SaveChangesAsync();

                List<TblSubscriptionPlanRow> rowList = new List<TblSubscriptionPlanRow>();

                foreach (var row in createSubscriptionPlan.objListRowDTO)
                {
                    var rowData = new TblSubscriptionPlanRow
                    {
                        IntMembershipId = header.IntMembershipId,
                        IntUserId = row.UserId,
                        IntCurrentPlan = row.CurrentPlanId,
                        StrCurrentPlan = row.CurrentPlan,
                        IntRequestedPlan = row.RequestedPlanId,
                        StrRequestedPlan = row.RequestedPlan,
                        DteChangeRequestDate = DateTime.UtcNow,
                        DteChangeProcessedDate = row.ChangeProcessedDate,
                        StrChangeStatus = row.ChangeStatus,
                        StrReasonForChange = row.ReasonForChange,
                        StrAdminNotes = row.AdminNotes,
                        StrPaymentStatus = row.PaymentStatus,
                        IsChangeCompleted = row.IsChangeCompleted,
                        DteCreatedAt = DateTime.UtcNow,
                        DteUpdatedAt = DateTime.UtcNow
                    };

                    rowList.Add(rowData);
                }

                await _dbContext.TblSubscriptionPlanRows.AddRangeAsync(rowList);
                await _dbContext.SaveChangesAsync();

                return new MessageHelper { Message = "Subscription Plan Created Successfully", StatusCode = 200 };
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<MessageHelper> EditSubscriptionPlanByUser(EditSubscriptionPlanByUserCommonDTO editSubscriptionPlan)
        {
            try
            {
                // Retrieve the existing header record
                var headerData = _dbContext.TblSubscriptionPlanHeaders
                    .FirstOrDefault(x => x.IntMembershipId == editSubscriptionPlan.objHeaderDTO.MembershipId);

                if (headerData == null)
                {
                    return new MessageHelper { Message = "Membership not found", StatusCode = 404 };
                }

                // Update header table fields
                headerData.IntUserId = editSubscriptionPlan.objHeaderDTO.UserId;
                headerData.IntPlanId = editSubscriptionPlan.objHeaderDTO.PlanId;
                headerData.DteStartDate = editSubscriptionPlan.objHeaderDTO.StartDate;
                headerData.DteEndDate = editSubscriptionPlan.objHeaderDTO.EndDate;
                headerData.IsActive = editSubscriptionPlan.objHeaderDTO.IsActive;
                headerData.IntActionBy = editSubscriptionPlan.objHeaderDTO.ActionBy;
                headerData.DteLastActionDateTime = DateTime.UtcNow;
                headerData.DteServerDateTime = DateTime.UtcNow;
                headerData.IntUnitId = editSubscriptionPlan.objHeaderDTO.UnitId;
                headerData.IntCustomerId = editSubscriptionPlan.objHeaderDTO.CustomerId;

                _dbContext.TblSubscriptionPlanHeaders.Update(headerData);
                await _dbContext.SaveChangesAsync();

                // Retrieve and remove existing rows related to this membership
                var existingRows = _dbContext.TblSubscriptionPlanRows
                    .Where(x => x.IntMembershipId == headerData.IntMembershipId)
                    .ToList();

                _dbContext.TblSubscriptionPlanRows.RemoveRange(existingRows);
                await _dbContext.SaveChangesAsync();

                // Insert new row data
                List<TblSubscriptionPlanRow> newRowList = new List<TblSubscriptionPlanRow>();

                foreach (var rowDTO in editSubscriptionPlan.objListRowDTO)
                {
                    var newRow = new TblSubscriptionPlanRow
                    {
                        IntMembershipId = headerData.IntMembershipId,
                        IntUserId = headerData.IntUserId,
                        IntCurrentPlan = rowDTO.CurrentPlanId,
                        StrCurrentPlan = rowDTO.CurrentPlan,
                        IntRequestedPlan = rowDTO.RequestedPlanId,
                        StrRequestedPlan = rowDTO.RequestedPlan,
                        DteChangeRequestDate = rowDTO.ChangeRequestDate,
                        DteChangeProcessedDate = rowDTO.ChangeProcessedDate,
                        StrChangeStatus = rowDTO.ChangeStatus,
                        StrReasonForChange = rowDTO.ReasonForChange,
                        StrAdminNotes = rowDTO.AdminNotes,
                        StrPaymentStatus = rowDTO.PaymentStatus,
                        IsChangeCompleted = rowDTO.IsChangeCompleted,
                        DteCreatedAt = DateTime.UtcNow,
                        DteUpdatedAt = DateTime.UtcNow
                    };

                    newRowList.Add(newRow);
                }

                _dbContext.TblSubscriptionPlanRows.AddRange(newRowList);
                await _dbContext.SaveChangesAsync();

                //// Log the activity
                //string serializedPayload = JsonConvert.SerializeObject(editSubscriptionPlan);
                //var payload = new EventActivityLogDTO
                //{
                //    ActionBy = editSubscriptionPlan.objHeaderDTO.actionBy,
                //    BusinessUnitId = headerData.intUnitId,
                //    ActivityId = 5,  // Assuming a specific ActivityId for subscription update
                //    ActivityName = "Subscription Management",
                //    EventId = (long)ActivityEventType.Edit,
                //    EventName = "Edit Subscription",
                //    ReferenceId = headerData.intMembershipId,
                //    ReferenceCode = headerData.intMembershipId.ToString(),
                //    Payload = serializedPayload,
                //    FeatureName = "Subscription Plan",
                //    CaseId = headerData.intMembershipId,
                //    CaseName = headerData.intMembershipId.ToString(),
                //};

                //await PayloadHelper.CreateEventActivityLog(payload, _contextW);

                return new MessageHelper { Message = "Subscription updated successfully", StatusCode = 200 };
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<GetSubscriptionDetailsDTO>> GetRunningSusscriptionInfoForUser(long userid, long unitid, long customerid)
        {
            var data = await Task.FromResult((from plan in _dbContext.TblSubscriptionPlans
                                              join header in _dbContext.TblSubscriptionPlanHeaders on plan.IntPlanId equals header.IntPlanId
                                              where header.IntUnitId == unitid && header.IntUserId == userid && plan.IsActive == true
                                              select new GetSubscriptionDetailsDTO()
                                              {
                                                  MembershipId = header.IntMembershipId,
                                                  UserId = header.IntUserId,
                                                  PlanId = header.IntPlanId,
                                                  SubscriptionStartDate = header.DteStartDate,
                                                  SubscriptionEndDate = header.DteEndDate,
                                                  SubscriptionIsActive = (bool)header.IsActive,
                                                  SubscriptionActionBy = (long)header.IntActionBy,
                                                  SubscriptionLastActionDateTime = (DateTime)header.DteLastActionDateTime,
                                                  SubscriptionServerDateTime = (DateTime)header.DteServerDateTime,
                                                  UnitId = (long)header.IntUnitId,
                                                  CustomerId = (long)header.IntCustomerId,

                                                  PlanName = plan.StrPlanName,
                                                  Price = plan.DecPrice,
                                                  Duration = plan.StrDuration,
                                                  ProfileVisibility = plan.StrProfileVisibility,
                                                  IsIncreasedMatchScore = plan.IsIncreasedMatchScore,
                                                  NumberOfMatches = (long)plan.IntNumberOfMatches,
                                                  MessageLimit = (long)plan.IntMessageLimit,
                                                  IsAccessToPremiumProfiles = plan.IsAccessToPremiumProfiles,
                                                  IsPrioritySupport = plan.IsPrioritySupport,
                                                  IsAccessToAdvancedFilters = plan.IsAccessToAdvancedFilters,
                                                  DiscountPercentage = (decimal)plan.DecDiscountPercentage,
                                                  AdditionalBenefits = plan.StrAdditionalBenefits,
                                                  PlanIsActive = (bool)plan.IsActive,
                                                  PlanLastActionDateTime = (DateTime)plan.DteLastActionDateTime,
                                                  PlanServerDateTime = (DateTime)plan.DteServerDateTime,
                                                  PlanActionBy = (long)plan.IntActionBy,
                                                  PlanStartDate = (DateTime)plan.DteStartDate,
                                                  PlanEndDate = (DateTime)plan.DteEndDate

                                              }).ToList());
            if (data == null)
                throw new Exception(" Sales Organization Not Found.");

            return data;
        }

        public async Task<DataTable> GetUserProfileInfo(int intPartid, int intLoginUserId, string strWantsForGender, int intCustomerId, int intUnitId, DateTime dteFromDate, DateTime dteToDate)
        {

            DataTable dt = new DataTable();

            try
            {

                using (var connection = new SqlConnection(Connection.PeopleDeskARLConnection))
                {
                    string sql = "mar.sprUserProfileInformation";
                    using (SqlCommand cmd = new SqlCommand(sql, connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@intPartid", intPartid);
                        cmd.Parameters.AddWithValue("@intLoginUserId", intLoginUserId);
                        cmd.Parameters.AddWithValue("@strWantsForGender", strWantsForGender);
                        cmd.Parameters.AddWithValue("@intCustomerId", intCustomerId);
                        cmd.Parameters.AddWithValue("@intUnitId", intUnitId);
                        cmd.Parameters.AddWithValue("@dteFromDate", dteFromDate);
                        cmd.Parameters.AddWithValue("@dteToDate", dteToDate);

                        connection.Open();
                        using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(cmd))
                        {
                            sqlAdapter.Fill(dt);
                        }
                        connection.Close();
                    }
                }
                return (dt);
            }
            catch (Exception)
            {

                throw;
            }

        }


    }
}
