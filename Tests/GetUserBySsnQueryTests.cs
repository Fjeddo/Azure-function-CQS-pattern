using System.Threading.Tasks;
using az_functions_cs_cqs_pattern.Code;
using az_functions_cs_cqs_pattern.Code.Domain;
using az_functions_cs_cqs_pattern.Code.Queries;
using FluentAssertions;
using NSubstitute;
using Xunit;

namespace Tests
{
    public class GetUserBySsnQueryTests
    {
        private readonly IUserStorage _dataSource;
        private const string Ssn = "1234567890";
        
        public GetUserBySsnQueryTests()
        {
            _dataSource = Substitute.For<IUserStorage>();
            _dataSource.GetUserBySsn(Ssn).Returns(info => Task.FromResult((true, new User(Ssn, "Kalle", "Hobbit på heltid"))));
        }
        
        [Fact]
        public async Task Execute_should_return_user_when_found()
        {
            var sut = new GetUserBySsnQuery(Ssn, _dataSource);

            var (success, result, status) = await sut.Execute();

            success.Should().BeTrue();
            status.Should().Be(0);
            result.Should().BeEquivalentTo(new User(Ssn, "Kalle", "Hobbit på heltid"));
        }

        [Fact]
        public async Task Execute_should_return_false_with_status_when_not_found()
        {
            const string someOtherSsn = "0987654321";
            var sut = new GetUserBySsnQuery(someOtherSsn, _dataSource);

            var (success, result, status) = await sut.Execute();

            success.Should().BeFalse();
            status.Should().Be(-1);
            result.Should().BeEquivalentTo(default(User));
        }
    }
}
