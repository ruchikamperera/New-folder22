using System;

namespace Tecoora.API.Models
{
    public class AppointmentDto:BaseModelDto
    {
        public int Id { get; set; }
        public string Status { get; set; }
        public int LawyerId { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string CallType { get; set; }
        public int StudentId { get; set; }
        public int TimeSlotId { get; set; }
        public TimeSlotDto? TimeSlotDto{ get; set; }
        public int? CanceledById { get; set; }
    }
}
