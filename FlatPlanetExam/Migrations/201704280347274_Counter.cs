namespace FlatPlanetExam.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Counter : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Counter",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Counter = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Counter");
        }
    }
}
