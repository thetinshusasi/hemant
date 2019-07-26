namespace Contact.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class intial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AddressType = c.Int(nullable: false),
                        Street = c.String(),
                        Street2 = c.String(),
                        StateId = c.Int(nullable: false),
                        CountryId = c.Int(nullable: false),
                        PinCode = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Countries", t => t.CountryId)
                .ForeignKey("dbo.States", t => t.StateId)
                .Index(t => t.StateId)
                .Index(t => t.CountryId);
            
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CountryCode = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Organisations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        SloganId = c.Int(nullable: false),
                        AddressId = c.Int(nullable: false),
                        Email = c.String(),
                        ContactNo = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Addresses", t => t.AddressId)
                .Index(t => t.AddressId);
            
            CreateTable(
                "dbo.States",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CountryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Countries", t => t.CountryId)
                .Index(t => t.CountryId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        PositionId = c.Int(),
                        OrganisationId = c.Int(),
                        AddressId = c.Int(),
                        MobileNo = c.String(),
                        AltMobileNo = c.String(),
                        Email = c.String(),
                        ContactId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Addresses", t => t.AddressId)
                .ForeignKey("dbo.Contacts", t => t.ContactId)
                .ForeignKey("dbo.Organisations", t => t.OrganisationId)
                .ForeignKey("dbo.Positions", t => t.PositionId)
                .Index(t => t.PositionId)
                .Index(t => t.OrganisationId)
                .Index(t => t.AddressId)
                .Index(t => t.ContactId);
            
            CreateTable(
                "dbo.Contacts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrganisationId = c.Int(nullable: false),
                        PositionId = c.Int(nullable: false),
                        LogoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Logoes", t => t.LogoId)
                .ForeignKey("dbo.Organisations", t => t.OrganisationId)
                .ForeignKey("dbo.Positions", t => t.PositionId)
                .Index(t => t.OrganisationId)
                .Index(t => t.PositionId)
                .Index(t => t.LogoId);
            
            CreateTable(
                "dbo.Logoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        OrganisationId = c.Int(nullable: false),
                        Image = c.Binary(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Organisations", t => t.OrganisationId)
                .Index(t => t.OrganisationId);
            
            CreateTable(
                "dbo.Positions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        OrganisationId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Organisations", t => t.OrganisationId)
                .Index(t => t.OrganisationId);
            
            CreateTable(
                "dbo.Slogans",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Message = c.String(),
                        OrganisationId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Organisations", t => t.OrganisationId)
                .Index(t => t.OrganisationId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Slogans", "OrganisationId", "dbo.Organisations");
            DropForeignKey("dbo.Users", "PositionId", "dbo.Positions");
            DropForeignKey("dbo.Users", "OrganisationId", "dbo.Organisations");
            DropForeignKey("dbo.Users", "ContactId", "dbo.Contacts");
            DropForeignKey("dbo.Contacts", "PositionId", "dbo.Positions");
            DropForeignKey("dbo.Positions", "OrganisationId", "dbo.Organisations");
            DropForeignKey("dbo.Contacts", "OrganisationId", "dbo.Organisations");
            DropForeignKey("dbo.Contacts", "LogoId", "dbo.Logoes");
            DropForeignKey("dbo.Logoes", "OrganisationId", "dbo.Organisations");
            DropForeignKey("dbo.Users", "AddressId", "dbo.Addresses");
            DropForeignKey("dbo.Addresses", "StateId", "dbo.States");
            DropForeignKey("dbo.States", "CountryId", "dbo.Countries");
            DropForeignKey("dbo.Organisations", "AddressId", "dbo.Addresses");
            DropForeignKey("dbo.Addresses", "CountryId", "dbo.Countries");
            DropIndex("dbo.Slogans", new[] { "OrganisationId" });
            DropIndex("dbo.Positions", new[] { "OrganisationId" });
            DropIndex("dbo.Logoes", new[] { "OrganisationId" });
            DropIndex("dbo.Contacts", new[] { "LogoId" });
            DropIndex("dbo.Contacts", new[] { "PositionId" });
            DropIndex("dbo.Contacts", new[] { "OrganisationId" });
            DropIndex("dbo.Users", new[] { "ContactId" });
            DropIndex("dbo.Users", new[] { "AddressId" });
            DropIndex("dbo.Users", new[] { "OrganisationId" });
            DropIndex("dbo.Users", new[] { "PositionId" });
            DropIndex("dbo.States", new[] { "CountryId" });
            DropIndex("dbo.Organisations", new[] { "AddressId" });
            DropIndex("dbo.Addresses", new[] { "CountryId" });
            DropIndex("dbo.Addresses", new[] { "StateId" });
            DropTable("dbo.Slogans");
            DropTable("dbo.Positions");
            DropTable("dbo.Logoes");
            DropTable("dbo.Contacts");
            DropTable("dbo.Users");
            DropTable("dbo.States");
            DropTable("dbo.Organisations");
            DropTable("dbo.Countries");
            DropTable("dbo.Addresses");
        }
    }
}
