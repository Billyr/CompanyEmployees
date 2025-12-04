using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Service.Contracts;
using Shared.DataTransferObjects;

namespace Service
{
    internal sealed class EmployeeService : IEmployeeService
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;

        public EmployeeService(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        
        public IEnumerable<EmployeeDto> GetEmployees(Guid companyId, bool trackChanges)
        {
            var company = _repository.Company.GetAllCompanies(trackChanges) ?? throw new CompanyNotFoundException(companyId);

            var employeesFromDb = _repository.Employee.GetEmployees(companyId, trackChanges);
            var employeesDto = _mapper.Map<IEnumerable<EmployeeDto>>(employeesFromDb);
            
            return employeesDto;

        }


        public EmployeeDto GetEmployee(Guid companyId, Guid id, bool trackChanges)
        {
            _ = _repository.Company.GetCompany(companyId, trackChanges) ?? throw new CompanyNotFoundException(companyId);

            var employeeDb = _repository.Employee.GetEmployee(companyId, id, trackChanges) ?? throw new EmployeeNotFoundException(id);

            var employee = _mapper.Map<EmployeeDto>(employeeDb); return employee;
        }



    }
}
