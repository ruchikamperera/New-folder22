
namespace Tecoora.Models
{
    public class Email:BaseModel
    {
        public int Id { get; set; }
        public string FromEmail { get; set; }
        public string ToEmail { get; set; }
        public string Content { get; set; }
        public bool IsSuccess { get; set; }
    }
}
