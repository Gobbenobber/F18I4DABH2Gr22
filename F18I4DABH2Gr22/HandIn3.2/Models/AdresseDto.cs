using HandIn21_Udvidet;

namespace HandIn3._2.Models
{
    public class AdresseDto
    {
        public int Id { get; set; }

        public string Vejnavn { get; set; }

        public int Husnummer { get; set; }
    }

    public class FullAdreseeDto
    {
        public int Id { get; set; }
        public string Vejnavn { get; set; }
        public int Husnummer { get; set; }
        public ByDto By { get; set; }

        public static FullAdreseeDto CreateDto(Adresse addr)
        {
            var dto = new FullAdreseeDto
            {
                Id = addr.Id,
                Vejnavn = addr.Vejnavn,
                Husnummer = addr.Husnummer,
                By = new ByDto
                {
                    Land = addr.By.Land,
                    PostNr = addr.By.PostNr,
                    Navn = addr.By.Navn
                }
            };
            return dto;
        }

        public static Adresse CreateObj(FullAdreseeDto dto)
        {
            var addr = new Adresse
            {
                Id = dto.Id,
                Vejnavn = dto.Vejnavn,
                Husnummer = dto.Husnummer,
                By = new By
                {
                    Land = dto.By.Land,
                    PostNr = dto.By.PostNr,
                    Navn = dto.By.Navn
                }
            };
            return addr;
        }
    }

    public class ByDto
    {
        public string Land { get; set; }
        public string PostNr { get; set; }
        public string Navn { get; set; }
    }

}