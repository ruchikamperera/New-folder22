using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tecoora.Models;

namespace Tecoora.IRepository
{
    public interface IReviewRepository
    {
        Task<Review> addReview(Review reviewEntity);
    }
}
