using SupplyManagement.Helper.Enum;
using SupplyManagement.Models;

namespace SupplyManagement.Contracts
{
    public interface IUserRepository : IGeneralRepository<User>
    {
        public User? GetByEmail(string email);
        public User? GetByUserType(UserType userType);
    }
}
