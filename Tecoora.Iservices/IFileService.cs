using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tecoora.Models;

namespace Tecoora.Iservices
{
    public interface IFileService
    {
        Task<List<LawyerRequestedFile>> addLawyerRequestedFiles(List<LawyerRequestedFile> lawyerRequestedFiles);
        Task<List<LawyerRequestedFile>> getFileRequested(LawyerRequestedFile lawyerRequestedFile);
        Task<List<UserFileDetail>> addUserFileDetails(List<UserFileDetail> userFileDetail);
        Task<UserFileDetail> addUserFileDetails(UserFileDetail userFileDetail);
        Task <List<UserFileDetail>> getUserUploadedFiles(UserFileDetail userFileEntity);
        Task deleteUserUploadedFile(UserFileDetail userFileDetailsEntity);
    }
}
