using System.Threading.Tasks;
using az_function_cs_cqs_pattern.Domain;

namespace az_function_cs_cqs_pattern
{
    public interface IUserStorage
    {
        Task<(bool success, User user)> GetUserBySsn(string ssn);
    }
}