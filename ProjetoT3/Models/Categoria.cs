using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjetoT3.Models
{
    public class Categoria
    {
        public int ID { get; set; }
        [Required]
        public string Nome { get; set; }
        public virtual ICollection<Produto> Produtos { get; set; }

        public Categoria()
        {
            Produtos = new List<Produto>();
        }

        public Categoria(string nome)
        {
            Nome = nome;
            Produtos = new List<Produto> ();
        }
    }
}