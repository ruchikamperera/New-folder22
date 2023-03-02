using System;
using System.Collections.Generic;
using System.Text;

namespace Tecoora.Models
{
    public class UserFileDetail
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int LawyerId { get; set; }
        public FileType FileType { get; set; }
        public string FileUrl { get; set; }
        public Boolean isDeleted { get; set; }
    }
}
