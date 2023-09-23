namespace Telefon_Rehberi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Dbolustur1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Kisilers", "Telefon", c => c.String());
            AddColumn("dbo.Kisilers", "Email", c => c.String());
            DropColumn("dbo.İletisim", "TelefonN");
            DropColumn("dbo.İletisim", "Email");
        }
        
        public override void Down()
        {
            AddColumn("dbo.İletisim", "Email", c => c.String());
            AddColumn("dbo.İletisim", "TelefonN", c => c.String());
            DropColumn("dbo.Kisilers", "Email");
            DropColumn("dbo.Kisilers", "Telefon");
        }
    }
}
