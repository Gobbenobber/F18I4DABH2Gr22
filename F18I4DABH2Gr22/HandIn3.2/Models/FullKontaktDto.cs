using System.Collections.Generic;
using HandIn21_Udvidet;

namespace HandIn3._2.Models
{
    public class FullKontaktDto
    {
        public int Id { get; set; }
        public string Fornavn { get; set; }
        public string Mellemnavn { get; set; }
        public string Efternavn { get; set; }
        public string Email { get; set; }
        public List<TilKnytningsDto> Tilknytninger { get; set; }
        public List<TelefonNummerDto> TelefonNumre { get; set; }
    }

    public class TilKnytningsDto
    {
        public string Type { get; set; }
        public int AdresseId { get; set; }
    }

    public class TelefonNummerDto
    {
        public string Brug { get; set; }
        public string Nummer { get; set; }
        public string Udbyder { get; set; }
    }

    public static class KontaktDtoSkaber
    {
        public static FullKontaktDto LavEtFullKontaktDto(Kontakt kontakt)
        {
            var dto = new FullKontaktDto
            {
                Id = kontakt.Id,
                Fornavn = kontakt.Fornavn,
                Mellemnavn = kontakt.Mellemnavn,
                Efternavn = kontakt.Efternavn,
                Email = kontakt.Email
            };

            dto.Tilknytninger = new List<TilKnytningsDto>();
            dto.TelefonNumre = new List<TelefonNummerDto>();

            foreach (var erTilknyttet in kontakt.TilknyttedeAdresser)
            {
                dto.Tilknytninger.Add(new TilKnytningsDto
                {
                    Type = erTilknyttet.Type,
                    AdresseId = erTilknyttet.Adresse.Id
                });
            }

            foreach (var telefonnummer in kontakt.Telefonnumre)
            {
                dto.TelefonNumre.Add(new TelefonNummerDto
                {
                    Brug = telefonnummer.Brug,
                    Nummer = telefonnummer.Nummer,
                    Udbyder = telefonnummer.Teleselskab
                });
            }

            return dto;
        }

        public static Kontakt LavEnKontakt(FullKontaktDto dto)
        {
            var kon = new Kontakt();
            kon.Id = dto.Id;
            kon.Fornavn = dto.Fornavn;
            kon.Mellemnavn = dto.Mellemnavn;
            kon.Efternavn = dto.Efternavn;
            kon.Email = dto.Email;

            foreach (var tilknyt in dto.Tilknytninger)
            {
                kon.TilknyttedeAdresser.Add(new ErTilknyttet(tilknyt.Type, new Adresse() {Id = tilknyt.AdresseId}));
            }

            foreach (var telefonnummer in dto.TelefonNumre)
            {
                kon.Telefonnumre.Add(new Telefonnummer(telefonnummer.Nummer, telefonnummer.Brug,
                    telefonnummer.Udbyder));
            }

            return kon;

        }
    }
}