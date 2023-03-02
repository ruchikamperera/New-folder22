using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tecoora.IRepository;
using Tecoora.Iservices;
using Tecoora.Models;

namespace Tecoora.Services
{
    public class FileService: IFileService
    {
        IFileRepository _fileRepository;

        public FileService(IFileRepository fileRepository)
        {
            _fileRepository = fileRepository;
        }

        public async Task<List<LawyerRequestedFile>> addLawyerRequestedFiles(List<LawyerRequestedFile> lawyerRequestedFiles)
        {
            var result = await _fileRepository.addLawyerRequestedFiles(lawyerRequestedFiles);
            return result;
        }

        public async Task<List<UserFileDetail>> addUserFileDetails(List<UserFileDetail> userFileDetail)
        {
            var result = await _fileRepository.addUserFileDetails(userFileDetail);
            return result;
        }

        public async Task<UserFileDetail> addUserFileDetails(UserFileDetail userFileDetail)
        {
            var result = await _fileRepository.addUserFileDetails(userFileDetail);
            return result;
        }

        public async Task deleteUserUploadedFile(UserFileDetail userFileDetailsEntity)
        {
            await _fileRepository.deleteUserUploadeFile(userFileDetailsEntity);
        }

        public async Task<List<LawyerRequestedFile>> getFileRequested(LawyerRequestedFile lawyerRequestedFile)
        {
            var result = await _fileRepository.getLawyerRequestedFiles(lawyerRequestedFile);
            return result;
        }

        public async Task<List<UserFileDetail>> getUserUploadedFiles(UserFileDetail userFileEntity)
        {
            var result = await _fileRepository.getUserUploadedFiles(userFileEntity);
            return result;
        }
    }
}
