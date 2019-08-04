namespace agbotwebservice.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Params",
                c => new
                {
                    ID = c.Int(nullable: false),
                    VehicleID = c.Int(nullable: false),
                    Name = c.String(),
                    Value = c.String(),
                    Type = c.String(),
                    Units = c.String(),
                    Timestamp = c.Int(nullable: false),
                    Message = c.String(),
                })
                .PrimaryKey(t => new { t.ID, t.VehicleID })
                .ForeignKey("dbo.VehicleInfoes", t => t.VehicleID, cascadeDelete: true)
                .Index(t => t.VehicleID);

            CreateTable(
                "dbo.VehicleInfoes",
                c => new
                {
                    ID = c.Int(nullable: false),
                    Version = c.String(),
                    Key = c.String(),
                })
                .PrimaryKey(t => t.ID);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Params", "VehicleID", "dbo.VehicleInfoes");
            DropIndex("dbo.Params", new[] { "VehicleID" });
            DropTable("dbo.VehicleInfoes");
            DropTable("dbo.Params");
        }
    }
}
