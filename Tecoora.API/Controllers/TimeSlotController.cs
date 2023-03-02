using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tecoora.API.Models;
using Tecoora.API.Responses;
using Tecoora.Iservices;
using Tecoora.Models;

namespace Tecoora.API.Controllers
{
    public class TimeSlotController
    {

        ITimeSlotService _timeSlotService;
        private readonly IMapper _mapper;

        public TimeSlotController(ITimeSlotService timeSlotService, IMapper mapper)
        {
            _timeSlotService = timeSlotService;
            _mapper = mapper;
        }

        [Produces("application/json")]
        [HttpGet, Route("timeslots/lawyerId")]
        public async Task<ApiResponse> getTimeSlotsByLawyerId(int lawyerId)
        {
            ApiResponse apiResponse = new ApiResponse();
            try
            {
                var result = await _timeSlotService.getTimeSlotsByLawyerId(lawyerId);
                var mappedResult = _mapper.Map<List<TimeSlotDto>>(result);
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
        [HttpPost, Route("timeSlots")]
        public async Task<ApiResponse> createTimeSlot([FromBody] TimeSlotDto timeSlotDto)
        {
            ApiResponse apiResponse = new ApiResponse();
            try
            {
                var timeSlotEntity = _mapper.Map<TimeSlot>(timeSlotDto);
                var result = await _timeSlotService.addTimeSlot(timeSlotEntity);
                var mappedResult = _mapper.Map<TimeSlotDto>(result);
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

