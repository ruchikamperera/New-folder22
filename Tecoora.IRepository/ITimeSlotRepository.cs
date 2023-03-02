using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tecoora.Models;

namespace Tecoora.IRepository
{
    public interface ITimeSlotRepository
    {
        Task<List<TimeSlot>> getTimeSlotsByLawyerId(int lawyerId);
        Task<TimeSlot> addTimeSlot(TimeSlot timeSlotEntity);
    }
}
