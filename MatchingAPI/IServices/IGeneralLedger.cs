using MatchingAPI.DTO;
using static MatchingAPI.DTO.CommonDTO;
using static MatchingAPI.Models.ExceptionMessage;

namespace MatchingAPI.IServices
{
    public interface IGeneralLedger
    {


        public  Task<MessageHelper> CreateGeneralLedger(GeneralLedgerDTO objCreateGlDTO);
        public Task<MessageHelper> EditGeneralLedger(EditGeneralLedgerDTO objEditGlDTO);
        public Task<List<GetGeneralLedgerDTO>> GetGeneralLedgerById(long GLID);
        public Task<List<GetCommonDTODDL>> GetGeneralLedgerDDL(long AccountId, long GeneralLedgerTypeId);

        public  Task<List<GetCommonDTODDL>> GetGeneralLedgerByCategoryDDL(long AccountId, long GeneralLedgerCategoryId, long BusinessUnitId);
        public  Task<MessageHelper> DeleteAccountClass(long ClassId, long ActionBy);

        public Task<List<GetGeneralLedgerDDLDTO>> GetGeneralLedgerDDLByAccountGroup(long AccountId, long BusinessUnitId, long AccountGroupId);
    }
}
