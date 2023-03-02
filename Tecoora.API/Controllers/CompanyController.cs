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
    public class CompanyController
    {
        ICompanyService _companyServie;
        private readonly IMapper _mapper;

        public CompanyController(ICompanyService companyService,IMapper mapper) {
            _companyServie = companyService;
            _mapper = mapper;
        }

        [Produces("application/json")]
        [HttpGet, Route("companies")]
        public async Task<ApiResponse> companies() 
        {
            ApiResponse apiResponse = new ApiResponse();
            try
            {
                var result = await _companyServie.getCompanies();
                var mappedResult = _mapper.Map<List<CompanyDto>>(result);
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
        [HttpPost, Route("company")]
        public async Task<ApiResponse> createCompany([FromBody] CompanyDto company) 
        {
            ApiResponse apiResponse = new ApiResponse();
            try
            {
                var companyEntity = _mapper.Map<Company>(company);
                var result = await _companyServie.addCompany(companyEntity);
                var mappedResult = _mapper.Map<CompanyDto>(result);
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
        [HttpPut, Route("company")]
        public async Task<ApiResponse> updateCompany( [FromBody] CompanyDto company)
        {
            ApiResponse apiResponse = new ApiResponse();
            try
            {
                var companyEntity = _mapper.Map<Company>(company);
                var result = await _companyServie.updateCompany(companyEntity);
                var mappedResult = _mapper.Map<CompanyDto>(result);
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
        [HttpDelete, Route("company/id")]
        public async void deleteCompany(int companyId)
        {
            await _companyServie.deleteCompany(companyId);
        }
    }
}
