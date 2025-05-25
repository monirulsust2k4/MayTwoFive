using System.Text.Json;

namespace MatchingAPI.Models
{
    public class ExceptionMessage
    {
        public class MessageHelper
        {
            public string Message { get; set; } = "";
            public int StatusCode { get; set; }
            public long? AutoId { get; set; }
            public string Code { get; set; }
        }
        public class MessageHelperCreate
        {
            public string Message { get; set; } = "Created Successfully";
            public int StatusCode { get; set; } = 200;
            public long? AutoId { get; set; }
        }
        public class MessageHelperUpdate
        {
            public string Message { get; set; } = "Update Successfully";
            public int StatusCode { get; set; } = 200;
            public long? AutoId { get; set; }
        }
        public class MessageHelperDelete
        {
            public string Message { get; set; } = "Delete Successfully";
            public int StatusCode { get; set; } = 200;
            public long? AutoId { get; set; }
        }
        public class MessageHelperCustom
        {
            public string Message { get; set; }
            public int StatusCode { get; set; }
            public long? AutoId { get; set; }
        }
   
        public class CustomMessageHelper
        {
            public string Message { get; set; }
            public int StatusCode { get; set; }
            public long AutoId { get; set; }
            public string AutoName { get; set; }
        }
        public class ApiError
        {
            public string? Message { get; set; }
            public int StatusCode { get; set; }
            public string? StackTrace { get; set; }
            public string ToJson()
            {
                return JsonSerializer.Serialize(this);
            }
        }

        public class MessageHelperBulkUpload
        {
            public string Message { get; set; }
            public int StatusCode { get; set; }
            public List<ErrorList>? ListData { get; set; }
        }
        public class ErrorList
        {
            public string? Title { get; set; }
            public string? Body { get; set; }
        }

        //public static class CatchEx
        //{
        //    public static MessageHelper CatchProcess(this Exception exception)
        //    {
        //        MessageHelper msg = new()
        //        {
        //            StatusCode = 500,
        //            AutoId = 0,
        //            Message = exception.Message,
        //        };
        //        return msg;

        //    }
        //}

    }
}
