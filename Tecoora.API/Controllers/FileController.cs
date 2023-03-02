using AutoMapper;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Tecoora.API.Models;
using Tecoora.API.Responses;
using Tecoora.Iservices;
using Tecoora.Models;

namespace Tecoora.API.Controllers
{
    public class FileController : Controller
    {
        IFileService _fileService;
        private readonly IMapper _mapper;
        private readonly string _azureConnectionString;


        public FileController(IFileService fileService,IMapper mapper, IConfiguration configuration) 
        { 
            _fileService = fileService;
            _mapper = mapper;
            _azureConnectionString = configuration.GetConnectionString("AzureConnectionString");
        }

        [Produces("application/json")]
        [HttpPost, Route("lawyerRequestedFiles")]
        public async Task<ApiResponse> addLawyerRequestedFiles([FromBody] List<LawyerRequestedFileDto> lawyerRequestdFiles)
        {
            ApiResponse apiResponse = new ApiResponse();
            try
            {
                var lawyerRequestedFileEntitiyes = _mapper.Map<List<LawyerRequestedFile>>(lawyerRequestdFiles);
                var result = await _fileService.addLawyerRequestedFiles(lawyerRequestedFileEntitiyes);
                var mappedResult = _mapper.Map<List<LawyerRequestedFileDto>>(result);
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
        [HttpPost, Route("getUserRequestedFiles")]
        public async Task<ApiResponse> getUserRequestedFiles([FromBody] FileRequestDto fileRequest)
        {
            ApiResponse apiResponse = new ApiResponse();
            try
            {
                var lawyerRequestedFileEntity = _mapper.Map<LawyerRequestedFile>(fileRequest);
                var result = await _fileService.getFileRequested(lawyerRequestedFileEntity);
                var mappedResult = _mapper.Map<List<LawyerRequestedFileDto>>(result);
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
        [HttpPost, Route("studentFileUpload")]
        public async Task<ApiResponse> addUserFileDetail([FromBody] List<UserFileDetailDto> userFileDetail)
        {
            ApiResponse apiResponse = new ApiResponse();
            try
            {
                var userFileDetailsEntity = _mapper.Map<List<UserFileDetail>>(userFileDetail);
                var result = await _fileService.addUserFileDetails(userFileDetailsEntity);
                var mappedResult = _mapper.Map<List<UserFileDetailDto>>(result);
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
        [HttpPost, Route("getUserUploadedFile")]
        public async Task<ApiResponse> getUserUploadedFiles([FromBody] FileRequestDto fileRequest)
        {
            ApiResponse apiResponse = new ApiResponse();
            try
            {
                var userFileEntity = _mapper.Map<UserFileDetail>(fileRequest);
                var result = await _fileService.getUserUploadedFiles(userFileEntity);
                var mappedResult = _mapper.Map<List<UserFileDetailDto>>(result);
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


        [HttpPost(nameof(userFileUpload))]
        public async Task<string> userFileUpload(IFormFile file)
        {
            try
            {
                var container = new BlobContainerClient(_azureConnectionString, "tecoora-files");
                var stream = new MemoryStream();
                await file.CopyToAsync(stream);
                stream.Position = 0;
                string extension = Path.GetExtension(file.FileName);
                string fileName = Guid.NewGuid().ToString() + extension;
                await container.UploadBlobAsync(fileName, stream);
                container.Uri.ToString();
                string fileUrl = container.Uri.ToString() +"/"+fileName;
                return fileUrl;
            }
            catch (Exception ex)
            {
                return "Internal server error:" + ex;
            }          
        }


        [Produces("application/json")]
        [HttpDelete, Route("userUploadedFile")]
        public async Task<ApiResponse> deleteUserUploadedFile([FromBody] UserFileDetailDto userFileDetail)
        {
            ApiResponse apiResponse = new ApiResponse();
            try
            {
                var userFileDetailsEntity = _mapper.Map<UserFileDetail>(userFileDetail);
                await _fileService.deleteUserUploadedFile(userFileDetailsEntity);
                
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
