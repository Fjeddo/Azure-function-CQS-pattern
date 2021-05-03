using az_function_cs_cqs_pattern.Domain;

namespace az_function_cs_cqs_pattern.Models
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