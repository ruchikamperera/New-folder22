using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tecoora.IRepository;
using Tecoora.IService;
using Tecoora.Models;

namespace Tecoora.Services
{
    public class AppointmentService : IAppointmentService
    {
        IAppointmentRepository _appointmentRepository;
        public AppointmentService(IAppointmentRepository appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;
        }

        public async Task<Appointment> addAppointment(Appointment appointment)
        {
            var result = await _appointmentRepository.addAppointment(appointment);
            return result;
        }

        public async Task deleteAppointment(int appointmentId)
        {
            await _appointmentRepository.deleteAppointment(appointmentId);
        }

        public async Task<List<Appointment>> getAppointments()
        {
            var appointments = await _appointmentRepository.getAppointments();
            return appointments;
        }

        public async Task<List<Appointment>> getAppointments(Appointment appointment)
        {
            var appointments = await _appointmentRepository.getAppointments(appointment);
            return appointments;
        }

        public async Task<Appointment> updateAppointment(Appointment appointment)
        {
            var updatedAppointment = await _appointmentRepository.updateAppointment(appointment);
            return updatedAppointment;
        }
    }
}
