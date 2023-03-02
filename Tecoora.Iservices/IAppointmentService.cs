using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tecoora.Models;

namespace Tecoora.IService
{
    public interface IAppointmentService
    {
        Task<Appointment> addAppointment(Appointment appointment);
        Task<Appointment> updateAppointment(Appointment appointment);
        Task deleteAppointment(int appointmentId);
        Task<List<Appointment>> getAppointments();
        Task<List<Appointment>> getAppointments(Appointment appointment);
    }
}
