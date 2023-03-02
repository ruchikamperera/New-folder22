using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tecoora.Models;

namespace Tecoora.IRepository
{
    public interface IStudentRepository
    {
        Task<Student> addStudent(Student student);
        Task<Student> updateStudent(Student student);
        Task< List< Student>> getStudents();

    }
}
