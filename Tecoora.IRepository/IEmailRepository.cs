using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tecoora.Models;

namespace Tecoora.IRepository
{
    public interface IEmailRepository
    {
       public Task<Email> sendEmail(Email email);
       public Task<List<Email>> getEmailList();

    }
}
