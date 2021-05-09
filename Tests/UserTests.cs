using az_function_cs_cqs_pattern.Domain;
using FluentAssertions;
using Xunit;

namespace Tests
{
    public class UserTests
    {
        [Fact]
        public void WithWork_should_clone_not_modify()
        {
            var sut = new User("1234567890", "Karo Hero", "Meisterhirte");

            var clone = sut.WithWork("alter Meisterhirte");

            clone.Should().NotBe(sut);
            clone.Should().NotBeEquivalentTo(sut);
            clone.Work.Should().Be("alter Meisterhirte");
            sut.Work.Should().Be("Meisterhirte");
        }

        [Fact]
        public void WithName_should_clone_not_modify()
        {
            var sut = new User("1234567890", "Karo Hero", "Meisterhirte");

            var clone = sut.WithName("alter Karo Hero");

            clone.Should().NotBe(sut);
            clone.Should().NotBeEquivalentTo(sut);
            clone.Name.Should().Be("alter Karo Hero");
            sut.Name.Should().Be("Karo Hero");
        }
    }
}