using System.Collections.Generic;

namespace DataBaseLayer.ViewModels.Responses
{

    public enum CodeResponse
    {
        Exist,
        NotExist,
        NotFound,
        Unknown,
        DbError,
        InvalidParams
    }

    public class ResponseBase
    {
        public CodeResponse Code { get; set; }
        public string Message { get; set; }
        public List<string> ErrorMessages { get; set; }
        public object ObjError { get; set; }
    }
}