using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HandIn21
{
    public class By
    {
        [Key]
        [Column(Order = 0)]
        public string Land { get; set; }
        [Key]
        [Column(Order = 1)]
        public string PostNr { get; set; }
        public string Navn { get; set; }
    }
}