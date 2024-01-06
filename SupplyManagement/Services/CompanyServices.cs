using SupplyManagement.Contracts;
using SupplyManagement.DTOs.Company;
using SupplyManagement.Models;

namespace SupplyManagement.Services
{
    public class CompanyServices
    {
        private readonly ICompanyRepository _companyRepository;

        public CompanyServices(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;

        }

        public IEnumerable<GetCompanyDTO>? GetCompany()
        {
            var company = _companyRepository.GetAll();
            if (!company.Any())
            {
                return null; // No manager found
            }

            var toDto = company.Select(company =>
                                                new GetCompanyDTO
                                                {
                                                    CompanyID = company.CompanyID,
                                                    CompanyName = company.CompanyName,
                                                    CompanyEmail = company.CompanyEmail,
                                                    CompanyPhoneNumber = company.CompanyPhoneNumber,
                                                    CompanyPhoto = company.CompanyPhoto,
                                                    ApprovalStatus = company.ApprovalStatus,

                                                }).ToList();

            return toDto; // manager found
        }

        public GetCompanyDTO? GetCompanyID(int id)
        {
            var company = _companyRepository.GetById(id);
            if (company is null)
            {
                return null; // company not found
            }

            var toDto = new GetCompanyDTO
            {
                CompanyID = company.CompanyID,
                CompanyName = company.CompanyName,
                CompanyEmail = company.CompanyEmail,
                CompanyPhoneNumber = company.CompanyPhoneNumber,
                CompanyPhoto = company.CompanyPhoto,
                ApprovalStatus = company.ApprovalStatus,
            };

            return toDto; // company found
        }

        public GetCompanyDTO? CreateCompany(NewCompanyDTO newCompanyDTO)
        {
            var company = new Company
            {
                CompanyName = newCompanyDTO.CompanyName,
                CompanyEmail = newCompanyDTO.CompanyEmail,
                CompanyPhoneNumber = newCompanyDTO.CompanyPhoneNumber,
                CompanyPhoto = newCompanyDTO.CompanyPhoto,
                ApprovalStatus = newCompanyDTO.ApprovalStatus,
            };

            var createdCompany = _companyRepository.Create(company);
            if (createdCompany is null)
            {
                return null; // Company not created
            }

            var toDto = new GetCompanyDTO
            {
                CompanyID = company.CompanyID,
                CompanyName = company.CompanyName,
                CompanyEmail = company.CompanyEmail,
                CompanyPhoneNumber = company.CompanyPhoneNumber,
                CompanyPhoto = company.CompanyPhoto,
                ApprovalStatus = company.ApprovalStatus,
            };

            return toDto; // Company created
        }

        public int UpdateCompany(UpdateCompanyDTO updateCompanyDTO)
        {
            var isExist = _companyRepository.IsExist(updateCompanyDTO.CompanyID);
            if (!isExist)
            {
                return -1; // Company Not Found
            }

            var getCompany = _companyRepository.GetById(updateCompanyDTO.CompanyID);

            var company = new Company
            {
                CompanyName = updateCompanyDTO.CompanyName,
                CompanyEmail = updateCompanyDTO.CompanyEmail,
                CompanyPhoneNumber = updateCompanyDTO.CompanyPhoneNumber,
                CompanyPhoto = updateCompanyDTO.CompanyPhoto,
                ApprovalStatus = updateCompanyDTO.ApprovalStatus,
            };

            var isUpdate = _companyRepository.Update(company);
            if (!isUpdate)
            {
                return 0; // company not updated
            }

            return 1;
        }

        public int DeleteCompany(int id)
        {
            var isExist = _companyRepository.IsExist(id);
            if (!isExist)
            {
                return -1; // company not found
            }

            var company = _companyRepository.GetById(id);
            var isDelete = _companyRepository.Delete(company);
            if (!isDelete)
            {
                return 0; // company not deleted
            }

            return 1;
        }
    }
}
