using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ProjetoT3.Models
{
    public class Fornecedor
    {
        public int ID { get; set; }
        [Required]
        public string Nome { get; set; }
        [DisplayName("Endereço")]
        public string Endereco { get; set; }
        public string Telefone { get; set; }
        [Index(IsUnique = true)]
        [DisplayName("E-mail")]
        [Required]
        [StringLength(120)]
        [EmailAddress]
        public string Email { get; set; }

        public virtual ICollection<Produto> Produtos { get; set; }
        public virtual ICollection<Pedido> Pedidos { get; set; }

        public Fornecedor()
        {
            Produtos = new List<Produto>();
            Pedidos = new List<Pedido>();
        }

        public Fornecedor(string nome, string endereco, string telefone, string email)
        {
            Nome = nome;
            Endereco = endereco;
            Telefone = telefone;
            Email = email;
            Produtos = new List<Produto>();
            Pedidos = new List<Pedido>();
        }
    }
}