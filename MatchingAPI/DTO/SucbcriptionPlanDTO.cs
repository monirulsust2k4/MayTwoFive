namespace MatchingAPI.DTO
{
    public class SucbcriptionPlanDTO
    {


        public class SubscriptionPlanMainDTO
        {
            public long PlanId { get; set; }
            public string PlanName { get; set; }
            public decimal Price { get; set; }
            public string Duration { get; set; }
            public string ProfileVisibility { get; set; }
            public bool IsIncreasedMatchScore { get; set; }
            public long NumberOfMatches { get; set; }
            public long MessageLimit { get; set; }
            public bool IsAccessToPremiumProfiles { get; set; }
            public bool IsPrioritySupport { get; set; }
            public bool IsAccessToAdvancedFilters { get; set; }
            public decimal DiscountPercentage { get; set; }
            public string AdditionalBenefits { get; set; }
            public bool IsActive { get; set; }
            public DateTime? LastActionDateTime { get; set; }
            public DateTime? ServerDateTime { get; set; }
            public long ActionBy { get; set; }
            public DateTime? StartDate { get; set; }
            public DateTime? EndDate { get; set; }
        }


        public class SubscriptionPlanChangeRequestHeaderDTO
        {
            public long ChangeRequestId { get; set; }
            public long MembershipId { get; set; }
            public long UserId { get; set; }
            public long CurrentPlan { get; set; }
            public string CurrentPlanName { get; set; }
            public long RequestedPlan { get; set; }
            public string RequestedPlanName { get; set; }
            public DateTime? ChangeRequestDate { get; set; }
            public DateTime? ChangeProcessedDate { get; set; }
            public string ChangeStatus { get; set; }
            public string ReasonForChange { get; set; }
            public string AdminNotes { get; set; }
            public string PaymentStatus { get; set; }
            public bool IsChangeCompleted { get; set; }
            public DateTime CreatedAt { get; set; }
            public DateTime UpdatedAt { get; set; }
        }

        public class SubscriptionPlanChangeRequestDTO
        {
            public long ChangeRequestId { get; set; }
            public long MembershipId { get; set; }
            public long UserId { get; set; }
            public long CurrentPlanId { get; set; }
            public string CurrentPlanName { get; set; }
            public long RequestedPlanId { get; set; }
            public string RequestedPlanName { get; set; }
            public DateTime? ChangeRequestDate { get; set; }
            public DateTime? ChangeProcessedDate { get; set; }
            public string ChangeStatus { get; set; }
            public string ReasonForChange { get; set; }
            public string AdminNotes { get; set; }
            public string PaymentStatus { get; set; }
            public bool IsChangeCompleted { get; set; }
            public DateTime CreatedAt { get; set; }
            public DateTime UpdatedAt { get; set; }
        }

        public class CreateSubscriptionPlanByUserCommonDTO
        {
            public CreateSubscriptionPlanByUserHeaderDTO objHeaderDTO { get; set; }
            public List<CreateSubscriptionPlanByUserRowDTO> objListRowDTO { get; set; }
        }

        public class CreateSubscriptionPlanByUserHeaderDTO
        {
            public long MembershipId { get; set; }
            public long UserId { get; set; }
            public long PlanId { get; set; }
            public DateTime StartDate { get; set; }
            public DateTime EndDate { get; set; }
            public bool IsActive { get; set; }
            public long ActionBy { get; set; }
            public DateTime LastActionDateTime { get; set; }
            public DateTime ServerDateTime { get; set; }
            public long UnitId { get; set; }
            public long CustomerId { get; set; }
        }
        public class CreateSubscriptionPlanByUserRowDTO
        {
            public long ChangeRequestId { get; set; }
            public long MembershipId { get; set; }
            public long UserId { get; set; }
            public long CurrentPlanId { get; set; }
            public string CurrentPlan { get; set; }
            public long RequestedPlanId { get; set; }
            public string RequestedPlan { get; set; }
            public DateTime ChangeRequestDate { get; set; }
            public DateTime? ChangeProcessedDate { get; set; }
            public string ChangeStatus { get; set; }
            public string ReasonForChange { get; set; }
            public string AdminNotes { get; set; }
            public string PaymentStatus { get; set; }
            public bool IsChangeCompleted { get; set; }
            public DateTime CreatedAt { get; set; }
            public DateTime? UpdatedAt { get; set; }
        }
        public class EditSubscriptionPlanByUserCommonDTO
        {
            public EditSubscriptionPlanByUserHeaderDTO objHeaderDTO { get; set; }
            public List<EditSubscriptionPlanByUserRowDTO> objListRowDTO { get; set; }

            public class EditSubscriptionPlanByUserHeaderDTO
            {
                public long MembershipId { get; set; }
                public long UserId { get; set; }
                public long PlanId { get; set; }
                public DateTime StartDate { get; set; }
                public DateTime EndDate { get; set; }
                public bool IsActive { get; set; }
                public long ActionBy { get; set; }
                public DateTime LastActionDateTime { get; set; }
                public DateTime ServerDateTime { get; set; }
                public long UnitId { get; set; }
                public long CustomerId { get; set; }
            }

            public class EditSubscriptionPlanByUserRowDTO
            {
                public long ChangeRequestId { get; set; }
                public long MembershipId { get; set; }
                public long UserId { get; set; }
                public long CurrentPlanId { get; set; }
                public string CurrentPlan { get; set; }
                public long RequestedPlanId { get; set; }
                public string RequestedPlan { get; set; }
                public DateTime ChangeRequestDate { get; set; }
                public DateTime? ChangeProcessedDate { get; set; }
                public string ChangeStatus { get; set; }
                public string ReasonForChange { get; set; }
                public string AdminNotes { get; set; }
                public string PaymentStatus { get; set; }
                public bool IsChangeCompleted { get; set; }
                public DateTime CreatedAt { get; set; }
                public DateTime? UpdatedAt { get; set; }
            }
        }

        public class UserSubscriptionPlanSummaryDTO
        {
            // Header DTO Fields
            public long MembershipId { get; set; }
            public long UserId { get; set; }
            public long PlanId { get; set; }
            public DateTime StartDate { get; set; }
            public DateTime EndDate { get; set; }
            public bool IsActive { get; set; }
            public long ActionBy { get; set; }
            public DateTime LastActionDateTime { get; set; }
            public DateTime ServerDateTime { get; set; }
            public long UnitId { get; set; }
            public long CustomerId { get; set; }

            // Row DTO Fields
            public long ChangeRequestId { get; set; }
            public long CurrentPlanId { get; set; }
            public string CurrentPlan { get; set; }
            public long RequestedPlanId { get; set; }
            public string RequestedPlan { get; set; }
            public DateTime ChangeRequestDate { get; set; }
            public DateTime? ChangeProcessedDate { get; set; }
            public string ChangeStatus { get; set; }
            public string ReasonForChange { get; set; }
            public string AdminNotes { get; set; }
            public string PaymentStatus { get; set; }
            public bool IsChangeCompleted { get; set; }
            public DateTime CreatedAt { get; set; }
            public DateTime? UpdatedAt { get; set; }
        }

        public class GetSubscriptionDetailsDTO
        {
            public long MembershipId { get; set; }
            public long UserId { get; set; }
            public long PlanId { get; set; }
            public DateTime SubscriptionStartDate { get; set; }
            public DateTime SubscriptionEndDate { get; set; }
            public bool SubscriptionIsActive { get; set; }
            public long SubscriptionActionBy { get; set; }
            public DateTime SubscriptionLastActionDateTime { get; set; }
            public DateTime SubscriptionServerDateTime { get; set; }
            public long UnitId { get; set; }
            public long CustomerId { get; set; }

            public string PlanName { get; set; }
            public decimal Price { get; set; }
            public string Duration { get; set; }
            public string ProfileVisibility { get; set; }
            public bool IsIncreasedMatchScore { get; set; }
            public long NumberOfMatches { get; set; }
            public long MessageLimit { get; set; }
            public bool IsAccessToPremiumProfiles { get; set; }
            public bool IsPrioritySupport { get; set; }
            public bool IsAccessToAdvancedFilters { get; set; }
            public decimal DiscountPercentage { get; set; }
            public string AdditionalBenefits { get; set; }
            public bool PlanIsActive { get; set; }
            public DateTime PlanLastActionDateTime { get; set; }
            public DateTime PlanServerDateTime { get; set; }
            public long PlanActionBy { get; set; }
            public DateTime PlanStartDate { get; set; }
            public DateTime PlanEndDate { get; set; }
        }

    }
}
