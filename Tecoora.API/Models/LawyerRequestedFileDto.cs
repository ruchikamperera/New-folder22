using System;
using Tecoora.Models;

namespace Tecoora.API.Models
{
    public class LawyerRequestedFileDto
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int LawyerId { get; set; }
        public FileType FileType { get; set; }
        public DateTime DueDate { get; set; }
        public Boolean IsDeleted { get; set; }
    }
}
