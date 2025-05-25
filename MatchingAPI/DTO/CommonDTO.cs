namespace MatchingAPI.DTO
{
    public class CommonDTO
    {

        public class GetCommonDTODDL
        {
            public long Value { get; set; }
            public string Label { get; set; }
            public long ShipToPartnerId { get; set; }
            public string ShipToPartnerName { get; set; }
            public string Code { get; set; }
            public DateTime dtedate { get; set; }

            public long Value2 { get; set; }
            public string Label2 { get; set; }

            public long TerritoryId { get; set; }
            public string Address { get; set; }
            public decimal? Qty { get; set; }

        }
    }
}
