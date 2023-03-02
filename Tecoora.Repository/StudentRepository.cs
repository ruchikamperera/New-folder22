using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tecoora.IRepository;
using Tecoora.Models;
using Tecoora.DataContext;
using Microsoft.EntityFrameworkCore;

namespace Tecoora.Repository
{
    public class StudentRepository : IStudentRepository
    {

        private readonly TecooraContext _context;

        public StudentRepository(TecooraContext context)
        {
            _context = context;
        }

        public async Task<Student> addStudent(Student student)
        {
            await _context.Students.AddAsync(student);
            return student;
        }

        public async Task<List<Student>> getStudents()
        {
            var result= await  _context.Students.ToListAsync();
            return result;
        }

        public Task<Student> updateStudent(Student student)
        {
            throw new NotImplementedException();
        }
    }
}
