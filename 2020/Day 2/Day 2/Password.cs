namespace Day_2
{
    public class Password
    {
        public Password(string value, IPolicy policy)
        {
            Value = value;
            Policy = policy;
        }

        public string Value { get; set; }

        public IPolicy Policy { get; set; }

        public bool IsValid()
        {
            return Policy.IsValid(Value);
        }
    }
}
