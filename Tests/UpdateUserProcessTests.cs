using System.Threading.Tasks;
using az_functions_cs_cqs_pattern.Code;
using az_functions_cs_cqs_pattern.Code.Commands;
using az_functions_cs_cqs_pattern.Code.Domain;
using az_functions_cs_cqs_pattern.Code.Models;
using az_functions_cs_cqs_pattern.Code.Queries;
using FluentAssertions;
using Microsoft.Extensions.Logging.Abstractions;
using NSubstitute;
using Xunit;

namespace Tests
{
    public class UpdateUserProcessTests
    {
        private UpdateUserProcess _sut;
        private IQueryExecuter _queryExecuter;
        private ICommandHandler _commandHandler;

        public UpdateUserProcessTests()
        {
            _queryExecuter = Substitute.For<IQueryExecuter>();
            _commandHandler = Substitute.For<ICommandHandler>();
            
            _sut = new UpdateUserProcess(
                _queryExecuter,
                _commandHandler,
                Substitute.For<IUserStorage>(),
                new NullLogger<UpdateUserProcess>());
        }

        [Fact]
        public async Task When_everything_is_fine_expected_queries_and_commands_should_be_invoked()
        {
            _queryExecuter.Execute(Arg.Any<GetUserBySsnQuery>()).Returns(Task.FromResult((true, new User("1234567890", "Nils", "Gold smith"), 0)));
            
            await _sut.Run(new UpdateUserRequest {Name = "Nisse", Ssn = "1234567890", Work = "Gold digger"});

            await _queryExecuter.Received().Execute(Arg.Any<GetUserBySsnQuery>());
            await _commandHandler.Received().Handle(Arg.Any<UpdateNameCommand>(), Arg.Any<User>());
            await _commandHandler.Received().Handle(Arg.Any<UpdateWorkCommand>(), Arg.Any<User>());
        }

        [Fact]
        public async Task When_user_is_not_found_the_commands_should_not_be_invoked()
        {
            _queryExecuter.Execute(Arg.Any<GetUserBySsnQuery>()).Returns(Task.FromResult((false, default(User), 987)));

            var result = await _sut.Run(new UpdateUserRequest { Name = "Nisse", Ssn = "1234567890", Work = "Gold digger" });

            result.Should().Be((false, null, 987));
            
            await _queryExecuter.Received().Execute(Arg.Any<GetUserBySsnQuery>());
            await _commandHandler.DidNotReceive().Handle(Arg.Any<UpdateNameCommand>(), Arg.Any<User>());
            await _commandHandler.DidNotReceive().Handle(Arg.Any<UpdateWorkCommand>(), Arg.Any<User>());
        }
    }
}