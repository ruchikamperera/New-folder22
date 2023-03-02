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
    public class StudentPointFormRepository : IStudentPointFormRepository
    {
        private readonly TecooraContext _context;

        public StudentPointFormRepository(TecooraContext context)
        {
            _context = context;
        }

        public async Task<StudentPointForm> addStudentPointForm(StudentPointForm studentForm)
        {
            var existingStuedntForm = await _context.StudentPointForms.Where(s => s.StudentUserId.Equals(studentForm.StudentUserId) && s.FormTypeId.Equals(studentForm.FormTypeId)).ToListAsync();

            int lastAttempt = 0;

            if (existingStuedntForm != null && existingStuedntForm.Count !=0)
            {
                foreach (StudentPointForm studentPointForm in existingStuedntForm) {
                    lastAttempt = Math.Max(lastAttempt, studentPointForm.Attempt);
                }
                if (lastAttempt < 3)
                {
                    studentForm.Attempt = lastAttempt + 1;
                    await _context.StudentPointForms.AddAsync(studentForm);
                    _context.SaveChanges();
                    return studentForm;
                }
                else 
                {
                    throw new NotImplementedException();
                    //TODO throw Bad exception attempt already completed
                }
            }
            else
            {
                studentForm.Attempt = 1;
                await _context.StudentPointForms.AddAsync(studentForm);
                _context.SaveChanges();
                return studentForm;
            }
        }

        public async Task deleteStudentForm(int studentFormId)
        {
            var studentForm = await _context.StudentPointForms.FindAsync(studentFormId);
            _context.StudentPointForms.Remove(studentForm);
            _context.SaveChanges();
        }

        public async Task<List<StudentPointForm>> getStudentForm(int studentId)
        {
            var studentForms = await _context.StudentPointForms.Where(s => s.StudentUserId.Equals(studentId)).ToListAsync();
            if (studentForms != null)
            {
                foreach (var studentForm in studentForms)
                {
                    var criterias = await _context.Criterias.Where(c => c.StudentFormId.Equals(studentForm.Id)).ToListAsync();
                    studentForm.Criterias = criterias;
                }
            }
            return studentForms;
        }

        public async Task<StudentPointForm> updateStudentForm(StudentPointForm studentForm)
        {
            var existingStudentForm = await _context.StudentPointForms.FindAsync(studentForm.Id);

            studentForm.CreateLawyerId = studentForm.CreateLawyerId;
            //TODO updated property
            _context.SaveChanges();
            return studentForm;
        }
    }
}
