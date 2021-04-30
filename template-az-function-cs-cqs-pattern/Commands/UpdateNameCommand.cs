using System.Threading.Tasks;
using template_az_function_cs_cqs_pattern.Domain;

namespace template_az_function_cs_cqs_pattern.Commands
{
    public class UpdateNameCommand : ICommand<User>
    {
        private readonly string _name;

        public UpdateNameCommand(string name) => _name = name;

        public async Task<User> Execute(User domainModel) => domainModel.WithName(_name);
    }
}