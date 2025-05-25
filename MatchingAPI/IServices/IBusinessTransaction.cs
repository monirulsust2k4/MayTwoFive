using static MatchingAPI.DTO.BusinessTransactionDTO;
using static MatchingAPI.Models.ExceptionMessage;

namespace MatchingAPI.IServices
{
    public interface IBusinessTransaction
    {
        public Task<MessageHelper> CreateBusinessTransaction(CreateBusinessTransactionDTO objCreate);

        public Task<BusinessTransactionLandingPagination> GetBusinessTransactionLandingPasignation(long AccountId, long BusinessUnitId, string viewOrder, long PageNo, long PageSize);
        public Task<MessageHelper> EditBusinessTransaction(EditBusinessTransactionDTO objEdit);
    }
}
