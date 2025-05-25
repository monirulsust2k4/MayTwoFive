using System.ComponentModel.DataAnnotations;

namespace MatchingAPI.DTO
{
    public class GeneralLedgerDTO
    {

        [Required]
        [Range(1, Int64.MaxValue, ErrorMessage = "The field {0} must be greater than {1}.")]
        public long AccountId { get; set; }
        [Required]
        [Range(1, Int64.MaxValue, ErrorMessage = "The field {0} must be greater than {1}.")]
        public long AccountGroupId { get; set; }
        [Required]
        [Range(1, Int64.MaxValue, ErrorMessage = "The field {0} must be greater than {1}.")]
        public long AccountClassId { get; set; }
        [Required]
        [Range(1, Int64.MaxValue, ErrorMessage = "The field {0} must be greater than {1}.")]
        public long AccountCategoryId { get; set; }
        public string GeneralLedgerCode { get; set; }
        public string GeneralLedgerName { get; set; }
        public long GlaccountTypeId { get; set; }
        public string GlaccountTypeName { get; set; }
        public long ActionBy { get; set; }
        public bool Scheduleview { get; set; }
        public bool SubglAllow {  get; set; }
    }

    public class EditGeneralLedgerDTO
    {
        public long GeneralLedgerId { get; set; }
        public long AccountId { get; set; }

        //public long AccountGroupId { get; set; }
        //public long AccountClassId { get; set; }
        //public long AccountCategoryId { get; set; }
        // public string GeneralLedgerCode { get; set; }
        public string GeneralLedgerName { get; set; }
        //public long GlaccountTypeId { get; set; }
        public long ActionBy { get; set; }
    }

    public class GetGeneralLedgerDTO
    {
        public long Sl { get; set; }
        public long GeneralLedgerId { get; set; }
        public long AccountId { get; set; }
        public long AccountGroupId { get; set; }
        public string AccountGroupName { get; set; }
        public long AccountClassId { get; set; }
        public string AccountClassName { get; set; }
        public long AccountCategoryId { get; set; }
        public string AccountCategoryName { get; set; }
        public string GeneralLedgerCode { get; set; }
        public string GeneralLedgerName { get; set; }
        public long GlaccountTypeId { get; set; }
        public string GlaccountTypeName { get; set; }
        public long ActionBy { get; set; }
    }

    public class GetGeneralLedgerDDLDTO
    {
        public long GeneralLedgerId { get; set; }
        public string GeneralLedgerName { get; set; }
        public string GeneralLedgerNameCode { get; set; }
        public bool IsSubGlAllowed { get; set; }
    }

}
