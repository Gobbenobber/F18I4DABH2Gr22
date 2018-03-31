using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HandIn21
{
    public class By
    {
        public int Id { get; set; }
        public string Land { get; set; }
        public string PostNr { get; set; }
        public string Navn { get; set; }
    }
}