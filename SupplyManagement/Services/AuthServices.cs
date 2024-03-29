﻿using SupplyManagement.Contracts;
using SupplyManagement.Data;
using SupplyManagement.DTOs.Authorize;
using SupplyManagement.DTOs.Vendor;
using SupplyManagement.Models;
using System.Security.Claims;

namespace SupplyManagement.Services
{
    public class AuthenticationServices
    {
        private readonly BookingDbContext _bookingDbContext;
        private readonly ICompanyRepository _companyRepository;
        private readonly IUserRepository _userRepository;
        private readonly IManagerLogistic _managerLogistic;
        private readonly IVendorRepository _vendorRepository;
        private readonly ITokenHandler _tokenHandler;

        public AuthenticationServices(BookingDbContext bookingDbContext, ICompanyRepository companyRepository, IUserRepository userRepository, IManagerLogistic managerLogistic, ITokenHandler tokenHandler, IVendorRepository vendorRepository)
        {
            _bookingDbContext = bookingDbContext;
            _companyRepository = companyRepository;
            _managerLogistic = managerLogistic;
            _userRepository = userRepository;
            _tokenHandler = tokenHandler;
            _vendorRepository = vendorRepository;
        }

        public RegisterDTO Register(RegisterDTO registerDto)
        {

            using var transaction = _bookingDbContext.Database.BeginTransaction();

            try
            {
                var company = new Company
                {
                    CompanyName = registerDto.CompanyName,
                    CompanyEmail = registerDto.CompanyEmail,
                    CompanyPhoneNumber = registerDto.CompanyPhoneNumber,
                    CompanyPhoto = registerDto.CompanyPhoto,
                    ApprovalStatus = "Pending",
                };
                var createdCompany = _companyRepository.Create(company);

                var createdUser = new User
                {
                    Email = company.CompanyEmail,
                    Password = registerDto.Password,
                    UserType = Helper.Enum.UserType.Company,
                    ManagerID = registerDto.ManagerID,
                    CompanyID = company.CompanyID,
                };
                var createdAccount = _userRepository.Create(createdUser);

                var toDto = new RegisterDTO
                {
                    CompanyName = createdCompany.CompanyName,
                    CompanyEmail = createdCompany.CompanyEmail,
                    CompanyPhoneNumber = createdCompany.CompanyPhoneNumber,
                    CompanyPhoto = createdCompany.CompanyPhoto,
                    Password = createdUser.Password,
                    UserType = Helper.Enum.UserType.Company,
                    ManagerID = createdUser.ManagerID,
                    CompanyID = company.CompanyID,

                };

                transaction.Commit();
                return toDto;
            }
            catch
            {
                transaction.Rollback();
                return null;
            }
        }

        public string Login(LoginDTO loginDto)
        {
            var user = _userRepository.GetByEmail(loginDto.Email);

            if (user is null)
            {
                return "USER_NOT_FOUND";
            }

            // Verify hashed passwords
            //if (!VerifyPassword(loginDto.Password, user.Password))
            //{
            //    return "INVALID_PASSWORD";
            //}

            var claims = new List<Claim>
            {
                new Claim("Id", $"{user.UserID}"),
                new Claim("Email", loginDto.Email),
                new Claim("UserType", $"{user.UserType}")
            };

            try
            {
                var getToken = _tokenHandler.GenerateToken(claims);
                return "test";
            }
            catch
            {

                return "Error";
            }
        }

        //private bool VerifyPassword(string inputPassword, string hashedPassword)
        //{
        //    // Verify the password using the hashed value
        //    // Example using BCrypt.Net library
        //    return BCrypt.Net.BCrypt.Verify(inputPassword, hashedPassword);
        //}


    }
}
