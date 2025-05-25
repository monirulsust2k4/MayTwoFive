using MatchingAPI.Data;
using MatchingAPI.Data.Entity;
using MatchingAPI.Helper;
using MatchingAPI.IServices;
using static MatchingAPI.DTO.BusinessTransactionDTO;
using static MatchingAPI.Models.ExceptionMessage;

namespace MatchingAPI.Services
{
    public class BusinessTransaction : IBusinessTransaction
    {

        private readonly PeopleDeskContext _dbContext;
        public BusinessTransaction(PeopleDeskContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<MessageHelper> CreateBusinessTransaction(CreateBusinessTransactionDTO objCreate)
        {
            //throw new NotImplementedException();

            try
            {

                TblBusinessTransaction Ledger = null;
                var result = _dbContext.TblBusinessTransactions.Where(x => x.StrBusinessTransactionName == objCreate.BusinessTransactionName
                    && x.IntAccountId == objCreate.AccountId && x.IntBusinessUnitId == objCreate.BusinessUnitId
                    && x.IsActive == true).FirstOrDefault();

                var GlInfo = await Task.FromResult(_dbContext.TblGeneralLedgers.Where(x => x.IntGeneralLedgerId == objCreate.GeneralLedgerId
                                                && x.IntAccountId == objCreate.AccountId).FirstOrDefault());

                if (GlInfo.IsSubGlallowed == false)
                {
                    Ledger = _dbContext.TblBusinessTransactions.Where(x => x.IntGeneralLedgerId == objCreate.GeneralLedgerId
                   && x.IntAccountId == objCreate.AccountId && x.IntBusinessUnitId == objCreate.BusinessUnitId
                   && x.IsActive == true).FirstOrDefault();

                }

                var GeneralLedgerCount = await Task.FromResult(_dbContext.TblBusinessTransactions.Where(x => x.IntGeneralLedgerId == objCreate.GeneralLedgerId
                                                            && x.IntAccountId == objCreate.AccountId && x.IntBusinessUnitId == objCreate.BusinessUnitId).Count());

                if (result == null && Ledger == null)
                {
                    var detalis = new TblBusinessTransaction()
                    {
                        IntAccountId = objCreate.AccountId,
                        IntBusinessUnitId = objCreate.BusinessUnitId,
                        StrBusinessTransactionName = objCreate.BusinessTransactionName,
                        StrBusinessTransactionCode = GlInfo.StrGeneralLedgerCode.ToString() + String.Format("{0:00}", (GeneralLedgerCount + 1)),
                        IntGeneralLedgerId = objCreate.GeneralLedgerId,
                        StrGeneralLedgerName = objCreate.GeneralLedgerName,
                        StrGeneralLedgerCode = GlInfo.StrGeneralLedgerCode,
                        IsInternalExpense = objCreate.isInternalExpense,
                        IntActionBy = objCreate.ActionBy,
                        DteLastActionDateTime = DateTime.UtcNow,
                        IsActive = true
                    };
                   
                    await _dbContext.TblBusinessTransactions.AddAsync(detalis);
                    await _dbContext.SaveChangesAsync();
                }
                else if (result == null)
                {
                    throw new Exception("Data Already exist");
                }
                else
                {
                    throw new Exception("Data already exists in this General Ledger");
                }


                var msg = new MessageHelper();
                msg.Message = "Processing";
                msg.StatusCode = 200;
                return msg;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        public async Task<BusinessTransactionLandingPagination> GetBusinessTransactionLandingPasignation(long AccountId, long BusinessUnitId, string viewOrder, long PageNo, long PageSize)
        {
            //throw new NotImplementedException();

            var counts = _dbContext.TblBusinessTransactions.Where(x => x.IntAccountId == AccountId && x.IntBusinessUnitId == BusinessUnitId && x.IsActive == true).Count();

            IQueryable<BusinessTransactionLandingPaginationDTO> data = await Task.FromResult(from bp in _dbContext.TblBusinessTransactions
                                                                                             where bp.IntAccountId == AccountId && bp.IntBusinessUnitId == BusinessUnitId && bp.IsActive == true
                                                                                             orderby bp.IntBusinessTransactionId descending
                                                                                             select new BusinessTransactionLandingPaginationDTO()
                                                                                             {
                                                                                                 BusinessTransactionId = bp.IntBusinessTransactionId,
                                                                                                 BusinessTransactionName = bp.StrBusinessTransactionName,
                                                                                                 BusinessTransactionCode = bp.StrBusinessTransactionCode,
                                                                                                 GeneralLedgerId = bp.IntGeneralLedgerId,
                                                                                                 GeneralLedgerCode = bp.StrGeneralLedgerCode,
                                                                                                 GeneralLedgerName = bp.StrGeneralLedgerName

                                                                                             });

            if (data == null)
                throw new Exception("Transport Zone Not Found.");
            else
            {
                if (viewOrder.ToUpper() == "ASC")
                    data = data.OrderBy(o => o.GeneralLedgerId);
                else if (viewOrder.ToUpper() == "DESC")
                    data = data.OrderByDescending(o => o.GeneralLedgerId);
            }

            if (PageNo <= 0)
                PageNo = 1;
            var itemdata = PagingList<BusinessTransactionLandingPaginationDTO>.CreateAsync(data, PageNo, PageSize);
            int index = 1;
            foreach (var itms in itemdata)
            {
                itms.SL = index++;
            }
            BusinessTransactionLandingPagination itm = new BusinessTransactionLandingPagination();

            itm.Data = itemdata;
            itm.currentPage = PageNo;
            itm.totalCount = counts;
            itm.pageSize = PageSize;

            return itm;
        }

        public async Task<MessageHelper> EditBusinessTransaction(EditBusinessTransactionDTO objEdit)
        {
            //  throw new NotImplementedException();

            try
            {
                var msg = new MessageHelper();
               var detalisrow = _dbContext.TblBusinessTransactions.First(x => x.IntBusinessTransactionId == objEdit.BusinessTransactionId && x.IsActive == true);

                var result = _dbContext.TblBusinessTransactions.Where(x => x.StrBusinessTransactionName == objEdit.BusinessTransactionName
                && x.IntAccountId == detalisrow.IntAccountId && x.IntBusinessUnitId == detalisrow.IntBusinessUnitId
                && x.IntBusinessTransactionId != objEdit.BusinessTransactionId && x.IsActive == true).FirstOrDefault();

                if (result == null)
                {
                    detalisrow.IntBusinessTransactionId = objEdit.BusinessTransactionId;
                    detalisrow.StrBusinessTransactionName = objEdit.BusinessTransactionName;
                    detalisrow.IntGeneralLedgerId = objEdit.GeneralLedgerId;
                    detalisrow.StrGeneralLedgerName = objEdit.GeneralLedgerName;
                    detalisrow.StrGeneralLedgerCode = objEdit.GeneralLedgerCode;
                    detalisrow.IntActionBy = objEdit.ActionBy;
                    detalisrow.IsInternalExpense = objEdit.isInternalExpense;
                    detalisrow.DteLastActionDateTime = DateTime.UtcNow;

                    _dbContext.TblBusinessTransactions.Update(detalisrow);
                    await _dbContext.SaveChangesAsync();
                }
                else
                    throw new Exception("Business Transaction already Exist.");

                msg.Message = "Processing";
                msg.StatusCode = 200;
                return msg;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
