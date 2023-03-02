using System;

namespace Tecoora.API.Models
{
    public class ScheduledDto
    {
        public int Id { get; set; }
        public Boolean IsAvailable { get; set; }
        public int LawyerUserId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
