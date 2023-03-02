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
    public class UserController: Controller
    {
        IUserService _userService;
        private readonly IMapper _mapper;

        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [Produces("application/json")]
        [HttpPost, Route("users")]
        public async Task<ApiResponse> users([FromBody] UserRequestDto userRequestDto)
        {
            ApiResponse apiResponse = new ApiResponse();
            try
            {
                var userEntity = _mapper.Map<User>(userRequestDto);
                var result = await _userService.getUsers(userEntity);
                var mappedResult = _mapper.Map<List<UserDto>>(result);
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
        [HttpGet, Route("testAPI/{id:int}")]
        public async Task<ApiResponse> testAPIByRuchika(int id)
        {
            ApiResponse apiResponse = new ApiResponse();
            try
            {
                var result = await _userService.getUserById(id);
                var mappedResult = _mapper.Map<UserDto>(result);
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
        [HttpGet, Route("users/{id:int}")]
        public async Task<ApiResponse> usersById(int id)
        {
            ApiResponse apiResponse = new ApiResponse();
            try 
            {
                var result = await _userService.getUserById(id);
                var mappedResult = _mapper.Map<UserDto>(result);
                apiResponse.Data = mappedResult;
                apiResponse.Success = true;
            } catch (Exception ex) 
            {
                apiResponse.Error = ex.Message;
                apiResponse.Success = false;
            }
            
            return apiResponse;
        }

        [Produces("application/json")]
        [HttpGet, Route("usersbyroleid/{role}")]
        public async Task<ApiResponse> usersByRoleId(string role)
        {
            ApiResponse apiResponse = new ApiResponse();
            try
            {
                var result = await _userService.getUsersByRole(role);
                var mappedResult = _mapper.Map<List<UserDto>>(result);
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
        [HttpPost,Route("signUp")]
        public async Task<ApiResponse> createUser([FromBody] UserDto user)
        {
            ApiResponse apiResponse = new ApiResponse();
            try
            {
                var userEntity = _mapper.Map<User>(user);
                var result = await _userService.addUser(userEntity);
                var mappedResult = _mapper.Map<UserDto>(result);
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
        [HttpPut, Route("user")]
        public async Task<ApiResponse> updateuser([FromBody] UserDto user)
        {
            ApiResponse apiResponse = new ApiResponse();
            try
            {
                var userentity = _mapper.Map<User>(user);
                var result = await _userService.updateUser(userentity);
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
        [HttpDelete, Route("user/id")]
        public async void deleteUser(int userId)
        {
            await _userService.deleteUser(userId);
        }

        [Produces("application/json")]
        [HttpPost, Route("login")]
        public async Task<ApiResponse> userSignIn([FromBody] UserLoginDto userLoginInfo)
        {
            ApiResponse apiResponse = new ApiResponse();
            try
            {
                var userentity = _mapper.Map<User>(userLoginInfo);
                User user = new User();
                user.Email = "ruchika@outlook.com";
                user.FirstName = "ruchika";
                user.Token = "eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJpc3MiOiJPbmxpbmUgSldUIEJ1aWxkZXIiLCJpYXQiOjE2NzY3ODU2OTgsImV4cCI6MTcwODMyMTY5OCwiYXVkIjoid3d3LmV4YW1wbGUuY29tIiwic3ViIjoianJvY2tldEBleGFtcGxlLmNvbSIsIkdpdmVuTmFtZSI6IkpvaG5ueSIsIlN1cm5hbWUiOiJSb2NrZXQiLCJFbWFpbCI6Impyb2NrZXRAZXhhbXBsZS5jb20iLCJSb2xlIjpbIk1hbmFnZXIiLCJQcm9qZWN0IEFkbWluaXN0cmF0b3IiXX0._j0jrDWueHQjcFvr-0vnHrrnvO3t5QS6lF-aXoJLKU4";
                var result = "access tocken";
               // await _userService.(userentity);
                var mappedresult = _mapper.Map<string>(result);
                apiResponse.Success = true;
                apiResponse.Data = user;
            }
            catch (Exception ex)
            {
                apiResponse.Error = ex.Message;
                apiResponse.Success = false;
            }
            return apiResponse;
        }

        [Produces("application/json")]
        [HttpGet, Route("{email}/sendOtp")]
        public async Task<ApiResponse> sendOtpToEmail(string email)
        {
            ApiResponse apiResponse = new ApiResponse();
            try
            {
                await _userService.sendUserToEmailWithOtp(email);
               
                apiResponse.Data = "Check your email";
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
