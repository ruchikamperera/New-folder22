using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tecoora.IRepository;
using Tecoora.Iservices;
using Tecoora.Models;

namespace Tecoora.Services
{
    public class UserService : IUserService
    {
        IUserRepository _userRepository;
        IEmailRepository _mailRepository;

        public UserService(IUserRepository userRepository, IEmailRepository mailRepository)
        {
            _userRepository = userRepository;
            _mailRepository = mailRepository;
        }

        public async Task<User> addUser(User user)
        {
            var result = await _userRepository.addUser(user);

            if (UserType.STAFF.ToString().Equals(user.UserType)) {

                Email email = new Email();
                email.ToEmail = user.Email;
                email.Content = "You have added as staff member";

                _mailRepository.sendEmail(email);
               
            }
             return result;
        }

        public async Task deleteUser(int userId)
        {
            await _userRepository.deleteUser(userId);
        }

        public async Task<User> getUserById(int id)
        {
            var user = await _userRepository.getUserById(id);
            return user;
        }

       
        public async Task<List<User>> getUsers(User user)
        {
            var users = await _userRepository.getUsers(user);
            return users;
        }

        public async Task<List<User>> getUsersByRole(string role)
        {
            var users = await _userRepository.getUsersByRole(role);
            return users;
        }

        public async Task sendUserToEmailWithOtp(string emailId)
        {
            Email email = new Email();
            email.ToEmail = emailId;
            Random generator = new Random();
            string otp = generator.Next(0, 1000000).ToString("D6");
            email.Content = otp;

            await _mailRepository.sendEmail(email);
            await _userRepository.updateUserByEmail(emailId,otp);
        }

        public async Task<User> updateUser(User user)
        {
            var updatedUser = await _userRepository.updateUser(user);
            return updatedUser;
        }
    }
}
 