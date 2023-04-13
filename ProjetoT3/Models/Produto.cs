using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjetoT3.Models
{
    public class Produto
    {
        public int ID { get; set; }
        [Required]
        public string Nome { get; set; }
        [DisplayName("Descrição")]
        public string Descricao { get; set; }
        [Required]
        [DisplayName("Preço")]
        public double Preco { get; set; }
        public string Marca { get; set; }
        public string Cor { get; set; }
        [Range(0, 999)]
        [DisplayName("Em Estoque")]
        public int QtdEstoque { get; set; }

        public int CategoriaID { get; set; }
        public virtual Categoria Categoria { get; set; }
        public virtual ICollection<Venda> Vendas { get; set; }
        public virtual ICollection<Pedido> Pedidos{ get; set; }

        public Produto()
        {
            Vendas = new List<Venda>();
            Pedidos = new List<Pedido>();
        }

        public Produto(string nome, string descricao, double preco, string marca, string cor, int qtdEstoque, int categoriaID)
        {
            Nome = nome;
            Descricao = descricao;
            Preco = preco;
            Marca = marca;
            Cor = cor;
            QtdEstoque = qtdEstoque;
            CategoriaID = categoriaID;
            Vendas = new List<Venda>();
            Pedidos = new List<Pedido>();
        }
    }
}