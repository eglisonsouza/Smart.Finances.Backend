using System.Text;
using System.Text.Json;

namespace Smart.Finances.Core.Model.Args
{
    public class EmailArgs
    {
        public string To { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }

        public EmailArgs(string to, string mensagem, string assunto)
        {
            To = to;
            Subject = assunto;
            Body = mensagem;
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
