namespace Gerasite.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Logo",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CaminhoImagem = c.String(maxLength: 50),
                        ArquivoImagem = c.String(maxLength: 100),
                        Template_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Template", t => t.Template_Id)
                .Index(t => t.Template_Id);
            
            CreateTable(
                "dbo.Template",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NomeTemplate = c.String(nullable: false, maxLength: 50),
                        DescricaoTemplate = c.String(maxLength: 100),
                        CorTemplate = c.String(maxLength: 12),
                        Sessao_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Sessaos", t => t.Sessao_Id)
                .Index(t => t.Sessao_Id);
            
            CreateTable(
                "dbo.Sessaos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DataInicioSessao = c.DateTime(nullable: false),
                        Usuario_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Usuario", t => t.Usuario_Id)
                .Index(t => t.Usuario_Id);
            
            CreateTable(
                "dbo.Usuario",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(maxLength: 150),
                        Email = c.String(maxLength: 50),
                        Senha = c.String(maxLength: 50),
                        HistoricoTemplate = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Menu",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 50),
                        PaginaAdicionada = c.Boolean(nullable: false),
                        PosicaoHorizontal = c.Single(nullable: false),
                        PosicaoVertical = c.Single(nullable: false),
                        Template_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Template", t => t.Template_Id)
                .Index(t => t.Template_Id);
            
            CreateTable(
                "dbo.Pagina",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(maxLength: 50),
                        PosicaoHorizontal = c.Single(nullable: false),
                        PosicaoVertical = c.Single(nullable: false),
                        Menu_Id = c.Int(nullable: false),
                        Template_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Menu", t => t.Menu_Id)
                .ForeignKey("dbo.Template", t => t.Template_Id)
                .Index(t => t.Menu_Id)
                .Index(t => t.Template_Id);
            
            CreateTable(
                "dbo.TemplateArquivado",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DataCriacao = c.DateTime(nullable: false),
                        NomeTemplate = c.String(maxLength: 50),
                        Template_Id = c.Int(nullable: false),
                        Usuario_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Template", t => t.Template_Id)
                .ForeignKey("dbo.Usuario", t => t.Usuario_Id)
                .Index(t => t.Template_Id)
                .Index(t => t.Usuario_Id);
            
            CreateTable(
                "dbo.Texto",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Conteudo = c.String(maxLength: 200),
                        CorTexto = c.String(maxLength: 10),
                        PosicaoHorizontal = c.Single(nullable: false),
                        PosicaoVertical = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TemplateArquivado", "Usuario_Id", "dbo.Usuario");
            DropForeignKey("dbo.TemplateArquivado", "Template_Id", "dbo.Template");
            DropForeignKey("dbo.Pagina", "Template_Id", "dbo.Template");
            DropForeignKey("dbo.Pagina", "Menu_Id", "dbo.Menu");
            DropForeignKey("dbo.Menu", "Template_Id", "dbo.Template");
            DropForeignKey("dbo.Logo", "Template_Id", "dbo.Template");
            DropForeignKey("dbo.Template", "Sessao_Id", "dbo.Sessaos");
            DropForeignKey("dbo.Sessaos", "Usuario_Id", "dbo.Usuario");
            DropIndex("dbo.TemplateArquivado", new[] { "Usuario_Id" });
            DropIndex("dbo.TemplateArquivado", new[] { "Template_Id" });
            DropIndex("dbo.Pagina", new[] { "Template_Id" });
            DropIndex("dbo.Pagina", new[] { "Menu_Id" });
            DropIndex("dbo.Menu", new[] { "Template_Id" });
            DropIndex("dbo.Sessaos", new[] { "Usuario_Id" });
            DropIndex("dbo.Template", new[] { "Sessao_Id" });
            DropIndex("dbo.Logo", new[] { "Template_Id" });
            DropTable("dbo.Texto");
            DropTable("dbo.TemplateArquivado");
            DropTable("dbo.Pagina");
            DropTable("dbo.Menu");
            DropTable("dbo.Usuario");
            DropTable("dbo.Sessaos");
            DropTable("dbo.Template");
            DropTable("dbo.Logo");
        }
    }
}
