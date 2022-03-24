using System.ComponentModel.DataAnnotations;

namespace APIClientes.Modelo
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        public string UserName { get; set; }

        public byte[] PasswordHash { get; set; }

        public byte[] Passwordsalt { get; set; }
    }
}
