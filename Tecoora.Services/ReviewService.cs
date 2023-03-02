using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tecoora.IRepository;
using Tecoora.Iservices;
using Tecoora.Models;

namespace Tecoora.Services
{
    public class ReviewService: IReviewService
    {
        IReviewRepository _reviewRepository;
        public ReviewService(IReviewRepository reviewRepository)
        {
            _reviewRepository = reviewRepository;
        }

        public async Task<Review> addReview(Review reviewEntity)
        {
            var result = await _reviewRepository.addReview(reviewEntity);
            return result;
        }
    }
}
