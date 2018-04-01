namespace DocumentDb.Model
{
    public class Phonenumber
    {
        public string Number { get; set; }
        public string Use { get; set; }
        public string Distributor { get; set; }

        public Phonenumber(string number, string use, string distributor = "")
        {
            Number = number;
            Use = use;
            Distributor = distributor;
        }

        protected Phonenumber()
        { }
    }
}