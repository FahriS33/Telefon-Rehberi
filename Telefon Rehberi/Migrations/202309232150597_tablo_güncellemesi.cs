namespace Telefon_Rehberi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tablo_güncellemesi : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.İletisim", newName: "Şehirler");
            RenameTable(name: "dbo.Kisilers", newName: "kisiler");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.kisiler", newName: "Kisilers");
            RenameTable(name: "dbo.Şehirler", newName: "İletisim");
        }
    }
}
