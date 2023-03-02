using System;
using System.Collections.Generic;
using System.Text;

namespace Tecoora.Models
{
    public class LawyerRequestedFile
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int LawyerId { get; set; }
        public FileType FileType { get; set; }
        public DateTime DueDate { get; set; }
        public Boolean IsDeleted { get; set; }
    }
}
