using Marraia.MongoDb.Core;

namespace PetShoes.Identity.Repositories.Repository
{
    public class Customer : Entity<Guid>
    {
        public Customer() { }

        public string Name { get; set; }
        public string Email { get; set; }
        public string Identification { get; set; }
        public string Phone { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string UF { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public bool Active { get; set; }
        public DateTime Updated { get; set; }
        public DateTime Created { get; set; } = new DateTime();

    }
}
