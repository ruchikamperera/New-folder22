using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tecoora.Models;

namespace Tecoora.IRepository
{
    public interface IFileRepository
    {
        Task<List<LawyerRequestedFile>> addLawyerRequestedFiles(List<LawyerRequestedFile> lawyreRequestedFiles);
        Task<List<LawyerRequestedFile>> getLawyerRequestedFiles(LawyerRequestedFile lawyreRequestedFile);
        Task<List<UserFileDetail>> addUserFileDetails(List<UserFileDetail> userFileDetail);
        Task<UserFileDetail> addUserFileDetails(UserFileDetail userFileDetail);
        Task <List<UserFileDetail>> getUserUploadedFiles(UserFileDetail userFileEntity);
        Task deleteUserUploadeFile(UserFileDetail userFileDetailsEntity);
    }
}
