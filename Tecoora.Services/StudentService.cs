using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tecoora.IRepository;
using Tecoora.Iservices;
using Tecoora.Models;

namespace Tecoora.Services
{
    public class StudentService : IStudentService
    {
        IStudentRepository _studentRepository;

        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }
        public async Task<Student> addStudent(Student student)
        {
            var result = await _studentRepository.addStudent(student);
            return result;
        }

        public Task<Student> getStudentById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Student>> getStudents()
        {
            var result = await _studentRepository.getStudents();
            return result;
        }

        public Task<Student> updateStudent(Student student)
        {
            throw new NotImplementedException();
        }
    }
}
