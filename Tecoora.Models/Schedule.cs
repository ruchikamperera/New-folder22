using System;
using System.Collections.Generic;
using System.Text;

namespace Tecoora.Models
{
    public class Schedule
    {
        public int Id { get; set; }
        public Boolean IsAvailable { get; set; }
        public int LawyerUserId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
