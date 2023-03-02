using System;
using Tecoora.Models;

namespace Tecoora.API.Models
{
    public class UserFileDetailDto
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int LawyerId { get; set; }
        public FileType FileType { get; set; }
        public string FileUrl { get; set; }
        public Boolean isDeleted { get; set; }
    }
}
