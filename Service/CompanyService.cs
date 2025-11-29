using AutoMapper;
using Contracts;
using Entities.Models;
using Service.Contracts;
using Shared.DataTransferObjects;

namespace Service
{
    internal sealed class CompanyService(IRepositoryManager repository, IMapper mapper) : ICompanyService
    {
        private readonly IRepositoryManager _repository = repository;
        private readonly IMapper _mapper = mapper;

        public IEnumerable<CompanyDto> GetAllCompanies(bool trackChanges)
        {
            //var companiesDto = companies
            //    .Select(c => new CompanyDto(c.Id, c.Name ?? "", string.Join(' ', c.Address, c.Country)))
            //    .ToList();

            var companies = _repository.Company.GetAllCompanies(trackChanges);
            var companiesDto = _mapper.Map<IEnumerable<CompanyDto>>(companies);

            return companiesDto;
            
        }

    }
}
