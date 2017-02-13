namespace E_School_Diary.WebClient.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
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
                        AspNetUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers1", t => t.AspNetUser_Id)
                .Index(t => t.RoleId)
                .Index(t => t.AspNetUser_Id);
            
            CreateTable(
                "dbo.AspNetUsers1",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        AdditionalInfo = c.String(),
                        Age = c.Int(nullable: false),
                        ChildId = c.String(maxLength: 128),
                        ConfirmIdentity = c.String(),
                        FirstName = c.String(),
                        MiddleName = c.String(),
                        LastName = c.String(),
                        ImageUrl = c.String(),
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
                        AspNetUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers1", t => t.ChildId)
                .ForeignKey("dbo.AspNetUsers1", t => t.FormMasterId)
                .ForeignKey("dbo.StudentClasses", t => t.StudentClassId)
                .ForeignKey("dbo.AspNetUsers1", t => t.AspNetUser_Id)
                .Index(t => t.ChildId)
                .Index(t => t.FormMasterId)
                .Index(t => t.StudentClassId)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex")
                .Index(t => t.AspNetUser_Id);
            
            CreateTable(
                "dbo.AspNetRoles1",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetUserClaims1",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        AspNetUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers1", t => t.AspNetUser_Id)
                .Index(t => t.AspNetUser_Id);
            
            CreateTable(
                "dbo.AspNetUserLogins1",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                        AspNetUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers1", t => t.AspNetUser_Id)
                .Index(t => t.AspNetUser_Id);
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        AspNetUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers1", t => t.AspNetUser_Id)
                .Index(t => t.AspNetUser_Id);
            
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
                        Title = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.StudentClasses", t => t.StudentClassId)
                .ForeignKey("dbo.AspNetUsers1", t => t.TeacherId)
                .Index(t => t.StudentClassId)
                .Index(t => t.TeacherId);
            
            CreateTable(
                "dbo.StudentClasses",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                        AspNetUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers1", t => t.AspNetUser_Id)
                .Index(t => t.AspNetUser_Id);
            
            CreateTable(
                "dbo.Marks",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        StudentId = c.String(maxLength: 128),
                        Subject = c.Int(nullable: false),
                        Value = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers1", t => t.StudentId)
                .Index(t => t.StudentId);
            
            CreateTable(
                "dbo.Messages",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Content = c.String(),
                        From = c.String(),
                        SendOn = c.DateTime(nullable: false),
                        AspNetUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers1", t => t.AspNetUser_Id)
                .Index(t => t.AspNetUser_Id);
            
            CreateTable(
                "dbo.AspNetUserAspNetRoles",
                c => new
                    {
                        AspNetUser_Id = c.String(nullable: false, maxLength: 128),
                        AspNetRole_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.AspNetUser_Id, t.AspNetRole_Id })
                .ForeignKey("dbo.AspNetUsers1", t => t.AspNetUser_Id, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles1", t => t.AspNetRole_Id, cascadeDelete: true)
                .Index(t => t.AspNetUser_Id)
                .Index(t => t.AspNetRole_Id);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers1", t => t.Id)
                .Index(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "Id", "dbo.AspNetUsers1");
            DropForeignKey("dbo.AspNetUserRoles", "AspNetUser_Id", "dbo.AspNetUsers1");
            DropForeignKey("dbo.AspNetUsers1", "AspNetUser_Id", "dbo.AspNetUsers1");
            DropForeignKey("dbo.Messages", "AspNetUser_Id", "dbo.AspNetUsers1");
            DropForeignKey("dbo.Marks", "StudentId", "dbo.AspNetUsers1");
            DropForeignKey("dbo.AspNetUserLogins", "AspNetUser_Id", "dbo.AspNetUsers1");
            DropForeignKey("dbo.Lectures", "TeacherId", "dbo.AspNetUsers1");
            DropForeignKey("dbo.AspNetUsers1", "StudentClassId", "dbo.StudentClasses");
            DropForeignKey("dbo.Lectures", "StudentClassId", "dbo.StudentClasses");
            DropForeignKey("dbo.AspNetUsers1", "FormMasterId", "dbo.AspNetUsers1");
            DropForeignKey("dbo.AspNetUserClaims", "AspNetUser_Id", "dbo.AspNetUsers1");
            DropForeignKey("dbo.AspNetUsers1", "ChildId", "dbo.AspNetUsers1");
            DropForeignKey("dbo.AspNetUserLogins1", "AspNetUser_Id", "dbo.AspNetUsers1");
            DropForeignKey("dbo.AspNetUserClaims1", "AspNetUser_Id", "dbo.AspNetUsers1");
            DropForeignKey("dbo.AspNetUserAspNetRoles", "AspNetRole_Id", "dbo.AspNetRoles1");
            DropForeignKey("dbo.AspNetUserAspNetRoles", "AspNetUser_Id", "dbo.AspNetUsers1");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropIndex("dbo.AspNetUsers", new[] { "Id" });
            DropIndex("dbo.AspNetUserAspNetRoles", new[] { "AspNetRole_Id" });
            DropIndex("dbo.AspNetUserAspNetRoles", new[] { "AspNetUser_Id" });
            DropIndex("dbo.Messages", new[] { "AspNetUser_Id" });
            DropIndex("dbo.Marks", new[] { "StudentId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "AspNetUser_Id" });
            DropIndex("dbo.Lectures", new[] { "TeacherId" });
            DropIndex("dbo.Lectures", new[] { "StudentClassId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "AspNetUser_Id" });
            DropIndex("dbo.AspNetUserLogins1", new[] { "AspNetUser_Id" });
            DropIndex("dbo.AspNetUserClaims1", new[] { "AspNetUser_Id" });
            DropIndex("dbo.AspNetUsers1", new[] { "AspNetUser_Id" });
            DropIndex("dbo.AspNetUsers1", "UserNameIndex");
            DropIndex("dbo.AspNetUsers1", new[] { "StudentClassId" });
            DropIndex("dbo.AspNetUsers1", new[] { "FormMasterId" });
            DropIndex("dbo.AspNetUsers1", new[] { "ChildId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "AspNetUser_Id" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserAspNetRoles");
            DropTable("dbo.Messages");
            DropTable("dbo.Marks");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.StudentClasses");
            DropTable("dbo.Lectures");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUserLogins1");
            DropTable("dbo.AspNetUserClaims1");
            DropTable("dbo.AspNetRoles1");
            DropTable("dbo.AspNetUsers1");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
        }
    }
}
