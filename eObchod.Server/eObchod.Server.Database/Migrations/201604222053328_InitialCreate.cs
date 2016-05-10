namespace eObchod.Server.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admittances",
                c => new
                    {
                        BlockId = c.Int(nullable: false),
                        WardId = c.Int(nullable: false),
                        PatientPesel = c.String(nullable: false, maxLength: 128),
                        AdmittanceDate = c.DateTime(nullable: false),
                        DischargeDate = c.DateTime(nullable: false),
                        Current = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => new { t.BlockId, t.WardId, t.PatientPesel, t.AdmittanceDate })
                .ForeignKey("dbo.Patients", t => t.PatientPesel)
                .ForeignKey("dbo.Wards", t => new { t.BlockId, t.WardId })
                .Index(t => new { t.BlockId, t.WardId })
                .Index(t => t.PatientPesel);
            
            CreateTable(
                "dbo.Patients",
                c => new
                    {
                        BlockId = c.Int(nullable: false),
                        WardId = c.Int(nullable: false),
                        RoomId = c.Int(nullable: false),
                        Pesel = c.String(nullable: false, maxLength: 128),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Gender = c.Int(nullable: false),
                        BirthDate = c.DateTime(nullable: false),
                        MainBookNumber = c.String(),
                        IsAdmitted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Pesel)
                .ForeignKey("dbo.Rooms", t => new { t.BlockId, t.WardId, t.RoomId })
                .Index(t => new { t.BlockId, t.WardId, t.RoomId });
            
            CreateTable(
                "dbo.DiagnoseHistoryItems",
                c => new
                    {
                        PatientPesel = c.String(nullable: false, maxLength: 128),
                        DiagnoseId = c.String(nullable: false, maxLength: 128),
                        Date = c.DateTime(nullable: false),
                        Comment = c.String(),
                    })
                .PrimaryKey(t => new { t.PatientPesel, t.DiagnoseId, t.Date })
                .ForeignKey("dbo.Diagnoses", t => t.DiagnoseId)
                .ForeignKey("dbo.Patients", t => t.PatientPesel)
                .Index(t => t.PatientPesel)
                .Index(t => t.DiagnoseId);
            
            CreateTable(
                "dbo.Diagnoses",
                c => new
                    {
                        DiagnoseId = c.String(nullable: false, maxLength: 128),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.DiagnoseId);
            
            CreateTable(
                "dbo.MedicineHistoryItems",
                c => new
                    {
                        PatientPesel = c.String(nullable: false, maxLength: 128),
                        ATC = c.String(nullable: false, maxLength: 128),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        Note = c.String(),
                    })
                .PrimaryKey(t => new { t.PatientPesel, t.ATC, t.StartDate })
                .ForeignKey("dbo.Medicines", t => t.ATC)
                .ForeignKey("dbo.Patients", t => t.PatientPesel)
                .Index(t => t.PatientPesel)
                .Index(t => t.ATC);
            
            CreateTable(
                "dbo.Medicines",
                c => new
                    {
                        ATC = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        DDD = c.Single(nullable: false),
                        Unit = c.Int(nullable: false),
                        AdministrationRoute = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ATC);
            
            CreateTable(
                "dbo.ProcedureHistoryItems",
                c => new
                    {
                        PatientPesel = c.String(nullable: false, maxLength: 128),
                        ProcedureId = c.String(nullable: false, maxLength: 128),
                        Date = c.DateTime(nullable: false),
                        Comment = c.String(),
                    })
                .PrimaryKey(t => new { t.PatientPesel, t.ProcedureId, t.Date })
                .ForeignKey("dbo.Patients", t => t.PatientPesel)
                .ForeignKey("dbo.Procedures", t => t.ProcedureId)
                .Index(t => t.PatientPesel)
                .Index(t => t.ProcedureId);
            
            CreateTable(
                "dbo.Parameters",
                c => new
                    {
                        PatientPesel = c.String(nullable: false, maxLength: 128),
                        ProcedureId = c.String(nullable: false, maxLength: 128),
                        Date = c.DateTime(nullable: false),
                        Name = c.String(nullable: false, maxLength: 128),
                        Value = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.PatientPesel, t.ProcedureId, t.Date, t.Name, t.Value })
                .ForeignKey("dbo.ProcedureHistoryItems", t => new { t.PatientPesel, t.ProcedureId, t.Date })
                .Index(t => new { t.PatientPesel, t.ProcedureId, t.Date });
            
            CreateTable(
                "dbo.Procedures",
                c => new
                    {
                        ProcedureId = c.String(nullable: false, maxLength: 128),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.ProcedureId);
            
            CreateTable(
                "dbo.Rooms",
                c => new
                    {
                        BlockId = c.Int(nullable: false),
                        WardId = c.Int(nullable: false),
                        RoomId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => new { t.BlockId, t.WardId, t.RoomId })
                .ForeignKey("dbo.Wards", t => new { t.BlockId, t.WardId })
                .Index(t => new { t.BlockId, t.WardId });
            
            CreateTable(
                "dbo.Wards",
                c => new
                    {
                        BlockId = c.Int(nullable: false),
                        WardId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => new { t.BlockId, t.WardId })
                .ForeignKey("dbo.Blocks", t => t.BlockId)
                .Index(t => t.BlockId);
            
            CreateTable(
                "dbo.Blocks",
                c => new
                    {
                        BlockId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.BlockId);
            
            CreateTable(
                "dbo.WardBookNumberItems",
                c => new
                    {
                        BlockId = c.Int(nullable: false),
                        WardId = c.Int(nullable: false),
                        PatientPesel = c.String(nullable: false, maxLength: 128),
                        WardBookNumber = c.String(),
                    })
                .PrimaryKey(t => new { t.BlockId, t.WardId, t.PatientPesel })
                .ForeignKey("dbo.Patients", t => t.PatientPesel)
                .ForeignKey("dbo.Wards", t => new { t.BlockId, t.WardId })
                .Index(t => new { t.BlockId, t.WardId })
                .Index(t => t.PatientPesel);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Admittances", new[] { "BlockId", "WardId" }, "dbo.Wards");
            DropForeignKey("dbo.WardBookNumberItems", new[] { "BlockId", "WardId" }, "dbo.Wards");
            DropForeignKey("dbo.WardBookNumberItems", "PatientPesel", "dbo.Patients");
            DropForeignKey("dbo.Patients", new[] { "BlockId", "WardId", "RoomId" }, "dbo.Rooms");
            DropForeignKey("dbo.Rooms", new[] { "BlockId", "WardId" }, "dbo.Wards");
            DropForeignKey("dbo.Wards", "BlockId", "dbo.Blocks");
            DropForeignKey("dbo.ProcedureHistoryItems", "ProcedureId", "dbo.Procedures");
            DropForeignKey("dbo.ProcedureHistoryItems", "PatientPesel", "dbo.Patients");
            DropForeignKey("dbo.Parameters", new[] { "PatientPesel", "ProcedureId", "Date" }, "dbo.ProcedureHistoryItems");
            DropForeignKey("dbo.MedicineHistoryItems", "PatientPesel", "dbo.Patients");
            DropForeignKey("dbo.MedicineHistoryItems", "ATC", "dbo.Medicines");
            DropForeignKey("dbo.DiagnoseHistoryItems", "PatientPesel", "dbo.Patients");
            DropForeignKey("dbo.DiagnoseHistoryItems", "DiagnoseId", "dbo.Diagnoses");
            DropForeignKey("dbo.Admittances", "PatientPesel", "dbo.Patients");
            DropIndex("dbo.WardBookNumberItems", new[] { "PatientPesel" });
            DropIndex("dbo.WardBookNumberItems", new[] { "BlockId", "WardId" });
            DropIndex("dbo.Wards", new[] { "BlockId" });
            DropIndex("dbo.Rooms", new[] { "BlockId", "WardId" });
            DropIndex("dbo.Parameters", new[] { "PatientPesel", "ProcedureId", "Date" });
            DropIndex("dbo.ProcedureHistoryItems", new[] { "ProcedureId" });
            DropIndex("dbo.ProcedureHistoryItems", new[] { "PatientPesel" });
            DropIndex("dbo.MedicineHistoryItems", new[] { "ATC" });
            DropIndex("dbo.MedicineHistoryItems", new[] { "PatientPesel" });
            DropIndex("dbo.DiagnoseHistoryItems", new[] { "DiagnoseId" });
            DropIndex("dbo.DiagnoseHistoryItems", new[] { "PatientPesel" });
            DropIndex("dbo.Patients", new[] { "BlockId", "WardId", "RoomId" });
            DropIndex("dbo.Admittances", new[] { "PatientPesel" });
            DropIndex("dbo.Admittances", new[] { "BlockId", "WardId" });
            DropTable("dbo.WardBookNumberItems");
            DropTable("dbo.Blocks");
            DropTable("dbo.Wards");
            DropTable("dbo.Rooms");
            DropTable("dbo.Procedures");
            DropTable("dbo.Parameters");
            DropTable("dbo.ProcedureHistoryItems");
            DropTable("dbo.Medicines");
            DropTable("dbo.MedicineHistoryItems");
            DropTable("dbo.Diagnoses");
            DropTable("dbo.DiagnoseHistoryItems");
            DropTable("dbo.Patients");
            DropTable("dbo.Admittances");
        }
    }
}
