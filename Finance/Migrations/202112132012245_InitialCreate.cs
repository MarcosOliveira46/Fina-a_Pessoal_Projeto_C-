namespace Finance.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Despesas",
                c => new
                    {
                        Despesa_Id = c.Int(nullable: false, identity: true),
                        Data_Despesa = c.DateTime(nullable: false),
                        Despesa_Valor = c.Double(nullable: false),
                        TipoDespesaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Despesa_Id)
                .ForeignKey("dbo.TipoDespesas", t => t.TipoDespesaId, cascadeDelete: true)
                .Index(t => t.TipoDespesaId);
            
            CreateTable(
                "dbo.TipoDespesas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Descricao = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Receitas",
                c => new
                    {
                        ReceitaId = c.Int(nullable: false, identity: true),
                        Receita_Nome = c.Int(nullable: false),
                        Data_Entrada = c.DateTime(nullable: false),
                        Receita_Valor = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.ReceitaId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Despesas", "TipoDespesaId", "dbo.TipoDespesas");
            DropIndex("dbo.Despesas", new[] { "TipoDespesaId" });
            DropTable("dbo.Receitas");
            DropTable("dbo.TipoDespesas");
            DropTable("dbo.Despesas");
        }
    }
}
