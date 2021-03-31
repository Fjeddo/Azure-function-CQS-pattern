namespace template_az_function_cs_cqs_pattern.Domain
{
    public class User
    {
        public string Ssn { get; protected set; }
        public string Name { get; protected set; }
        public string Work { get; protected set; }

        public User(string ssn, string name, string work)
        {
            Ssn = ssn;
            Name = name;
            Work = work;
        }
        
        private User Clone()
        {
            return new User(Ssn, Name, Work);
        }

        public User WithWork(string work)
        {
            var clone = Clone();
            clone.Work = work;

            return clone;
        }

        public User WithName(string name)
        {
            var clone = Clone();
            clone.Name = name;

            return clone;
        }
    }
}
