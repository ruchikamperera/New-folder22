using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tecoora.IRepository;
using Tecoora.Iservices;
using Tecoora.Models;

namespace Tecoora.Services
{
    public class CompanyService : ICompanyService
    {
        ICompanyRepository _companyRepository;
        public CompanyService(ICompanyRepository companyrepository) {
            _companyRepository = companyrepository;
        }
        public async Task<Company> addCompany(Company company)
        {
            var result = await _companyRepository.addCompany(company);
            return result;
        }

        public async Task deleteCompany(int companyId)
        {
            await _companyRepository.deleteCompany(companyId);
        }

        public async Task<List<Company>> getCompanies()
        {
            var companies = await _companyRepository.getCompanies();
            return companies;
        }

        public async Task<Company> updateCompany(Company company)
        {
            var updatedCompany = await _companyRepository.updateCompany(company);
            return updatedCompany;
        }
    }
}
