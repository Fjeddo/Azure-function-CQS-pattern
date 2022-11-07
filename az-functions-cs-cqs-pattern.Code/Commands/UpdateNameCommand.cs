using System.Threading.Tasks;
using az_functions_cs_cqs_pattern.Code.Domain;

namespace az_functions_cs_cqs_pattern.Code.Commands
{
    public class UpdateNameCommand : ICommand<User>
    {
        private readonly string _name;

        public UpdateNameCommand(string name) => _name = name;

        public async Task<User> Execute(User domainModel) => domainModel.WithName(_name);
    }
}