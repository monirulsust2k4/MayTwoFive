
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using MatchingAPI.DbContexts;
using System.Collections.Generic; // Add this namespace for List<T>
using MatchingAPI.Models; // Add this namespace for KeyValue

namespace MatchingAPI.Services
{
    public class CashJournal : ICashJournal
    {
        private readonly PeopleDeskContext _dbContext;
        CodeGenerate con = new CodeGenerate();
        string dtCode;
        public CashJournal(PeopleDeskContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<MessageHelper> CreateCashJournalNew(CashJournalDTO objCreate)
        {
            try
            {
                var sp = "mar.sprCashJournal";
                var input = new List<KeyValue>();
                var output = new List<KeyValue>();

                input.Add(new KeyValue { Key = "@HeaderString", Value = objCreate.objHeader });
                input.Add(new KeyValue { Key = "@RowString", Value = objCreate.objRowList });

                output.Add(new KeyValue { Key = "@msg" });
                output.Add(new KeyValue { Key = "@code" });

                var result = StoreProcedureCall.PostJson(sp, input, output);

                var msg = result.Find(x => x.Key == "@msg").Value.ToString();
                var code = result.Find(x => x.Key == "@code").Value.ToString();

                return new MessageHelper { UserCode = code, Message = msg, statuscode = 200 };

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
