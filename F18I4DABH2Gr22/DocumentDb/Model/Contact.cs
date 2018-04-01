using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace DocumentDb.Model
{
    public class Contact
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }

        public List<Attachment> Attachments { get; } = new List<Attachment>();
        public List<Phonenumber> Phonenumbers { get; } = new List<Phonenumber>();
        public string Email { get; set; }

        public Contact(string firstName, string middleName, string lastName, Address primaryAddress, Phonenumber phonenumber,
            string email = "", string adresseType = "Primær Adresse")
        {
            if (firstName == null || lastName == null || primaryAddress == null || phonenumber == null)
                throw new ArgumentNullException();
            FirstName = firstName;
            MiddleName = middleName;
            LastName = lastName;
            Email = email;
            Phonenumbers.Add(phonenumber);
            AddAddress(adresseType, primaryAddress);
        }

        [JsonConstructor]
        protected Contact()
        { }

        public void AddAddress(string typeOfAttachment, Address address)
        {
            Attachments.Add(new Attachment(typeOfAttachment, address));
        }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}