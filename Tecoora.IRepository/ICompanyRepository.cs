using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tecoora.Models;

namespace Tecoora.IRepository
{
    public interface ICompanyRepository
    {
        Task<Company> addCompany(Company company);
        Task<Company> updateCompany(Company company);
        Task deleteCompany(int companyId);
        Task<List<Company>> getCompanies();
    }
}
