using Contracts;
using Entities.Models;
using Service.Contracts;

namespace Service
{
    internal sealed class CompanyService(IRepositoryManager repository) : ICompanyService
    {
        private readonly IRepositoryManager _repository = repository;


        public IEnumerable<Company> GetAllCompanies(bool trackChanges)
        {
            try
            {
                return _repository.Company.GetAllCompanies(trackChanges);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
}
