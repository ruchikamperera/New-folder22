using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tecoora.Models;

namespace Tecoora.Iservices
{
    public interface IStudentService
    {
        Task<Student> addStudent(Student student);
        Task<Student> updateStudent(Student student);
        Task<Student> getStudentById(int id);
        Task< List< Student>> getStudents();

    }
}
