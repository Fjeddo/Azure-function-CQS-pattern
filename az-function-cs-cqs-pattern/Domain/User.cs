namespace az_function_cs_cqs_pattern.Domain
{
    public class User
    {
        public string Ssn { get; private set; }
        public string Name { get; private set; }
        public string Work { get; private set; }

        public User(string ssn, string name, string work)
        {
            Ssn = ssn;
            Name = name;
            Work = work;
        }
        
        private User Clone() => new(Ssn, Name, Work);

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
