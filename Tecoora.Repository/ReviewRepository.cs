using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tecoora.DataContext;
using Tecoora.IRepository;
using Tecoora.Models;

namespace Tecoora.Repository
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly TecooraContext _context;
        public ReviewRepository(TecooraContext context)
        {
            _context = context;
        }

        public async Task<Review> addReview(Review reviewEntity)
        {
            await _context.Reviews.AddAsync(reviewEntity);
            _context.SaveChanges();
            return reviewEntity;
        }

    }
}
