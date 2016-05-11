namespace eObchod.Server.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NullableDates : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Admittances", "DischargeDate", c => c.DateTime());
            AlterColumn("dbo.MedicineHistoryItems", "EndDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.MedicineHistoryItems", "EndDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Admittances", "DischargeDate", c => c.DateTime(nullable: false));
        }
    }
}
