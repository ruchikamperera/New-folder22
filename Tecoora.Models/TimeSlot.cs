using System;
using System.Collections.Generic;
using System.Text;

namespace Tecoora.Models
{
    public class TimeSlot
    {
        public int Id { get; set; }
        public int LawyerId { get; set; }
        public DateTime ToTime { get; set; }
        public DateTime FromTime { get; set; }
    }
}
