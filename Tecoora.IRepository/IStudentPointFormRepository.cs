using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tecoora.Models;

namespace Tecoora.IRepository
{
    public interface IStudentPointFormRepository
    {
        Task<StudentPointForm> addStudentPointForm(StudentPointForm studentForm);
        Task<StudentPointForm> updateStudentForm(StudentPointForm studentForm);
        Task deleteStudentForm(int studentFormId);
        Task<List<StudentPointForm>> getStudentForm(int studentId);
    }
}
