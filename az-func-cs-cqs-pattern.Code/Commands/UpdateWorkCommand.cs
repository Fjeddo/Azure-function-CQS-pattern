using System.Threading.Tasks;
using az_func_cs_cqs_pattern.Code.Domain;

namespace az_func_cs_cqs_pattern.Code.Commands
{
    public class UpdateWorkCommand : ICommand<User>
    {
        private readonly string _work;

        public UpdateWorkCommand(string work) => _work = work;

        public async Task<User> Execute(User domainModel) => domainModel.WithWork(_work);
    }
}
