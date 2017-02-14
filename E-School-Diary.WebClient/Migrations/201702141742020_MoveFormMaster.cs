namespace E_School_Diary.WebClient.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MoveFormMaster : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Users", "FormMasterId", "dbo.Users");
            DropIndex("dbo.Users", new[] { "FormMasterId" });
            DropIndex("dbo.Users", new[] { "User_Id" });
            DropColumn("dbo.Users", "ChildId");
            RenameColumn(table: "dbo.Users", name: "User_Id", newName: "ChildId");
            AddColumn("dbo.StudentClasses", "FormMasterId", c => c.String(maxLength: 128));
            CreateIndex("dbo.StudentClasses", "FormMasterId");
            AddForeignKey("dbo.StudentClasses", "FormMasterId", "dbo.Users", "Id");
            DropColumn("dbo.Users", "FormMasterId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "FormMasterId", c => c.String(maxLength: 128));
            DropForeignKey("dbo.StudentClasses", "FormMasterId", "dbo.Users");
            DropIndex("dbo.StudentClasses", new[] { "FormMasterId" });
            DropColumn("dbo.StudentClasses", "FormMasterId");
            RenameColumn(table: "dbo.Users", name: "ChildId", newName: "User_Id");
            AddColumn("dbo.Users", "ChildId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Users", "User_Id");
            CreateIndex("dbo.Users", "FormMasterId");
            AddForeignKey("dbo.Users", "FormMasterId", "dbo.Users", "Id");
        }
    }
}
