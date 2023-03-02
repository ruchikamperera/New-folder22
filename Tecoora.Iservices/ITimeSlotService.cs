using System.Collections.Generic;
using System.Threading.Tasks;
using Tecoora.Models;

namespace Tecoora.Iservices
{
    public interface ITimeSlotService
    {
        Task<List<TimeSlot>> getTimeSlotsByLawyerId(int lawyerId);
        Task<TimeSlot> addTimeSlot(TimeSlot timeSlotEntity);
    }
}
