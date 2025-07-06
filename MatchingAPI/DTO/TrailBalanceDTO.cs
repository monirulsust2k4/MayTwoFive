namespace MatchingAPI.DTO
{
    public class TrailBalanceDTO
    {

        public class GetTrailBalanceReportDTO
        {
            public long LedgerId { get; set; }
            public decimal Debit { get; set; }
            public decimal Credit { get; set; }
            //public string GeneralLedgerCode { get; set; }
            //public string GeneralLedgerName { get; set; }
            public string GeneralLedgerCode { get; set; }
            public string GeneralLedgerName { get; set; }

        }
    }
}
