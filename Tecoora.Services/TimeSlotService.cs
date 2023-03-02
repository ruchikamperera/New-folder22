using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tecoora.IRepository;
using Tecoora.Iservices;
using Tecoora.Models;

namespace Tecoora.Services
{
    public class TimeSlotService : ITimeSlotService
    {
        ITimeSlotRepository _timeSlotRepository;
        public TimeSlotService(ITimeSlotRepository timeSlotRepository)
        {
            _timeSlotRepository = timeSlotRepository;
        }
        public async Task<List<TimeSlot>> getTimeSlotsByLawyerId(int lawyerId)
        {
            var timeSlots = await _timeSlotRepository.getTimeSlotsByLawyerId(lawyerId);
            return timeSlots;
        }
        public async Task<TimeSlot> addTimeSlot(TimeSlot timeSlotEntity)
        {
            var result = await _timeSlotRepository.addTimeSlot(timeSlotEntity);
            return result;
        }
    }
}
