using System.Threading.Tasks;
using template_az_function_cs_cqs_pattern.Domain;

namespace template_az_function_cs_cqs_pattern.Queries
{
    public class GetUserBySsnQuery : IQuery<User>
    {
        private readonly string _ssn;

        public GetUserBySsnQuery(string ssn)
        {
            _ssn = ssn;
        }
        
        public async Task<(bool success, User result, int status)> Execute()
        {
            return (true, new User(_ssn, "Nisse Hult", "Maurer"), 0);
        }
    }
}
