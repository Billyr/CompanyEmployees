using Contracts;
using Service.Contracts;

namespace Service
{
    internal sealed class CompanyService(IRepositoryManager repository) : ICompanyService
    {
        private readonly IRepositoryManager _repository = repository;
    }
}
