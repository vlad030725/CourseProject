namespace ComputerStore.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "public.Company",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "public.Product",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Name = c.String(),
                        Price = c.Int(),
                        PricePurchase = c.Int(),
                        Count = c.Int(),
                        IdCompany = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("public.Company", t => t.IdCompany)
                .Index(t => t.IdCompany);
            
            CreateTable(
                "public.CustomRow",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        IdCustom = c.Int(),
                        IdProduct = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("public.Custom", t => t.IdCustom)
                .ForeignKey("public.Product", t => t.IdProduct)
                .Index(t => t.IdCustom)
                .Index(t => t.IdProduct);
            
            CreateTable(
                "public.Custom",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Sum = c.Int(),
                        IdUser = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "public.User",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Name = c.String(),
                        Login = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("public.Product", "IdCompany", "public.Company");
            DropForeignKey("public.CustomRow", "IdProduct", "public.Product");
            DropForeignKey("public.CustomRow", "IdCustom", "public.Custom");
            DropIndex("public.CustomRow", new[] { "IdProduct" });
            DropIndex("public.CustomRow", new[] { "IdCustom" });
            DropIndex("public.Product", new[] { "IdCompany" });
            DropTable("public.User");
            DropTable("public.Custom");
            DropTable("public.CustomRow");
            DropTable("public.Product");
            DropTable("public.Company");
        }
    }
}
