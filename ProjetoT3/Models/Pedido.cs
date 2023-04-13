using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjetoT3.Models
{
    public class Pedido
    {
        public int ID { get; set; }
        [DisplayName("Data do Pedido")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [Required]
        public DateTime DataPedido { get; set; }
        [DisplayName("Valor Total")]
        [Required]
        public double ValorTotal { get; set; }
        [Range(0, 999)]
        [Required]
        public int Quantidade { get; set; }

        public int FornecedorID { get; set; }
        public virtual Fornecedor Fornecedor { get; set; }

        public int ProdutoID { get; set; }
        public virtual Produto Produto { get; set; }

        public Pedido()
        {
        }

        public Pedido(DateTime dataPedido, double valorTotal, int quantidade, int fornecedorID, int produtoID)
        {
            DataPedido = dataPedido;
            ValorTotal = valorTotal;
            Quantidade = quantidade;
            FornecedorID = fornecedorID;
            ProdutoID = produtoID;
        }
    }
}