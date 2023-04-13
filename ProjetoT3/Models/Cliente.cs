using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProjetoT3.Models
{
    public class Cliente
    {
        public int ID { get; set; }
        [Required]
        public string Nome { get; set; }
        [DisplayName("Endereço")]
        public string Endereco { get; set; }
        public string Telefone { get; set; }
        [StringLength(14, MinimumLength = 14, ErrorMessage = "CPF Inválido.")]
        [DisplayName("CPF")]
        public string Cpf { get; set; }
        [Index(IsUnique = true)]
        [DisplayName("E-mail")]
        [Required]
        [StringLength(120)]
        [EmailAddress]
        public string Email { get; set; }

        public virtual ICollection<Venda> Vendas { get; set; }

        public Cliente()
        {
            Vendas = new List<Venda>();
        }

        public Cliente(string nome, string endereco, string telefone, string cpf, string email)
        {
            Nome = nome;
            Endereco = endereco;
            Telefone = telefone;
            Cpf = cpf;
            Email = email;
            Vendas = new List<Venda> ();
        }
    }
}