using System.Text.Json;

namespace Product.Application.Models
{
    public class ResponseMessage
    {
        public string Message { get; set; }
        public object Result { get; set; }

        public ResponseMessage(string message = "عملیات با موفقیت انجام شد", object result = null)
        {
            Message = message;
            Result = result;
        }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
