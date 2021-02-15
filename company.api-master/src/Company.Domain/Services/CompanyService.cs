using Company.Domain.Service.Define;
using Company.Domain.Repositories;
using Company.Domain.Constant;
using Company.Domain.Request;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System;

namespace Company.Domain.Service
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IBranchRepository _branchRepository;
        private readonly IApplicationContext _applicationContext;


        public CompanyService(ICompanyRepository companyRepository, IBranchRepository branchRepository, IApplicationContext applicationContext)
        {
            _companyRepository = companyRepository;
            _branchRepository = branchRepository;
            _applicationContext = applicationContext;
        }

        public async Task<object> CreateCompanyAsync(CreateCompanyRequest request)
        {
            var result = await _companyRepository.CreateCompanyAsync(request);

            var newResult = await _branchRepository.CreateBranchAsync(new CreateBranchRequest() { Name = request.Name + " " + AutoBranch.FirstNameBranch, CompanyId = result, Active = true, Order = 1, CreatedBy = _applicationContext.UserId });

            return  JsonConvert.SerializeObject(result);
        }

        public async Task<object> CreateAsync(CreateCompanyRegisterRequest request)
        {
            var reqDTo = new CreateCompanyRequest 
            {
                Name = request.Name,
                TradeRegisterNo = "00000000",
                Logo = string.Empty,
                CreatedBy = _applicationContext.UserId,
                CreatedDate = DateTime.UtcNow
            };
            var result = await _companyRepository.CreateCompanyAsync(reqDTo);

            var newResult = await _branchRepository.CreateBranchAsync(new CreateBranchRequest 
            {
                 Name = request.Name + " " + AutoBranch.FirstNameBranch, 
                 CompanyId = result, 
                 Active = true, Order = 1,
                 CityId = request.CountyId,
                 DistrictId = request.DistrcitId,
                 CreatedBy = _applicationContext.UserId,
                 CreatedDate = DateTime.UtcNow
            });

            return  JsonConvert.SerializeObject(result);
        }
    }
}
