using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tecoora.DataContext;
using Tecoora.IRepository;
using Tecoora.Models;

namespace Tecoora.Repository
{
    public class TimeSlotRepository : ITimeSlotRepository
    {
        private readonly TecooraContext _context;
        public TimeSlotRepository(TecooraContext context)
        {
            _context = context;
        }

        public async Task<TimeSlot> addTimeSlot(TimeSlot timeSlotEntity)
        {
            await _context.TimeSlots.AddAsync(timeSlotEntity);
            _context.SaveChanges();
            return timeSlotEntity;
        }

        public async Task<List<TimeSlot>> getTimeSlotsByLawyerId(int lawyerId)
        {
            var timeSlots = await _context.TimeSlots.Where(a => a.LawyerId.Equals(lawyerId)).ToListAsync();
            return timeSlots;
        }

    }
}
