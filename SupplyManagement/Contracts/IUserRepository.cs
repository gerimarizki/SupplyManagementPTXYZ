using SupplyManagement.Helper.Enum;
using SupplyManagement.Model;

namespace SupplyManagement.Contracts
{
    public interface IUserRepository : IGeneralRepository<User>
    {
        public User? GetByEmail(string email);
        public User? GetByUserType(UserType userType);
    }
}
