using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Tecoora.API.Models;
using Tecoora.API.Responses;
using Tecoora.Iservices;
using Tecoora.Models;

namespace Tecoora.API.Controllers
{
    public class ReviewController
    {
        IReviewService _reviewService;
        private readonly IMapper _mapper;

        public ReviewController(IReviewService reviewService, IMapper mapper)
        {
            _reviewService = reviewService;
            _mapper = mapper;
        }

        [Produces("application/json")]
        [HttpPost, Route("reviews")]
        public async Task<ApiResponse> createReview([FromBody] ReviewDto review)
        {
            ApiResponse apiResponse = new ApiResponse();
            try
            {
                var reviewEntity = _mapper.Map<Review>(review);
                var result = await _reviewService.addReview(reviewEntity);
                var mappedResult = _mapper.Map<ReviewDto>(result);
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
