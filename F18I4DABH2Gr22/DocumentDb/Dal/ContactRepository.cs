using DocumentDb.Model;

namespace DocumentDb.Dal
{
    public class ContactRepository : DocumentDbRepository<Contact>, IContactRepository
    {
        private const string DatabaseId = "ContactDb";
        private const string CollectionId = "ContactCollection";

        public ContactRepository() : base(DatabaseId, CollectionId)
        {

        }
    }
}