namespace MatchingAPI.DTO
{
    public class CashJournalDTO
    {

        public CreateCashJournalHeaderDTO objHeader { get; set; }
        public List<CreateCashJournalRowDTO> objRowList { get; set; }
    }
    public class CreateCashJournalHeaderDTO
    {
        public long CashJournalId { get; set; }
        public string CashJournalCode { get; set; }

        public DateTime JournalDate { get; set; }
        public long AccountId { get; set; }
        public long BusinessUnitId { get; set; }
        public long Sbuid { get; set; }
        public string ReceiveFrom { get; set; }
        public string TransferTo { get; set; }
        public string PaidTo { get; set; }
        public long GeneralLedgerId { get; set; }
        public string GeneralLedgerCode { get; set; }
        public string GeneralLedgerName { get; set; }
        public decimal Amount { get; set; }
        public string Narration { get; set; }
        public bool Posted { get; set; }
        public long? PartnerTypeId { get; set; }
        public string PartnerTypeName { get; set; }
        public long? BusinessPartnerId { get; set; }
        public string BusinessPartnerCode { get; set; }
        public string BusinessPartnerName { get; set; }
        public long AccountingJournalTypeId { get; set; }
        public bool DirectPosting { get; set; }
        public long ActionBy { get; set; }
        public string ControlType { get; set; }
        public string CostRevenueName { get; set; }
        public long? CostRevenueId { get; set; }

        public string ElementName { get; set; }
        public long? ElementId { get; set; }
        public string? Attachment { get; set; }

    }

    public class CreateCashJournalRowDTO
    {
        public long RowId { get; set; }
        public long? BankAccountId { get; set; }
        public string BankAccNo { get; set; }
        public long BusinessTransactionId { get; set; }
        public string BusinessTransactionCode { get; set; }
        public string BusinessTransactionName { get; set; }
        public long GeneralLedgerId { get; set; }
        public string GeneralLedgerCode { get; set; }
        public string GeneralLedgerName { get; set; }
        public decimal Amount { get; set; }
        public string Narration { get; set; }
        public long PartnerId { get; set; }
        public string PartnerName { get; set; }
        public string PartnerCode { get; set; }
        public long PartnerTypeId { get; set; }
        public string PartnerTypeName { get; set; }
        public long BusinessPartnerId { get; set; }
        public string BusinessPartnerCode { get; set; }
        public string BusinessPartnerName { get; set; }
        public long SubGLId { get; set; }
        public string SubGlCode { get; set; }
        public string SubGLName { get; set; }
        public long SubGLTypeId { get; set; }
        public string SubGLTypeName { get; set; }

        //public bool Active { get; set; }
        //public long ActionBy { get; set; }

    }
}
