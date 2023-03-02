using System;

namespace Tecoora.API.Models
{
    public class TimeSlotDto
    {
        public int Id { get; set; }
        public int LawyerId { get; set; }
        public DateTime ToTime { get; set; }
        public DateTime FromTime { get; set; }
    }
}
