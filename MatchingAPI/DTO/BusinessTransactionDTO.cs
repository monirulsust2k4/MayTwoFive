namespace MatchingAPI.DTO
{
    public class BusinessTransactionDTO
    {
        public class CreateBusinessTransactionDTO
        {
            public long AccountId { get; set; }
            public long BusinessUnitId { get; set; }
            public string BusinessTransactionName { get; set; }
            public string BusinessTransactionCode { get; set; }
            public long GeneralLedgerId { get; set; }
            public string GeneralLedgerName { get; set; }
            public string GeneralLedgerCode { get; set; }
            public bool isInternalExpense { get; set; }
            public long ActionBy { get; set; }
        }

        public class BusinessTransactionLandingPagination
        {
            public List<BusinessTransactionLandingPaginationDTO> Data { get; set; }
            public long currentPage { get; set; }
            public long totalCount { get; set; }
            public long pageSize { get; set; }
        }


        public class BusinessTransactionLandingPaginationDTO
        {
            public long SL { get; set; }
            public long BusinessTransactionId { get; set; }
            public string BusinessTransactionName { get; set; }
            public string BusinessTransactionCode { get; set; }
            public long AccountId { get; set; }
            public long BusinessUnitId { get; set; }
            public long GeneralLedgerId { get; set; }
            public string GeneralLedgerCode { get; set; }
            public string GeneralLedgerName { get; set; }
            public long ActionBy { get; set; }
        }

        public class EditBusinessTransactionDTO
        {
            public long BusinessTransactionId { get; set; }
            public string BusinessTransactionName { get; set; }
            public long GeneralLedgerId { get; set; }
            public string GeneralLedgerName { get; set; }
            public string GeneralLedgerCode { get; set; }
            public bool? isInternalExpense { get; set; }
            public long ActionBy { get; set; }
        }
    }
}
