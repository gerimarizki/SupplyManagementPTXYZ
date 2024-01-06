using SupplyManagement.Contracts;
using SupplyManagement.DTOs.Vendor;
using SupplyManagement.Models;
using SupplyManagement.Repositories;

namespace SupplyManagement.Services
{
    public class VendorServices
    {
        private readonly IVendorRepository _vendorRepository;

        public VendorServices(IVendorRepository vendorRepository)
        {
            _vendorRepository = vendorRepository;
        }


        public IEnumerable<GetVendorDTO>? GetVendor()
        {
            var vendor = _vendorRepository.GetAll();
            if (!vendor.Any())
            {
                return null; // No manager found
            }

            var toDto = vendor.Select(vendor =>
                                                new GetVendorDTO
                                                {
                                                    VendorID = vendor.VendorID,
                                                    VendorName = vendor.VendorName,
                                                    BusinessType = vendor.BusinessType,
                                                    CompanyType = vendor.CompanyType,
                                                    UserID = vendor.UserID,

                                                }).ToList();

            return toDto; // manager found
        }

        public GetVendorDTO? GetVendorID(int id)
        {
            var vendor = _vendorRepository.GetById(id);
            if (vendor is null)
            {
                return null; // Vendor not found
            }

            var toDto = new GetVendorDTO
            {
                VendorID = vendor.VendorID,
                VendorName = vendor.VendorName,
                BusinessType = vendor.BusinessType,
                CompanyType = vendor.CompanyType,
                UserID = vendor.UserID,
            };

            return toDto; // Vendor found
        }

        public GetVendorDTO? CreateCompany(NewVendorDTO newvVendorDTO)
        {
            var vendor = new Vendor
            {
                VendorID = newvVendorDTO.VendorID,
                VendorName = newvVendorDTO.VendorName,
                BusinessType = newvVendorDTO.BusinessType,
                CompanyType = newvVendorDTO.CompanyType,
                UserID = newvVendorDTO.UserID,
            };

            var createdVendor = _vendorRepository.Create(vendor);
            if (createdVendor is null)
            {
                return null; // Vendor not created
            }

            var toDto = new GetVendorDTO
            {
                VendorID = vendor.VendorID,
                VendorName = vendor.VendorName,
                BusinessType = vendor.BusinessType,
                CompanyType = vendor.CompanyType,
                UserID = vendor.UserID,
            };

            return toDto; // Vendor created
        }

        public int UpdateCompany(UpdateVendorDTO updateVendorDTO)
        {
            var isExist = _vendorRepository.IsExist(updateVendorDTO.VendorID);
            if (!isExist)
            {
                return -1; // Vendor Not Found
            }

            var getVendor = _vendorRepository.GetById(updateVendorDTO.VendorID);

            var vendor = new Vendor
            {
                VendorID = updateVendorDTO.VendorID,
                VendorName = updateVendorDTO.VendorName,
                BusinessType = updateVendorDTO.BusinessType,
                CompanyType = updateVendorDTO.CompanyType,
                UserID = updateVendorDTO.UserID,
            };

            var isUpdate = _vendorRepository.Update(vendor);
            if (!isUpdate)
            {
                return 0; // company not updated
            }
            return 1;
        }

        public int DeleteVendor(int id)
        {
            var isExist = _vendorRepository.IsExist(id);
            if (!isExist)
            {
                return -1; // company not found
            }

            var vendor = _vendorRepository.GetById(id);
            var isDelete = _vendorRepository.Delete(vendor);
            if (!isDelete)
            {
                return 0; // company not deleted
            }

            return 1;
        }
    }
}
