using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tecoora.Models;

namespace Tecoora.Iservices
{
    public interface IStaffService
    {
        Task<Staff> addStaff(Staff staff);
        Task<Staff> updateStaff(Staff staff);
        Task deleteStaff(int staffId);
        Task<List<Staff>> getStaff();
    }
}
