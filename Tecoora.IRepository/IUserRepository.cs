using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tecoora.Models;

namespace Tecoora.IRepository
{
    public interface IUserRepository
    {
        Task<User> addUser(User user);
        Task<User> updateUser(User user);
        Task deleteUser(int userId);
        Task<List<User>> getUsers(User user);
        Task<User> getUserById(int id);
        Task<List<User>> getUsersByRole(string role);
        Task updateUserByEmail(string emailId,string otp);
    }
    
}
