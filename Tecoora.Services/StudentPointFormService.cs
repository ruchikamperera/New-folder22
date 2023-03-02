using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tecoora.IRepository;
using Tecoora.Iservices;
using Tecoora.Models;

namespace Tecoora.Services
{
    public class StudentPointFormService : IStudentPointFormService
    {
        IStudentPointFormRepository _studentFormRepository;

        public StudentPointFormService(IStudentPointFormRepository studentFormRepository)
        {
            _studentFormRepository = studentFormRepository;
        }

        public async Task<StudentPointForm> addStudentPointForm(StudentPointForm studentForm)
        {
            var result = await _studentFormRepository.addStudentPointForm(studentForm);
            return result;
        }

        public async Task deleteStudentForm(int studentFormId)
        {
            await _studentFormRepository.deleteStudentForm(studentFormId);
        }

        public async Task<List<StudentPointForm>> getStudentForm(int studentId)
        {
            var studentForms = await _studentFormRepository.getStudentForm(studentId);
            return studentForms;
        }

        public async Task<StudentPointForm> updateStudentForm(StudentPointForm studentForm)
        {
            var updatedStudentForm = await _studentFormRepository.updateStudentForm(studentForm);
            return updatedStudentForm;
        }
    }
}
