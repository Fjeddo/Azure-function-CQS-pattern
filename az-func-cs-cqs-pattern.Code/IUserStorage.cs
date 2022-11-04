using System.Threading.Tasks;
using az_func_cs_cqs_pattern.Code.Domain;

namespace az_func_cs_cqs_pattern.Code
{
    public interface IUserStorage
    {
        Task<(bool success, User user)> GetUserBySsn(string ssn);
    }
}