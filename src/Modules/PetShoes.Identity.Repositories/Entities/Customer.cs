using Marraia.MongoDb.Core;

namespace PetShoes.Identity.Repositories.Repository
{
    public class Customer : Entity<Guid>
    {
        public Customer() { }

        public Customer(string name,
                        string email,
                        string cpf,
                        string phone,
                        string city,
                        string uf,
                        string password)
        {
            Name = name;
            Email = email;
            Identification = cpf;
            Phone = phone;
            City = city;
            UF = uf;
            Password = password;

            SetDefaultValues();
            SetPasswordEncrypt();
        }

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
        
        #region Private Methods 
        private void SetDefaultValues()
        {
            Id = Guid.NewGuid();
            Active = true;
            Updated = DateTime.Now;
            Created = DateTime.Now;
        }
        private void SetUpdateValues()
        {
            Updated = DateTime.Now;
        }

        private void SetPasswordEncrypt()
        {
            //Password = BCrypt.Net.BCrypt.HashPassword(Password);
        }
        #endregion
    }
}
