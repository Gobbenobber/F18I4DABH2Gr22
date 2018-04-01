namespace DocumentDb.Model
{
    public class Attachment
    {
        public string Type { get; set; }

        public Address Address { get; set; }

        public Attachment(string type, Address address)
        {
            Type = type;
            Address = address;
        }

        protected Attachment()
        { }
    }
}