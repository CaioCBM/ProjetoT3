namespace ProjetoT3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categorias",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Produtoes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false),
                        Descricao = c.String(),
                        Preco = c.Double(nullable: false),
                        Marca = c.String(),
                        Cor = c.String(),
                        QtdEstoque = c.Int(nullable: false),
                        CategoriaID = c.Int(nullable: false),
                        Fornecedor_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Categorias", t => t.CategoriaID, cascadeDelete: true)
                .ForeignKey("dbo.Fornecedors", t => t.Fornecedor_ID)
                .Index(t => t.CategoriaID)
                .Index(t => t.Fornecedor_ID);
            
            CreateTable(
                "dbo.Pedidoes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        DataPedido = c.DateTime(nullable: false),
                        ValorTotal = c.Double(nullable: false),
                        Quantidade = c.Int(nullable: false),
                        FornecedorID = c.Int(nullable: false),
                        ProdutoID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Fornecedors", t => t.FornecedorID, cascadeDelete: true)
                .ForeignKey("dbo.Produtoes", t => t.ProdutoID, cascadeDelete: true)
                .Index(t => t.FornecedorID)
                .Index(t => t.ProdutoID);
            
            CreateTable(
                "dbo.Fornecedors",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false),
                        Endereco = c.String(),
                        Telefone = c.String(),
                        Email = c.String(nullable: false, maxLength: 120),
                    })
                .PrimaryKey(t => t.ID)
                .Index(t => t.Email, unique: true);
            
            CreateTable(
                "dbo.Vendas",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        DataVenda = c.DateTime(nullable: false),
                        ValorTotal = c.Double(nullable: false),
                        ClienteID = c.Int(nullable: false),
                        ProdutoID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Clientes", t => t.ClienteID, cascadeDelete: true)
                .ForeignKey("dbo.Produtoes", t => t.ProdutoID, cascadeDelete: true)
                .Index(t => t.ClienteID)
                .Index(t => t.ProdutoID);
            
            CreateTable(
                "dbo.Clientes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false),
                        Endereco = c.String(),
                        Telefone = c.String(),
                        Cpf = c.String(maxLength: 14),
                        Email = c.String(nullable: false, maxLength: 120),
                    })
                .PrimaryKey(t => t.ID)
                .Index(t => t.Email, unique: true);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Vendas", "ProdutoID", "dbo.Produtoes");
            DropForeignKey("dbo.Vendas", "ClienteID", "dbo.Clientes");
            DropForeignKey("dbo.Pedidoes", "ProdutoID", "dbo.Produtoes");
            DropForeignKey("dbo.Produtoes", "Fornecedor_ID", "dbo.Fornecedors");
            DropForeignKey("dbo.Pedidoes", "FornecedorID", "dbo.Fornecedors");
            DropForeignKey("dbo.Produtoes", "CategoriaID", "dbo.Categorias");
            DropIndex("dbo.Clientes", new[] { "Email" });
            DropIndex("dbo.Vendas", new[] { "ProdutoID" });
            DropIndex("dbo.Vendas", new[] { "ClienteID" });
            DropIndex("dbo.Fornecedors", new[] { "Email" });
            DropIndex("dbo.Pedidoes", new[] { "ProdutoID" });
            DropIndex("dbo.Pedidoes", new[] { "FornecedorID" });
            DropIndex("dbo.Produtoes", new[] { "Fornecedor_ID" });
            DropIndex("dbo.Produtoes", new[] { "CategoriaID" });
            DropTable("dbo.Clientes");
            DropTable("dbo.Vendas");
            DropTable("dbo.Fornecedors");
            DropTable("dbo.Pedidoes");
            DropTable("dbo.Produtoes");
            DropTable("dbo.Categorias");
        }
    }
}
