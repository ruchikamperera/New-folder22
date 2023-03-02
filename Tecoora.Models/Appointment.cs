using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Tecoora.Models
{
    public class Appointment: BaseModel
    {
        public int Id { get; set; }
        public string Status { get; set; }
        public int LawyerId { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string CallType { get; set; }
        public int StudentId { get; set; }
        public TimeSlot TimeSlot { get; set; }
        public int TimeSlotId { get; set; }
        public int? CanceledById { get; set; }
    }
}
