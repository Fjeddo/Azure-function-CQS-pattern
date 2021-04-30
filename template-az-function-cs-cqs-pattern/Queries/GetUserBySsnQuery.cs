using System.Threading.Tasks;
using template_az_function_cs_cqs_pattern.Domain;

namespace template_az_function_cs_cqs_pattern.Queries
{
    public class GetUserBySsnQuery : IQuery<User>
    {
        private readonly string _ssn;
        private readonly IUserStorage _userStorage;

        public GetUserBySsnQuery(string ssn, IUserStorage userStorage)
        {
            _ssn = ssn;
            _userStorage = userStorage;
        }

        public async Task<(bool success, User result, int status)> Execute()
        {
            var (success, user) = await _userStorage.GetUserBySsn(_ssn);
            return success ? (true, user, 0) : (false, default, -1);
        }
    }
}
