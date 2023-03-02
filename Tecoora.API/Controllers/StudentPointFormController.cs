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
    public class StudentPointFormController
    {
        IStudentPointFormService _studentFormServie;
        private readonly IMapper _mapper;

        public StudentPointFormController(IStudentPointFormService studentFormServie, IMapper mapper)
        {
            _studentFormServie = studentFormServie;
            _mapper = mapper;
        }

        [Produces("application/json")]
        [HttpGet, Route("studentPointForms/studentId")]
        public async Task<ApiResponse> studentForms(int studentId)
        {
            ApiResponse apiResponse = new ApiResponse();
            try
            {
                var result = await _studentFormServie.getStudentForm(studentId);
                var mappedResult = _mapper.Map<List<StudentPointFormDto>>(result);
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
        [HttpPost, Route("studentPointForms")]
        public async Task<ApiResponse> createStudentForm([FromBody] StudentPointFormDto studentForm)
        {
            ApiResponse apiResponse = new ApiResponse();
            try
            {
                var studentFormEntity = _mapper.Map<StudentPointForm>(studentForm);
                var result = await _studentFormServie.addStudentPointForm(studentFormEntity);
                var mappedResult = _mapper.Map<StudentPointFormDto>(result);
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
        [HttpPut, Route("studentPointForms")]
        public async Task<ApiResponse> upateStudentForms(StudentPointFormDto studentForm)
        {
            ApiResponse apiResponse = new ApiResponse();
            try
            {
                var studentFormEntity = _mapper.Map<StudentPointForm>(studentForm);
                var result = await _studentFormServie.updateStudentForm(studentFormEntity);
                var mappedresult = _mapper.Map<UserDto>(result);
            }
            catch (Exception ex)
            {
                apiResponse.Error = ex.Message;
                apiResponse.Success = false;
            }
            return apiResponse;
        }

        [Produces("application/json")]
        [HttpDelete, Route("studentPointForms/id")]
        public async void deleteStudentForm(int studentFormId)
        {
            await _studentFormServie.deleteStudentForm(studentFormId);
        }
    }
}
