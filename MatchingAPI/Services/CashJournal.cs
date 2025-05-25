using MatchingAPI.Data;
using MatchingAPI.StoreProcedure;
using static MatchingAPI.Models.ExceptionMessage;
using MatchingAPI.DTO;
using Microsoft.Graph;
using Microsoft.Graph.Models;
using MatchingAPI.Helper;
using MatchingAPI.IServices;

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


                var headerString = System.Text.Json.JsonSerializer.Serialize(objCreate.objHeader);
                input.Add(new KeyValue { Key = "@HeaderString", Value = headerString });

                var rowString = System.Text.Json.JsonSerializer.Serialize(objCreate.objRowList);
                input.Add(new KeyValue { Key = "@RowString", Value = rowString });

                output.Add(new KeyValue { Key = "@msg" });
                output.Add(new KeyValue { Key = "@code" });


                var result = StoreProcedureCall.PostJson(sp, input, output);

                var msg = result.Find(x => x.Key == "@msg").Value.ToString();
                var code = result.Find(x => x.Key == "@code").Value.ToString();


                //var input = new List<KeyValue>();
                //var output = new List<KeyValue>();

                //input.Add(new KeyValue { Key = "@HeaderString", Value = objCreate.objHeader });
                //input.Add(new KeyValue { Key = "@RowString", Value = objCreate.objRowList });

                //output.Add(new KeyValue { Key = "@msg" });
                //output.Add(new KeyValue { Key = "@code" });

                //var result = StoreProcedureCall.PostJson(sp, input, output);

                //var msg = result.Find(x => x.Key == "@msg").Value.ToString();
                //var code = result.Find(x => x.Key == "@code").Value.ToString();


                return new MessageHelper { Code = code, Message = msg, StatusCode = 200 };
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
