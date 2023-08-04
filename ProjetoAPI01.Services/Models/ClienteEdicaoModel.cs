using System.ComponentModel.DataAnnotations;

namespace ProjetoAPI01.Services.Models
{
    public class ClienteEdicaoModel
    {
        [Required(ErrorMessage = "Por favor, informe o id do cliente.")]
        public Guid IdCliente { get; set; }
        [MinLength(10, ErrorMessage = "Por favor, informe no mínimo {1} caracteres.")]
        [MaxLength(150, ErrorMessage = "Por favor, informe no máximo {1} caracteres.")]
        [Required(ErrorMessage = "Por favor, informe o nome do cliente.")]
        public string Nome { get; set; }
        [EmailAddress(ErrorMessage = "Por favor, informe um endereço de email válido.")]

        [Required(ErrorMessage = "Por favor, informe o email do cliente.")]
        public string Email { get; set; }
    }
}
