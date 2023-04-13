namespace ProjetoT3.Migrations
{
    using ProjetoT3.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Web.Razor.Parser.SyntaxTree;

    internal sealed class Configuration : DbMigrationsConfiguration<ProjetoT3.DAL.ProjetoContexto>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "ProjetoT3.DAL.ProjetoContexto";
        }

        protected override void Seed(ProjetoT3.DAL.ProjetoContexto context)
        {
            List<Categoria> categorias = new List<Categoria>
            {
                new Categoria(nome:"Hatchback"),
                new Categoria(nome:"SUV"),
                new Categoria(nome:"Conversivel"),
                new Categoria(nome:"Sedan"),
                new Categoria(nome:"Esportivo"),
            };
            categorias.ForEach(c => context.Categorias.AddOrUpdate(c));
            context.SaveChanges();
            List<Cliente> clientes = new List<Cliente>
            {
                new Cliente (nome:"Arthur Maicon", endereco: "101 N AV 1 LT 1", telefone: "(63)98111-1111", cpf: "111.222.333-44", email: "arthur@email.com"),
                new Cliente(nome: "Camila Silva", endereco: "Rua das Flores, 123", telefone: "(11) 99999-9999", cpf: "111.222.333-44", email: "camila@email.com"),
                new Cliente(nome: "Rafael Santos", endereco: "Av. Paulista, 987", telefone: "(21) 98888-8888", cpf: "111.222.333-44", email: "rafael@email.com"),
                new Cliente(nome: "Ana Paula Souza", endereco: "Rua da Praia, 456", telefone: "(31) 97777-7777", cpf: "111.222.333-44", email: "anapaula@email.com"),
                new Cliente(nome: "Pedro Henrique Alves", endereco: "Av. das Palmeiras, 789", telefone: "(41) 96666-6666", cpf: "111.222.333-44", email: "pedrohenrique@email.com"),
                new Cliente(nome: "Mariana Oliveira", endereco: "Rua do Sol, 234", telefone: "(62) 95555-5555", cpf: "111.222.333-44", email: "mariana@email.com"),
                new Cliente(nome: "Lucas Rodrigues", endereco: "Av. Beira Mar, 345", telefone: "(51) 94444-4444", cpf: "111.222.333-44", email: "lucas@email.com"),
                new Cliente(nome: "Juliana Costa", endereco: "Rua das Árvores, 567", telefone: "(84) 93333-3333", cpf: "111.222.333-44", email: "juliana@email.com"),
                new Cliente(nome: "Gustavo Oliveira", endereco: "Av. das Flores, 890", telefone: "(19) 92222-2222", cpf: "111.222.333-44", email: "gustavo@email.com"),
            };
            clientes.ForEach(c => context.Clientes.AddOrUpdate(c));
            context.SaveChanges();
            List<Fornecedor> fornecedor = new List<Fornecedor>
            {
                new Fornecedor (nome: "MM Distribuidora", endereco: "202 S AV 2 LT 2", telefone: "(63)98222-2222", email: "mm@email.com"),
                new Fornecedor(nome: "Volkswagen Fábrica", endereco: "Rua das Flores, 123", telefone: "(11) 99999-9999", email: "volkswagen@fabrica.com"),
                new Fornecedor(nome: "Ford Fábrica de Motores", endereco: "Av. Paulista, 987", telefone: "(21) 98888-8888", email: "ford@fabrica.com.br"),
                new Fornecedor(nome: "General Motors Fábrica de Autopeças", endereco: "Rua da Praia, 456", telefone: "(31) 97777-7777", email: "gm@autopecas.com"),
                new Fornecedor(nome: "Toyota Fábrica de Carros", endereco: "Av. das Palmeiras, 789", telefone: "(41) 96666-6666", email: "toyota@fabrica.com.br"),
                new Fornecedor(nome: "Honda Fábrica de Motores", endereco: "Rua do Sol, 234", telefone: "(62) 95555-5555", email: "honda@fabrica.com"),
                new Fornecedor(nome: "Fiat Fábrica de Veículos", endereco: "Av. Beira Mar, 345", telefone: "(51) 94444-4444", email: "fiat@fabrica.com.br"),
                new Fornecedor(nome: "Renault Fábrica de Carros", endereco: "Rua das Palmeiras, 567", telefone: "(12) 93333-3333", email: "renault@fabrica.com"),
                new Fornecedor(nome: "Mercedes-Benz Fábrica de Motores", endereco: "Av. dos Pinheiros, 678", telefone: "(61) 92222-2222", email: "mercedes@fabrica.com"),
            };
            fornecedor.ForEach(c => context.Fornecedores.AddOrUpdate(c));
            context.SaveChanges();
            List<Produto> produto = new List<Produto>
            {
                new Produto (nome: "Ford Fiesta", descricao: "O Ford Fiesta é um carro compacto e econômico com um design moderno e recursos avançados de tecnologia.", preco: 15000.00, marca: "Ford", cor: "Preto", qtdEstoque: 2, categoriaID: 1),
                new Produto(nome: "Volkswagen Gol", descricao: "O Volkswagen Gol é um carro popular com um design clássico e recursos básicos de tecnologia.", preco: 20000.00, marca: "Volkswagen", cor: "Branco", qtdEstoque: 2, categoriaID: 1),
                new Produto(nome: "Chevrolet Onix", descricao: "O Chevrolet Onix é um carro compacto e econômico com um design moderno e recursos avançados de tecnologia.", preco: 25000.00, marca: "Chevrolet", cor: "Vermelho", qtdEstoque: 3, categoriaID: 1),
                new Produto(nome: "Toyota Corolla", descricao: "O Toyota Corolla é um carro sedan de tamanho médio com um design sofisticado e recursos avançados de tecnologia.", preco: 50000.00, marca: "Toyota", cor: "Prata", qtdEstoque: 1, categoriaID: 4),
                new Produto(nome: "Honda Civic", descricao: "O Honda Civic é um carro sedan de tamanho médio com um design elegante e recursos avançados de tecnologia.", preco: 45000.00, marca: "Honda", cor: "Azul", qtdEstoque: 2, categoriaID: 4),
                new Produto(nome: "Nissan Versa", descricao: "O Nissan Versa é um carro sedan de tamanho médio com um design moderno e recursos avançados de tecnologia.", preco: 28000.00, marca: "Nissan", cor: "Preto", qtdEstoque: 3, categoriaID: 4),
                new Produto(nome: "Fiat Uno", descricao: "O Fiat Uno é um carro compacto e econômico com um design simples e recursos básicos de tecnologia.", preco: 18000.00, marca: "Fiat", cor: "Branco", qtdEstoque: 1, categoriaID: 1),
                new Produto(nome: "Renault Kwid", descricao: "O Renault Kwid é um carro compacto e econômico com um design moderno e recursos básicos de tecnologia.", preco: 22000.00, marca: "Renault", cor: "Verde", qtdEstoque: 2, categoriaID: 1),
                new Produto(nome: "Mercedes-Benz Classe A", descricao: "O Mercedes-Benz Classe A é um carro sedan de luxo com um design sofisticado e recursos avançados de tecnologia.", preco: 80000.00, marca: "Mercedes-Benz", cor: "Preto", qtdEstoque: 1, categoriaID: 5),
                new Produto(nome: "Jeep Renegade", descricao: "O Jeep Renegade é um carro SUV compacto com um design robusto e recursos avançados de tecnologia.", preco: 60000.00, marca: "Jeep", cor: "Azul", qtdEstoque: 2, categoriaID: 2),
                new Produto(nome: "Mazda MX-5", descricao: "O Mazda MX-5 é um carro conversível de dois lugares com um design esportivo e elegante.", preco: 40000.00, marca: "Mazda", cor: "Vermelho", qtdEstoque: 1, categoriaID: 3)
            };
            produto.ForEach(c => context.Produtos.AddOrUpdate(c));
            context.SaveChanges();
            List<Pedido> pedido = new List<Pedido>
            {
                new Pedido (dataPedido: DateTime.Now, valorTotal: 20000.00, quantidade: 1, fornecedorID: 1, produtoID: 1),
                new Pedido(dataPedido: DateTime.Now, valorTotal: 20000.00, quantidade: 20, fornecedorID: 4, produtoID: 7),
                new Pedido(dataPedido: DateTime.Now, valorTotal: 30000.00, quantidade: 30, fornecedorID: 2, produtoID: 9),
                new Pedido(dataPedido: DateTime.Now, valorTotal: 40000.00, quantidade: 40, fornecedorID: 9, produtoID: 3),
                new Pedido(dataPedido: DateTime.Now, valorTotal: 50000.00, quantidade: 50, fornecedorID: 1, produtoID: 10),
                new Pedido(dataPedido: DateTime.Now, valorTotal: 60000.00, quantidade: 60, fornecedorID: 6, produtoID: 5),
                new Pedido(dataPedido: DateTime.Now, valorTotal: 70000.00, quantidade: 70, fornecedorID: 3, produtoID: 2),
                new Pedido(dataPedido: DateTime.Now, valorTotal: 80000.00, quantidade: 80, fornecedorID: 7, produtoID: 11),
                new Pedido(dataPedido: DateTime.Now, valorTotal: 90000.00, quantidade: 90, fornecedorID: 5, produtoID: 4),
                new Pedido(dataPedido: DateTime.Now, valorTotal: 100000.00, quantidade: 100, fornecedorID: 8, produtoID: 8),
                new Pedido(dataPedido: DateTime.Now, valorTotal: 110000.00, quantidade: 110, fornecedorID: 4, produtoID: 1),
            };
            pedido.ForEach(c => context.Pedidos.AddOrUpdate(c));
            context.SaveChanges();
            List<Venda> venda = new List<Venda>
            {
                new Venda (dataVenda: DateTime.Now, valorTotal: 19000.00, clienteID: 1, produtoID: 1),
                new Venda(dataVenda: DateTime.Now, valorTotal: 21000.00, clienteID: 3, produtoID: 7),
                new Venda(dataVenda: DateTime.Now, valorTotal: 32000.00, clienteID: 2, produtoID: 9),
                new Venda(dataVenda: DateTime.Now, valorTotal: 43000.00, clienteID: 8, produtoID: 3),
                new Venda(dataVenda: DateTime.Now, valorTotal: 54000.00, clienteID: 4, produtoID: 10),
                new Venda(dataVenda: DateTime.Now, valorTotal: 65000.00, clienteID: 7, produtoID: 5),
                new Venda(dataVenda: DateTime.Now, valorTotal: 76000.00, clienteID: 6, produtoID: 2),
                new Venda(dataVenda: DateTime.Now, valorTotal: 87000.00, clienteID: 5, produtoID: 11),
                new Venda(dataVenda: DateTime.Now, valorTotal: 98000.00, clienteID: 9, produtoID: 4),
                new Venda(dataVenda: DateTime.Now, valorTotal: 109000.00, clienteID: 3, produtoID: 8),
                new Venda(dataVenda: DateTime.Now, valorTotal: 120000.00, clienteID: 1, produtoID: 1),
            };
            venda.ForEach(c => context.Vendas.AddOrUpdate(c));
            context.SaveChanges();

        }
    }
}
