namespace PetShoes.Identity.Application.AppCustomer.Input
{
    public class CustomerInput
    {
        public CustomerInput() { }

        public CustomerInput(string name,
                             string email,
                             string cpf,
                             string phone,
                             string city,
                             string uf,
                             string password) 
        { 
            Name = name; 
            Email = email;
            Cpf = cpf;
            Phone = phone;
            City = city;
            UF = uf;
            Password = password;
        }

        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Cpf { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string UF { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
