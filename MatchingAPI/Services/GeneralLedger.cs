using MatchingAPI.Data;
using MatchingAPI.Data.Entity;
using MatchingAPI.DTO;
using MatchingAPI.IServices;
using static MatchingAPI.DTO.CommonDTO;
using static MatchingAPI.Models.ExceptionMessage;

namespace MatchingAPI.Services
{

    public class GeneralLedger : IGeneralLedger
    {


        private readonly PeopleDeskContext _dbContext;
        public GeneralLedger(PeopleDeskContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<MessageHelper> CreateGeneralLedger(GeneralLedgerDTO objCreateGlDTO)
        {

            try
            {
                var result = _dbContext.TblGeneralLedgers.Where(x => (x.StrGeneralLedgerCode == objCreateGlDTO.GeneralLedgerCode || x.StrGeneralLedgerName == objCreateGlDTO.GeneralLedgerName)

                && x.IntAccountId == objCreateGlDTO.AccountId && x.IsActive == true)
                                                      .FirstOrDefault();

                if (result == null)
                {


                    var detalis = new TblGeneralLedger()
                    {
                        IntAccountId = objCreateGlDTO.AccountId,
                        IntAccountGroupId = (from b in _dbContext.TblAccountCategories where b.IntAccountCategoryId == objCreateGlDTO.AccountCategoryId && b.IsActive == true select b.IntAccountGroupId).FirstOrDefault(),
                        //objCreateGlDTO.AccountGroupId,
                        IntAccountClassId = (from b in _dbContext.TblAccountCategories where b.IntAccountCategoryId == objCreateGlDTO.AccountCategoryId && b.IsActive == true select b.IntAccountClassId).FirstOrDefault(),
                        //objCreateGlDTO.AccountClassId,
                        IntAccountCategoryId = objCreateGlDTO.AccountCategoryId,
                        StrGeneralLedgerCode = objCreateGlDTO.GeneralLedgerCode,
                        StrGeneralLedgerName = objCreateGlDTO.GeneralLedgerName,
                        IntGeneralLedgerTypeId = objCreateGlDTO.GlaccountTypeId,
                        IntActionBy = objCreateGlDTO.ActionBy,
                        IsScheduleView=objCreateGlDTO.Scheduleview,
                        IsSubGlallowed=objCreateGlDTO.SubglAllow,
                        DteLastActionDateTime = DateTime.UtcNow,
                        IsActive = true
                    };

                    await _dbContext.AddRangeAsync(detalis);
                    await _dbContext.SaveChangesAsync();

                }
                else
                {
                    throw new Exception("Already General Ledger Exists");


                }
                var msg = new MessageHelper();
                msg.Message = "Sucessfully Created";
                msg.StatusCode = 200;
                return msg;
            }
            catch (Exception ex)
            {
                throw ex;

            }

            
        }


        public async Task<MessageHelper> EditGeneralLedger(EditGeneralLedgerDTO objEditGlDTO)
        {
            try
            {
                var msg = new MessageHelper();
                var result = _dbContext.TblGeneralLedgers.Where(x => (x.StrGeneralLedgerName == objEditGlDTO.GeneralLedgerName) && x.IntAccountId == objEditGlDTO.AccountId
                                && x.IntGeneralLedgerId != objEditGlDTO.GeneralLedgerId && x.IsActive == true).FirstOrDefault();

                if (result == null)
                {
                    TblGeneralLedger detalisrow = _dbContext.TblGeneralLedgers.First(x => x.IntGeneralLedgerId == objEditGlDTO.GeneralLedgerId && x.IsActive == true);

                    /*detalisrow.IntAccountId = objEditGlDTO.AccountId;
                    detalisrow.IntAccountGroupId = objEditGlDTO.AccountGroupId;
                    detalisrow.IntAccountClassId = objEditGlDTO.AccountClassId;
                    detalisrow.IntAccountCategoryId = objEditGlDTO.AccountCategoryId;*/

                    //detalisrow.StrGeneralLedgerCode = objEditGlDTO.GeneralLedgerCode;
                    detalisrow.StrGeneralLedgerName = objEditGlDTO.GeneralLedgerName;
                    //detalisrow.IntGeneralLedgerTypeId = objEditGlDTO.GlaccountTypeId;
                    detalisrow.IntActionBy = objEditGlDTO.ActionBy;
                    detalisrow.DteLastActionDateTime = DateTime.UtcNow;

                    _dbContext.TblGeneralLedgers.Update(detalisrow);
                    await _dbContext.SaveChangesAsync();
                }
                else
                    throw new Exception("Already General Ledger Exist.");

                msg.Message = "Processing";
                msg.StatusCode = 200;
                return msg;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public async Task<List<GetGeneralLedgerDTO>> GetGeneralLedgerById(long GLID)
        {
            var data = await Task.FromResult((from c in _dbContext.TblGeneralLedgers
                                              join ag in _dbContext.TblAccountGroups on c.IntAccountGroupId equals ag.IntAccountGroupId
                                              join ac in _dbContext.TblAccountClasses on c.IntAccountClassId equals ac.IntAccountClassId
                                              join acat in _dbContext.TblAccountCategories on c.IntAccountCategoryId equals acat.IntAccountCategoryId
                                              join glt in _dbContext.TblGeneralLedgerTypes on c.IntGeneralLedgerTypeId equals glt.IntGeneralLedgerTypeId
                                              where c.IsActive == true && c.IntGeneralLedgerId == GLID
                                              select new GetGeneralLedgerDTO
                                              {
                                                  GeneralLedgerId = c.IntGeneralLedgerId,
                                                  GeneralLedgerCode = c.StrGeneralLedgerCode,
                                                  GeneralLedgerName = c.StrGeneralLedgerName,
                                                  AccountGroupId = c.IntAccountGroupId,
                                                  AccountGroupName = ag.StrAccountGroupName,
                                                  AccountClassId = c.IntAccountClassId,
                                                  AccountClassName = ac.StrAccountClassName,
                                                  AccountCategoryId = c.IntAccountCategoryId,
                                                  AccountCategoryName = acat.StrAccountCategoryName,
                                                  ActionBy = c.IntActionBy,
                                                  AccountId = c.IntAccountId,
                                                  GlaccountTypeId = c.IntGeneralLedgerTypeId,
                                                  GlaccountTypeName = glt.IntGeneralLedgerTypeName
                                              }).ToList());
            long index = 1;
            foreach (var oData in data)
                oData.Sl = index++;

            if (data == null)
                throw new Exception("GL Information Not Found.");

            return data;
        }

        public async Task<List<GetCommonDTODDL>> GetGeneralLedgerDDL(long AccountId, long GeneralLedgerTypeId)
        {
            var data = await Task.FromResult((from c in _dbContext.TblGeneralLedgers
                                              where c.IsActive == true && c.IntAccountId == AccountId
                                              && c.IntGeneralLedgerTypeId == GeneralLedgerTypeId
                                              select new GetCommonDTODDL
                                              {
                                                  Value = c.IntGeneralLedgerId,
                                                  Label = c.StrGeneralLedgerName,
                                                  Code = c.StrGeneralLedgerCode

                                              }).ToList()); ;
            if (data == null)
                throw new Exception("General Ledger Not Found.");

            return data;
        }


        public async Task<List<GetCommonDTODDL>> GetGeneralLedgerByCategoryDDL(long AccountId, long GeneralLedgerCategoryId, long BusinessUnitId)
        {
            //throw new NotImplementedException();

            var data = await Task.FromResult((from c in _dbContext.TblGeneralLedgers
                                              join g in _dbContext.TblBusinessUnitGeneralLedgers
                                              on c.IntGeneralLedgerId equals g.IntGeneralLedgerId
                                              where c.IsActive == true && c.IntAccountId == AccountId
                                              && c.IntAccountCategoryId == GeneralLedgerCategoryId
                                              && g.IntBusinessUnitId == BusinessUnitId
                                              select new GetCommonDTODDL
                                              {
                                                  Value = c.IntGeneralLedgerId,
                                                  Label = c.StrGeneralLedgerName,
                                                  Code = c.StrGeneralLedgerCode

                                              }).ToList());

            if (data == null)
                throw new Exception("General Ledger Not Found.");

            return data;
        }


        public async Task<MessageHelper> DeleteAccountClass(long ClassId,long ActionBy)
        {
            //throw new NotImplementedException();
            try
            {
                var msg = new MessageHelper();

                TblAccountClass detalisrow = _dbContext.TblAccountClasses.First(x => x.IntAccountClassId == ClassId && x.IsActive == true);

                detalisrow.IsActive = false;
                detalisrow.IntActionBy=ActionBy;
                detalisrow.DteLastActionDateTime = DateTime.Now;


                _dbContext.TblAccountClasses.Update(detalisrow);
                await _dbContext.SaveChangesAsync();


                msg.Message = "Processing";
                msg.StatusCode = 200;
                return msg;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public async Task<List<GetGeneralLedgerDDLDTO>> GetGeneralLedgerDDLByAccountGroup(long AccountId, long BusinessUnitId, long AccountGroupId)
        {
            AccountGroupId = 0;
            List<GetGeneralLedgerDDLDTO> data = new List<GetGeneralLedgerDDLDTO>();
            if (AccountGroupId != 0)
            {
                data = await Task.FromResult((from c in _dbContext.TblBusinessUnitGeneralLedgers
                                              join g in _dbContext.TblGeneralLedgers on c.IntGeneralLedgerId equals g.IntGeneralLedgerId
                                              where c.IsActive == true && c.IntAccountId == AccountId && c.IntBusinessUnitId == BusinessUnitId && g.IntAccountGroupId == AccountGroupId
                                              && g.IsActive == true
                                              select new GetGeneralLedgerDDLDTO
                                              {
                                                  GeneralLedgerId = c.IntGeneralLedgerId,
                                                  GeneralLedgerName = c.StrGeneralLedgerName,
                                                  GeneralLedgerNameCode = c.StrGeneralLedgerCode,
                                                  IsSubGlAllowed = g.IsSubGlallowed ?? false
                                              }).ToList());
            }
            else
            {
                data = await Task.FromResult((from c in _dbContext.TblBusinessUnitGeneralLedgers
                                              join g in _dbContext.TblGeneralLedgers on c.IntGeneralLedgerId equals g.IntGeneralLedgerId
                                              where c.IsActive == true && c.IntAccountId == AccountId && c.IntBusinessUnitId == BusinessUnitId
                                              && g.IsActive == true
                                              select new GetGeneralLedgerDDLDTO
                                              {
                                                  GeneralLedgerId = c.IntGeneralLedgerId,
                                                  GeneralLedgerName = c.StrGeneralLedgerName,
                                                  GeneralLedgerNameCode = c.StrGeneralLedgerCode,
                                                  IsSubGlAllowed = g.IsSubGlallowed ?? false
                                              }).ToList());
            }

            if (data == null)
                data = new List<GetGeneralLedgerDDLDTO>();

            return data;
        }

    }
}
