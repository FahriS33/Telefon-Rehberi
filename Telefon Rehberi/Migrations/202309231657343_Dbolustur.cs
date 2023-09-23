namespace Telefon_Rehberi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Dbolustur : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.İletisim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Konum = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Kisilers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Ad = c.String(),
                        Soyad = c.String(),
                        Firma = c.String(),
                        Telefon = c.String(),
                        Email = c.String(),
                        İletisimId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.İletisim", t => t.İletisimId, cascadeDelete: true)
                .Index(t => t.İletisimId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Kisilers", "İletisimId", "dbo.İletisim");
            DropIndex("dbo.Kisilers", new[] { "İletisimId" });
            DropTable("dbo.Kisilers");
            DropTable("dbo.İletisim");
        }
    }
}
