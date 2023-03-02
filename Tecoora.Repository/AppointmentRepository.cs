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
    public class AppointmentRepository: IAppointmentRepository
    {
        private readonly TecooraContext _context;
        public AppointmentRepository(TecooraContext context)
        {
            _context = context;
        }

        public async Task<Appointment> addAppointment(Appointment appointment)
        {
            await _context.Appointments.AddAsync(appointment);
            _context.SaveChanges();
            return appointment;
        }

        public async Task deleteAppointment(int appointmentId)
        {
            var appointment = await _context.Appointments.FindAsync(appointmentId);
            _context.Appointments.Remove(appointment);
            _context.SaveChanges();
        }

        public async Task<List<Appointment>> getAppointments()
        {
            var appointments = await _context.Appointments.ToListAsync();
            return appointments;
        }

        public async Task<List<Appointment>> getAppointments(Appointment appointment)
        {
            List<Appointment> appointments;
            if (appointment.LawyerId != 0 
                && appointment.Status == null
                && appointment.StudentId == 0)
            {
                appointments = await _context.Appointments.Where(a => a.LawyerId.Equals(appointment.LawyerId)).ToListAsync();
            }if (appointment.LawyerId == 0 
                && appointment.Status == null 
                && appointment.StudentId != 0) {
                appointments = await _context.Appointments.Where(a => a.StudentId.Equals(appointment.StudentId)).ToListAsync();
            }
            else
            {
                appointments = await _context.Appointments.Where(a => a.LawyerId.Equals(appointment.LawyerId) && a.Status.Equals(appointment.Status)).ToListAsync();
            }
            return appointments;
        }

        public async Task<Appointment> updateAppointment(Appointment appointment)
        {
            var existingAppointment = await _context.Appointments.FindAsync(appointment.Id);

            if (appointment.Status.Equals("Canceled")) {
                existingAppointment.CanceledById = appointment.LawyerId;
            }

            existingAppointment.Status = appointment.Status;
            _context.SaveChanges();
            return existingAppointment;
        }
    }
}
