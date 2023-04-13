using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjetoT3.Models
{
    public class Venda
    {
        public int ID { get; set; }
        [DisplayName("Data da Venda")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [Required]
        public DateTime DataVenda { get; set; }
        [Required]
        [DisplayName("Valor Total")]
        public double ValorTotal { get; set; }
        [Required]
        public int ClienteID { get; set; }
        public virtual Cliente Cliente { get; set; }
        [Required]
        public int ProdutoID { get; set; }
        public virtual Produto Produto { get; set; }

        public Venda()
        {
        }

        public Venda(DateTime dataVenda, double valorTotal, int clienteID, int produtoID)
        {
            DataVenda = dataVenda;
            ValorTotal = valorTotal;
            ClienteID = clienteID;
            ProdutoID = produtoID;
        }
    }
}