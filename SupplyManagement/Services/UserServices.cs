using SupplyManagement.Contracts;
using SupplyManagement.DTOs.User;
using SupplyManagement.Models;

namespace SupplyManagement.Services
{
    public class UserServices
    {
        private readonly IUserRepository _userRepository;

        public UserServices(IUserRepository userRepository)
        {
            _userRepository = userRepository;

        }

        public IEnumerable<GetUserDTO>? GetAllUser()
        {
            var user = _userRepository.GetAll();
            if (!user.Any())
            {
                return null; //user not found
            }

            var toDto = user.Select(user =>
                                                new GetUserDTO
                                                {
                                                    UserID = user.UserID,
                                                    Email = user.Email,
                                                    Password = user.Password,
                                                    UserType = user.UserType,
                                                    ManagerID = user.ManagerID,
                                                    CompanyID = user.CompanyID,

                                                }).ToList();

            return toDto; // user found
        }

        public GetUserDTO? GetUserId(int id)
        {
            var user = _userRepository.GetById(id);
            if (user is null)
            {
                return null; // user not found
            }

            var toDto = new GetUserDTO
            {
                UserID = user.UserID,
                Email = user.Email,
                Password = user.Password,
                UserType = user.UserType,
                ManagerID = user.ManagerID,
                CompanyID = user.CompanyID,
            };

            return toDto; //user found
        }

        public GetUserDTO? CreateNewUser(NewUserDTO newUserDTO)
        {
            var user = new User
            {
                UserID = newUserDTO.UserID,
                Email = newUserDTO.Email,
                Password = newUserDTO.Password,
                UserType = newUserDTO.UserType,
                ManagerID = newUserDTO.ManagerID,
                CompanyID = newUserDTO.CompanyID,
            };

            var createdUser = _userRepository.Create(user);
            if (createdUser is null)
            {
                return null; // user not created
            }

            var toDto = new GetUserDTO
            {
                UserID = user.UserID,
                Email = user.Email,
                Password = user.Password,
                UserType = user.UserType,
                ManagerID = user.ManagerID,
                CompanyID = user.CompanyID,
            };

            return toDto; // user created
        }

        public int UpdateUser(UpdateUserDTO updateUserDTO)
        {
            var isExist = _userRepository.IsExist(updateUserDTO.UserID);
            if (!isExist)
            {
                return -1; // User Not Found
            }

            var getUser = _userRepository.GetById(updateUserDTO.UserID);

            var user = new User
            {
                UserID = updateUserDTO.UserID,
                Email = updateUserDTO.Email,
                Password = updateUserDTO.Password,
                UserType = updateUserDTO.UserType,
                ManagerID = updateUserDTO.ManagerID,
                CompanyID = updateUserDTO.CompanyID,
            };

            var isUpdate = _userRepository.Update(user);
            if (!isUpdate)
            {
                return 0; // user not updated
            }

            return 1;
        }

        public int DeleteUser(int id)
        {
            var isExist = _userRepository.IsExist(id);
            if (!isExist)
            {
                return -1; // user not found
            }

            var user = _userRepository.GetById(id);
            var isDelete = _userRepository.Delete(user);
            if (!isDelete)
            {
                return 0; // user not deleted
            }

            return 1;
        }
    }
}
