using System.Text;
using System.Text.Json;

namespace Smart.Finances.Core.Model.Args
{
    public class EmailArgs
    {
        public string To { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }

        public EmailArgs(string to, string message, string subject)
        {
            To = to;
            Subject = subject;
            Body = message;
        }

        public string ToJson()
        {
            return JsonSerializer.Serialize(this);
        }

        public byte[] ToBytes()
        {
            return Encoding.UTF8.GetBytes(ToJson());
        }
    }
}
