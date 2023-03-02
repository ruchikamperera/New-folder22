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
    public class CompanyRepository: ICompanyRepository
    {
        private readonly TecooraContext _context;
        public CompanyRepository(TecooraContext context) {
            _context = context;
        }

        public async Task<Company> addCompany(Company company)
        {
            await _context.Companies.AddAsync(company);
            return company;
        }

        public async Task deleteCompany(int companyId)
        {
            var company = await _context.Companies.FindAsync(companyId);
            _context.Companies.Remove(company);
            _context.SaveChanges();
        }

        public async Task<List<Company>> getCompanies()
        {
            var companies = await _context.Companies.ToListAsync();
            return companies;   
        }

        public async Task<Company> updateCompany(Company company)
        {
            var existingCompany = await _context.Companies.FindAsync(company.Id);

            existingCompany.Email = company.Email;
            existingCompany.Name = company.Name;
            //TODO updated property
            _context.SaveChanges();
            return company;
        }
    }
}
