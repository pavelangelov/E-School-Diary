namespace E_School_Diary.WebClient.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedAppUser : DbMigration
    {
        public override void Up()
        {
            //DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            //DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            //DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            //DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            //DropIndex("dbo.AspNetUsers", "UserNameIndex");
            //DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            //DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            //CreateTable(
            //    "dbo.AspNetUsers1",
            //    c => new
            //        {
            //            Id = c.String(nullable: false, maxLength: 128),
            //            AdditionalInfo = c.String(),
            //            Age = c.Int(nullable: false),
            //            ChildId = c.String(maxLength: 128),
            //            ConfirmIdentity = c.String(),
            //            FirstName = c.String(),
            //            MiddleName = c.String(),
            //            LastName = c.String(),
            //            ImageUrl = c.String(),
            //            FormMasterId = c.String(maxLength: 128),
            //            StudentClassId = c.String(maxLength: 128),
            //            Subject = c.Int(nullable: false),
            //            Email = c.String(maxLength: 256),
            //            EmailConfirmed = c.Boolean(nullable: false),
            //            PasswordHash = c.String(),
            //            SecurityStamp = c.String(),
            //            PhoneNumber = c.String(),
            //            PhoneNumberConfirmed = c.Boolean(nullable: false),
            //            TwoFactorEnabled = c.Boolean(nullable: false),
            //            LockoutEndDateUtc = c.DateTime(),
            //            LockoutEnabled = c.Boolean(nullable: false),
            //            AccessFailedCount = c.Int(nullable: false),
            //            UserName = c.String(nullable: false, maxLength: 256),
            //            AspNetUser_Id = c.String(maxLength: 128),
            //        })
            //    .PrimaryKey(t => t.Id)
            //    .ForeignKey("dbo.AspNetUsers1", t => t.ChildId)
            //    .ForeignKey("dbo.AspNetUsers1", t => t.FormMasterId)
            //    .ForeignKey("dbo.StudentClasses", t => t.StudentClassId)
            //    .ForeignKey("dbo.AspNetUsers1", t => t.AspNetUser_Id)
            //    .Index(t => t.ChildId)
            //    .Index(t => t.FormMasterId)
            //    .Index(t => t.StudentClassId)
            //    .Index(t => t.UserName, unique: true, name: "UserNameIndex")
            //    .Index(t => t.AspNetUser_Id);
            
            //CreateTable(
            //    "dbo.AspNetRoles1",
            //    c => new
            //        {
            //            Id = c.String(nullable: false, maxLength: 128),
            //            Name = c.String(nullable: false, maxLength: 256),
            //        })
            //    .PrimaryKey(t => t.Id);
            
            //CreateTable(
            //    "dbo.AspNetUserClaims1",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            UserId = c.String(nullable: false, maxLength: 128),
            //            ClaimType = c.String(),
            //            ClaimValue = c.String(),
            //            AspNetUser_Id = c.String(maxLength: 128),
            //        })
            //    .PrimaryKey(t => t.Id)
            //    .ForeignKey("dbo.AspNetUsers1", t => t.AspNetUser_Id)
            //    .Index(t => t.AspNetUser_Id);
            
            //CreateTable(
            //    "dbo.AspNetUserLogins1",
            //    c => new
            //        {
            //            LoginProvider = c.String(nullable: false, maxLength: 128),
            //            ProviderKey = c.String(nullable: false, maxLength: 128),
            //            UserId = c.String(nullable: false, maxLength: 128),
            //            AspNetUser_Id = c.String(maxLength: 128),
            //        })
            //    .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
            //    .ForeignKey("dbo.AspNetUsers1", t => t.AspNetUser_Id)
            //    .Index(t => t.AspNetUser_Id);
            
            //CreateTable(
            //    "dbo.Lectures",
            //    c => new
            //        {
            //            Id = c.String(nullable: false, maxLength: 128),
            //            End = c.DateTime(),
            //            Start = c.DateTime(),
            //            Status = c.Int(nullable: false),
            //            StudentClassId = c.String(maxLength: 128),
            //            Subject = c.Int(nullable: false),
            //            TeacherId = c.String(maxLength: 128),
            //            Title = c.String(),
            //        })
            //    .PrimaryKey(t => t.Id)
            //    .ForeignKey("dbo.StudentClasses", t => t.StudentClassId)
            //    .ForeignKey("dbo.AspNetUsers1", t => t.TeacherId)
            //    .Index(t => t.StudentClassId)
            //    .Index(t => t.TeacherId);
            
            //CreateTable(
            //    "dbo.StudentClasses",
            //    c => new
            //        {
            //            Id = c.String(nullable: false, maxLength: 128),
            //            Name = c.String(),
            //        })
            //    .PrimaryKey(t => t.Id);
            
            //CreateTable(
            //    "dbo.Marks",
            //    c => new
            //        {
            //            Id = c.String(nullable: false, maxLength: 128),
            //            StudentId = c.String(maxLength: 128),
            //            Subject = c.Int(nullable: false),
            //            Value = c.Double(nullable: false),
            //        })
            //    .PrimaryKey(t => t.Id)
            //    .ForeignKey("dbo.AspNetUsers1", t => t.StudentId)
            //    .Index(t => t.StudentId);
            
            //CreateTable(
            //    "dbo.Messages",
            //    c => new
            //        {
            //            Id = c.String(nullable: false, maxLength: 128),
            //            Content = c.String(),
            //            From = c.String(),
            //            SendOn = c.DateTime(nullable: false),
            //            AspNetUser_Id = c.String(maxLength: 128),
            //        })
            //    .PrimaryKey(t => t.Id)
            //    .ForeignKey("dbo.AspNetUsers1", t => t.AspNetUser_Id)
            //    .Index(t => t.AspNetUser_Id);
            
            //CreateTable(
            //    "dbo.AspNetUserAspNetRoles",
            //    c => new
            //        {
            //            AspNetUser_Id = c.String(nullable: false, maxLength: 128),
            //            AspNetRole_Id = c.String(nullable: false, maxLength: 128),
            //        })
            //    .PrimaryKey(t => new { t.AspNetUser_Id, t.AspNetRole_Id })
            //    .ForeignKey("dbo.AspNetUsers1", t => t.AspNetUser_Id, cascadeDelete: true)
            //    .ForeignKey("dbo.AspNetRoles1", t => t.AspNetRole_Id, cascadeDelete: true)
            //    .Index(t => t.AspNetUser_Id)
            //    .Index(t => t.AspNetRole_Id);
            
            //AddColumn("dbo.AspNetUserRoles", "AspNetUser_Id", c => c.String(maxLength: 128));
            //AddColumn("dbo.AspNetUserClaims", "AspNetUser_Id", c => c.String(maxLength: 128));
            //AddColumn("dbo.AspNetUserLogins", "AspNetUser_Id", c => c.String(maxLength: 128));
            //AlterColumn("dbo.AspNetUserClaims", "UserId", c => c.String());
            //CreateIndex("dbo.AspNetUserRoles", "AspNetUser_Id");
            //CreateIndex("dbo.AspNetUserClaims", "AspNetUser_Id");
            //CreateIndex("dbo.AspNetUserLogins", "AspNetUser_Id");
            //CreateIndex("dbo.AspNetUsers", "Id");
            //AddForeignKey("dbo.AspNetUsers", "Id", "dbo.AspNetUsers1", "Id");
            //AddForeignKey("dbo.AspNetUserClaims", "AspNetUser_Id", "dbo.AspNetUsers1", "Id");
            //AddForeignKey("dbo.AspNetUserLogins", "AspNetUser_Id", "dbo.AspNetUsers1", "Id");
            //AddForeignKey("dbo.AspNetUserRoles", "AspNetUser_Id", "dbo.AspNetUsers1", "Id");
            //DropColumn("dbo.AspNetUsers", "Email");
            //DropColumn("dbo.AspNetUsers", "EmailConfirmed");
            //DropColumn("dbo.AspNetUsers", "PasswordHash");
            //DropColumn("dbo.AspNetUsers", "SecurityStamp");
            //DropColumn("dbo.AspNetUsers", "PhoneNumber");
            //DropColumn("dbo.AspNetUsers", "PhoneNumberConfirmed");
            //DropColumn("dbo.AspNetUsers", "TwoFactorEnabled");
            //DropColumn("dbo.AspNetUsers", "LockoutEndDateUtc");
            //DropColumn("dbo.AspNetUsers", "LockoutEnabled");
            //DropColumn("dbo.AspNetUsers", "AccessFailedCount");
            //DropColumn("dbo.AspNetUsers", "UserName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "UserName", c => c.String(nullable: false, maxLength: 256));
            AddColumn("dbo.AspNetUsers", "AccessFailedCount", c => c.Int(nullable: false));
            AddColumn("dbo.AspNetUsers", "LockoutEnabled", c => c.Boolean(nullable: false));
            AddColumn("dbo.AspNetUsers", "LockoutEndDateUtc", c => c.DateTime());
            AddColumn("dbo.AspNetUsers", "TwoFactorEnabled", c => c.Boolean(nullable: false));
            AddColumn("dbo.AspNetUsers", "PhoneNumberConfirmed", c => c.Boolean(nullable: false));
            AddColumn("dbo.AspNetUsers", "PhoneNumber", c => c.String());
            AddColumn("dbo.AspNetUsers", "SecurityStamp", c => c.String());
            AddColumn("dbo.AspNetUsers", "PasswordHash", c => c.String());
            AddColumn("dbo.AspNetUsers", "EmailConfirmed", c => c.Boolean(nullable: false));
            AddColumn("dbo.AspNetUsers", "Email", c => c.String(maxLength: 256));
            DropForeignKey("dbo.AspNetUserRoles", "AspNetUser_Id", "dbo.AspNetUsers1");
            DropForeignKey("dbo.AspNetUserLogins", "AspNetUser_Id", "dbo.AspNetUsers1");
            DropForeignKey("dbo.AspNetUserClaims", "AspNetUser_Id", "dbo.AspNetUsers1");
            DropForeignKey("dbo.AspNetUsers", "Id", "dbo.AspNetUsers1");
            DropForeignKey("dbo.AspNetUsers1", "AspNetUser_Id", "dbo.AspNetUsers1");
            DropForeignKey("dbo.Messages", "AspNetUser_Id", "dbo.AspNetUsers1");
            DropForeignKey("dbo.Marks", "StudentId", "dbo.AspNetUsers1");
            DropForeignKey("dbo.Lectures", "TeacherId", "dbo.AspNetUsers1");
            DropForeignKey("dbo.AspNetUsers1", "StudentClassId", "dbo.StudentClasses");
            DropForeignKey("dbo.Lectures", "StudentClassId", "dbo.StudentClasses");
            DropForeignKey("dbo.AspNetUsers1", "FormMasterId", "dbo.AspNetUsers1");
            DropForeignKey("dbo.AspNetUsers1", "ChildId", "dbo.AspNetUsers1");
            DropForeignKey("dbo.AspNetUserLogins1", "AspNetUser_Id", "dbo.AspNetUsers1");
            DropForeignKey("dbo.AspNetUserClaims1", "AspNetUser_Id", "dbo.AspNetUsers1");
            DropForeignKey("dbo.AspNetUserAspNetRoles", "AspNetRole_Id", "dbo.AspNetRoles1");
            DropForeignKey("dbo.AspNetUserAspNetRoles", "AspNetUser_Id", "dbo.AspNetUsers1");
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
            AlterColumn("dbo.AspNetUserClaims", "UserId", c => c.String(nullable: false, maxLength: 128));
            DropColumn("dbo.AspNetUserLogins", "AspNetUser_Id");
            DropColumn("dbo.AspNetUserClaims", "AspNetUser_Id");
            DropColumn("dbo.AspNetUserRoles", "AspNetUser_Id");
            DropTable("dbo.AspNetUserAspNetRoles");
            DropTable("dbo.Messages");
            DropTable("dbo.Marks");
            DropTable("dbo.StudentClasses");
            DropTable("dbo.Lectures");
            DropTable("dbo.AspNetUserLogins1");
            DropTable("dbo.AspNetUserClaims1");
            DropTable("dbo.AspNetRoles1");
            DropTable("dbo.AspNetUsers1");
            CreateIndex("dbo.AspNetUserLogins", "UserId");
            CreateIndex("dbo.AspNetUserClaims", "UserId");
            CreateIndex("dbo.AspNetUsers", "UserName", unique: true, name: "UserNameIndex");
            CreateIndex("dbo.AspNetUserRoles", "UserId");
            AddForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
    }
}
