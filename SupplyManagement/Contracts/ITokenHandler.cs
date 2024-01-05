using System.Security.Claims;

namespace SupplyManagement.Contracts
{
    public interface ITokenHandler
    {
        string GenerateToken(IEnumerable<Claim> claims);

    }
}
