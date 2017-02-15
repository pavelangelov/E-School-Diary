namespace E_School_Diary.Auth.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUbiqueStudentClassName : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.StudentClasses", "Name", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.StudentClasses", new[] { "Name" });
        }
    }
}
