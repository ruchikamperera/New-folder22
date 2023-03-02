using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tecoora.Models;

namespace Tecoora.Iservices
{
    public interface IReviewService
    {
        Task<Review> addReview(Review reviewEntity);
    }
}
