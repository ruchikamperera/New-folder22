using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tecoora.Models;

namespace Tecoora.IRepository
{
    public interface IScheduleRepository
    {
        Task<Schedule> addShedule(Schedule schedule);
        Task<Schedule> updateSchedule(Schedule schedule);
        Task deleteSchedule(int scheduleId);
        Task<List<Schedule>> getSchedule();
    }
}
