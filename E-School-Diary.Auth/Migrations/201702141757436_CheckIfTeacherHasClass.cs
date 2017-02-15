namespace E_School_Diary.Auth.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CheckIfTeacherHasClass : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "IsFreeTeacher", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "IsFreeTeacher");
        }
    }
}
