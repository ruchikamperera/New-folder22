using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tecoora.DataContext;
using Tecoora.IRepository;
using Tecoora.Models;

namespace Tecoora.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly TecooraContext _context;

        public UserRepository(TecooraContext context)
        {
            _context = context;
        }
        public async Task<User> addUser(User user)
        {
            if (user.AccessArea != null && user.AccessArea.Count != 0) {
                string accessAreas = string.Join(",", user.AccessArea);
                user.AccessAreas = accessAreas;
            }
            
            await _context.Users.AddAsync(user);
            _context.SaveChanges();
            return user;
        }

        public async Task deleteUser(int userId)
        {
            var user = await _context.Users.FindAsync(userId);
            _context.Users.Remove(user);
            _context.SaveChanges();
        }

        public async Task<User> getUserById(int id)
        {
            var user = await _context.Users.FindAsync(id);
            List<Review> review = await _context.Reviews.Where(r => r.LawyerId.Equals(id)).ToListAsync();
            user.Reviews = review;
            return user;
        }

        public async Task<List<User>> getUsers(User user)
        {
            string type = user.UserType;
            string search = user.search;
            string sortBy = user.sortBy;
            string email = user.Email;
            string OTP = user.OTP;
            List<User> users;

            if (type != null && search == null && email== null)
            {
                users = await _context.Users.Where(u => u.UserType.Equals(type)).ToListAsync();
            }
            else if (type == null && search != null&& email== null)
            {
                users = await _context.Users.Where(u=>u.FirstName.Contains(search) ||u.LastName.Contains(search)|| u.State.Contains(search)).ToListAsync();
            }
            else if (type != null && search != null && email== null) 
            {
                users = await _context.Users.Where(u => u.UserType.Equals(type) && (u.FirstName.Contains(search) || u.LastName.Contains(search) || u.State.Contains(search))).ToListAsync();
            }
            else if (type == null && search == null && email != null && OTP == null)
            {
                users = await _context.Users.Where(u => u.Email.Equals(email)).ToListAsync();
            }
            else if (type == null && search == null && email != null && OTP != null)
            {
                users = await _context.Users.Where(u => u.OTP.Equals(OTP) && u.Email.Equals(email)).ToListAsync();
            }
            else
            {
                users = await _context.Users.ToListAsync();
            }

            if (sortBy != null) {
                switch (sortBy)
                {
                    case "noOfReviews":
                        users = users.OrderByDescending(u => u.noOfReviews).ToList();
                        break;
                    case "yearsOfExperience":
                        users = users.OrderByDescending(u => u.yearsOfExperience).ToList();
                        break;
                    default:
                        break;
                }
            }
            return users;
        }

        public async Task<List<User>> getUsersByRole(string role)
        {
           var users = await _context.Users.Where(u => u.UserType== role).ToListAsync();
            return users;

        }

        public async Task<User> updateUser(User user)
        {
            var existingUser = await _context.Users.FindAsync(user.Id);

            existingUser.Email = user.Email;
            existingUser.FirstName = user.FirstName;
            existingUser.CompanyName = user.CompanyName;
            existingUser.LastName = user.LastName;
            existingUser.State = user.State;
            existingUser.ChargingForExtraMin = user.ChargingForExtraMin;
            existingUser.ConsultationFeeForHalfAndHour = user.ConsultationFeeForHalfAndHour;
            existingUser.ConsultationFeeForOneHour = user.ConsultationFeeForOneHour;
            existingUser.Password = user.Password;
            existingUser.ConfirmPassword = user.ConfirmPassword;
            existingUser.ChargeForExtraMinutes = user.ChargeForExtraMinutes;
            existingUser.PhoneNumber = user.PhoneNumber;
            existingUser.Gender = user.Gender;
            existingUser.ShortDescription = user.ShortDescription;
            existingUser.ServiceDescription = user.ServiceDescription;
            existingUser.ProfileImageUrl = user.ProfileImageUrl;
            existingUser.Rating = user.Rating;
            _context.SaveChanges();
            return user;
        }

        public async Task updateUserByEmail(string emailId,string otp)
        {
            var existingUser = await _context.Users.Where(u => u.Email == emailId).FirstAsync();

            existingUser.OTP = otp;
            _context.SaveChanges();
        }
    }
}
