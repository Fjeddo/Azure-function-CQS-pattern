using System.Threading.Tasks;
using template_az_function_cs_cqs_pattern.Domain;

namespace template_az_function_cs_cqs_pattern
{
    public interface IUserStorage
    {
        Task<(bool success, User user)> GetUserBySsn(string ssn);
    }
}