using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tecoora.API.Models;
using Tecoora.API.Responses;
using Tecoora.IService;
using Tecoora.Models;

namespace Tecoora.API.Controllers
{
    public class AppointmentController
    {
        IAppointmentService _appointmentService;
        private readonly IMapper _mapper;

        public AppointmentController(IAppointmentService appointmentService, IMapper mapper)
        {
            _appointmentService = appointmentService;
            _mapper = mapper;
        }

        [Produces("application/json")]
        [HttpGet, Route("appointments")]
        public async Task<ApiResponse> getAppointments()
        {
            ApiResponse apiResponse = new ApiResponse();
            try
            {
                var result = await _appointmentService.getAppointments();
                var mappedResult = _mapper.Map<List<AppointmentDto>>(result);
                apiResponse.Data = mappedResult;
                apiResponse.Success = true;
            }
            catch (Exception ex)
            {
                apiResponse.Error = ex.Message;
                apiResponse.Success = false;
            }
            return apiResponse;
        }
        [Produces("application/json")]
        [HttpPost, Route("appointment")]
        public async Task<ApiResponse> createAppointments([FromBody] AppointmentDto appointmentDto)
        {
            ApiResponse apiResponse = new ApiResponse();
            try
            {
                var appointmentEntity = _mapper.Map<Appointment>(appointmentDto);
                var result = await _appointmentService.addAppointment(appointmentEntity);
                var mappedResult = _mapper.Map<AppointmentDto>(result);
                apiResponse.Data = mappedResult;
                apiResponse.Success = true;
            }
            catch (Exception ex)
            {
                apiResponse.Error = ex.Message;
                apiResponse.Success = false;
            }

            return apiResponse;
        }

        [Produces("application/json")]
        [HttpPut, Route("appointments")]
        public async Task<ApiResponse> updateAppointments([FromBody] AppointmentDto appointment)
        {
            ApiResponse apiResponse = new ApiResponse();
            try
            {
                var appointmentEntity = _mapper.Map<Appointment>(appointment);
                var result = await _appointmentService.updateAppointment(appointmentEntity);
                var mappedResult = _mapper.Map<Appointment>(result);
                apiResponse.Data = mappedResult;
                apiResponse.Success = true;
            }
            catch (Exception ex)
            {
                apiResponse.Error = ex.Message;
                apiResponse.Success = false;
            }
            return apiResponse;
        }

        [Produces("application/json")]
        [HttpDelete, Route("appointment/id")]
        public async void deleteAppointment(int appointmentId)
        {
            await _appointmentService.deleteAppointment(appointmentId);
        }

        [Produces("application/json")]
        [HttpPost, Route("appointments")]
        public async Task<ApiResponse> getAppointments([FromBody] AppointmentRequestDto appointmentRequestDto)
        {
            ApiResponse apiResponse = new ApiResponse();
            try
            {
                var appointmentEntity = _mapper.Map<Appointment>(appointmentRequestDto);
                var result = await _appointmentService.getAppointments(appointmentEntity);
                var mappedResult = _mapper.Map<List<AppointmentDto>>(result);
                apiResponse.Data = mappedResult;
                apiResponse.Success = true;
            }
            catch (Exception ex)
            {
                apiResponse.Error = ex.Message;
                apiResponse.Success = false;
            }
            return apiResponse;
        }
    }
}
