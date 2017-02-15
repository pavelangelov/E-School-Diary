namespace E_School_Diary.Auth.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        AdditionalInfo = c.String(maxLength: 150),
                        Age = c.Int(nullable: false),
                        ChildId = c.String(maxLength: 128),
                        ConfirmIdentity = c.String(),
                        FirstName = c.String(nullable: false, maxLength: 20),
                        MiddleName = c.String(),
                        LastName = c.String(nullable: false, maxLength: 20),
                        ImageUrl = c.String(),
                        UserType = c.Int(nullable: false),
                        FormMasterId = c.String(maxLength: 128),
                        StudentClassId = c.String(maxLength: 128),
                        Subject = c.Int(nullable: false),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                        StudentClass_Id = c.String(maxLength: 128),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.ChildId)
                .ForeignKey("dbo.Users", t => t.FormMasterId)
                .ForeignKey("dbo.StudentClasses", t => t.StudentClass_Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .ForeignKey("dbo.StudentClasses", t => t.StudentClassId)
                .Index(t => t.ChildId)
                .Index(t => t.FormMasterId)
                .Index(t => t.StudentClassId)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex")
                .Index(t => t.StudentClass_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Lectures",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        End = c.DateTime(),
                        Start = c.DateTime(),
                        Status = c.Int(nullable: false),
                        StudentClassId = c.String(maxLength: 128),
                        Subject = c.Int(nullable: false),
                        TeacherId = c.String(maxLength: 128),
                        Title = c.String(nullable: false, maxLength: 35),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.StudentClasses", t => t.StudentClassId)
                .ForeignKey("dbo.Users", t => t.TeacherId)
                .Index(t => t.StudentClassId)
                .Index(t => t.TeacherId);
            
            CreateTable(
                "dbo.StudentClasses",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 6),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Marks",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        StudentId = c.String(nullable: false, maxLength: 128),
                        Subject = c.Int(nullable: false),
                        Value = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.StudentId, cascadeDelete: true)
                .Index(t => t.StudentId);
            
            CreateTable(
                "dbo.Messages",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Content = c.String(nullable: false, maxLength: 100),
                        SendFrom = c.String(nullable: false, maxLength: 20),
                        SendOn = c.DateTime(nullable: false),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.Id)
                .Index(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "Id", "dbo.Users");
            DropForeignKey("dbo.StudentClasses", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Users", "StudentClassId", "dbo.StudentClasses");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.Users");
            DropForeignKey("dbo.Users", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Messages", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Marks", "StudentId", "dbo.Users");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.Users");
            DropForeignKey("dbo.Lectures", "TeacherId", "dbo.Users");
            DropForeignKey("dbo.Users", "StudentClass_Id", "dbo.StudentClasses");
            DropForeignKey("dbo.Lectures", "StudentClassId", "dbo.StudentClasses");
            DropForeignKey("dbo.Users", "FormMasterId", "dbo.Users");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.Users");
            DropForeignKey("dbo.Users", "ChildId", "dbo.Users");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropIndex("dbo.AspNetUsers", new[] { "Id" });
            DropIndex("dbo.Messages", new[] { "User_Id" });
            DropIndex("dbo.Marks", new[] { "StudentId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.StudentClasses", new[] { "User_Id" });
            DropIndex("dbo.Lectures", new[] { "TeacherId" });
            DropIndex("dbo.Lectures", new[] { "StudentClassId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.Users", new[] { "User_Id" });
            DropIndex("dbo.Users", new[] { "StudentClass_Id" });
            DropIndex("dbo.Users", "UserNameIndex");
            DropIndex("dbo.Users", new[] { "StudentClassId" });
            DropIndex("dbo.Users", new[] { "FormMasterId" });
            DropIndex("dbo.Users", new[] { "ChildId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Messages");
            DropTable("dbo.Marks");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.StudentClasses");
            DropTable("dbo.Lectures");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.Users");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
        }
    }
}
