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

        public CompanyDto GetCompany(Guid companyId, bool trackChanges)
        {
            var company = _repository.Company.GetCompany(companyId, trackChanges);
            var companyDto = _mapper.Map<CompanyDto>(company);

            return companyDto;
        }

        public CompanyDto CreateCompany(CompanyForCreationDto company)
        {
            var companyEntity = _mapper.Map<Company>(company);

            _repository.Company.CreateCompany(companyEntity);
            _repository.Save();

            var companyToReturn = _mapper.Map<CompanyDto>(companyEntity);

            return companyToReturn;
        }



    }
}
