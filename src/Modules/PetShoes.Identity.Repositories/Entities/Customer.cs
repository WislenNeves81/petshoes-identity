using Marraia.MongoDb.Core;
using PetShoes.Identity.Domain.Common.Auth;

namespace PetShoes.Identity.Repositories.Repository
{
    public class Customer : Entity<Guid>
    {
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

            SetDefaultValues();
            SetPasswordEncrypt(password);
        }

        public string Name { get; set; }
        public string Email { get; set; }
        public string Identification { get; set; }
        public string Phone { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string UF { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public bool Active { get; set; }
        public bool Admin { get; set; } = false;
        public DateTime Updated { get; set; }
        public DateTime Created { get; set; } = new DateTime();

        public void Update(string name,
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
            Updated = DateTime.Now;
            SetPasswordEncrypt(password);
        }

        #region Private Methods 
        private void SetDefaultValues()
        {
            Id = Guid.NewGuid();
            Active = true;
        }
        private void SetUpdateValues()
        {
            Updated = DateTime.Now;
        }
        private void SetPasswordEncrypt(string password)
        {
            Password = PasswordHasher.Hash(password);
        }
        #endregion
    }
}
