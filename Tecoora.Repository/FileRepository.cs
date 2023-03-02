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
    public class FileRepository: IFileRepository
    {
        private readonly TecooraContext _context;

        public FileRepository(TecooraContext context)
        {
            _context = context;
        }

        public async Task<List<LawyerRequestedFile>> addLawyerRequestedFiles(List<LawyerRequestedFile> lawyreRequestedFiles)
        {
            await _context.LawyerRequestedFiles.AddRangeAsync(lawyreRequestedFiles);
            _context.SaveChanges();
            return lawyreRequestedFiles;
        }

        public async Task<List<UserFileDetail>> addUserFileDetails(List<UserFileDetail> userFileDetail)
        {
            await _context.UserFileDetails.AddRangeAsync(userFileDetail);
            _context.SaveChanges();
            return userFileDetail;
        }

        public async Task<UserFileDetail> addUserFileDetails(UserFileDetail userFileDetail)
        {
            await _context.UserFileDetails.AddAsync(userFileDetail);
            _context.SaveChanges();
            return userFileDetail;
        }

        public async Task deleteUserUploadeFile(UserFileDetail userFileDetailsEntity)
        {
            var userUploadedFile = await _context.UserFileDetails.Where(file => file.LawyerId.Equals(userFileDetailsEntity.LawyerId) && file.StudentId.Equals(userFileDetailsEntity.StudentId) && file.FileType.Equals(userFileDetailsEntity.FileType)).FirstAsync();
            _context.UserFileDetails.Remove(userUploadedFile);
            _context.SaveChanges();
        }

        public async Task<List<LawyerRequestedFile>> getLawyerRequestedFiles(LawyerRequestedFile lawyreRequestedFile)
        {
            List<LawyerRequestedFile> requestedFiles = await _context.LawyerRequestedFiles.Where(file => file.LawyerId.Equals(lawyreRequestedFile.LawyerId) && file.StudentId.Equals(lawyreRequestedFile.StudentId)).ToListAsync();
            return requestedFiles;
        }

        public async Task<List<UserFileDetail>> getUserUploadedFiles(UserFileDetail userFileEntity)
        {
            List<UserFileDetail> userUploadedFiles = await _context.UserFileDetails.Where(file => file.LawyerId.Equals(userFileEntity.LawyerId) && file.StudentId.Equals(userFileEntity.StudentId)).ToListAsync();
            return userUploadedFiles;
        }
    }
}
