using SupplyManagement.Contracts;
using SupplyManagement.Data;
using SupplyManagement.Helper.Enum;
using SupplyManagement.Model;

namespace SupplyManagement.Repositories
{
    public class UserRepository : GeneralRepository<User>, IUserRepository
    {
        public UserRepository(BookingDbContext context) : base(context)
        {

        }

        public User? GetByEmail(string email)
        {
            return _context.Set<User>().FirstOrDefault(u => u.Email == email);
        }

        public User? GetByUserType(UserType userType)
        {
            return _context.Set<User>().FirstOrDefault(u => u.UserType == userType);
        }
    }
}
