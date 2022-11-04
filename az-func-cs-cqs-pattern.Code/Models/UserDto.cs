using az_func_cs_cqs_pattern.Code.Domain;

namespace az_func_cs_cqs_pattern.Code.Models
{
    public class UserDto
    {
        public string Name { get; protected set; }
        public string Work { get; protected set; }

        protected UserDto() { }

        public UserDto(User user)
        {
            Name = user.Name;
            Work = user.Work;
        }
    }
}