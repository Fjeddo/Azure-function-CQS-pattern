﻿using System.Threading.Tasks;
using az_function_cs_cqs_pattern.Domain;

namespace az_function_cs_cqs_pattern.Commands
{
    public class UpdateWorkCommand : ICommand<User>
    {
        private readonly string _work;

        public UpdateWorkCommand(string work) => _work = work;

        public async Task<User> Execute(User domainModel) => domainModel.WithWork(_work);
    }
}
