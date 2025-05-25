using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using MatchingAPI.DTO;

using MatchingAPI.Helper;
using MatchingAPI.Services;
using static MatchingAPI.Models.ExceptionMessage;

namespace MatchingAPI.IServices
{
    public interface ICashJournal
    {

        public  Task<MessageHelper> CreateCashJournalNew(CashJournalDTO objCreate);
    }
}
