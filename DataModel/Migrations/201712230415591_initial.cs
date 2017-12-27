namespace DataModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        city_name = c.String(nullable: false, maxLength: 128),
                        country_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        first_name = c.String(nullable: false, maxLength: 128),
                        last_name = c.String(nullable: false, maxLength: 128),
                        company_name = c.String(maxLength: 128),
                        VAT_ID = c.String(maxLength: 64),
                        city_id = c.Int(nullable: false),
                        client_address = c.String(nullable: false, unicode: false, storeType: "text"),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Colours",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        country_name = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.FeaturedItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ImageId = c.Int(nullable: false),
                        FeaturedImage_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Images", t => t.FeaturedImage_Id)
                .Index(t => t.FeaturedImage_Id);
            
            CreateTable(
                "dbo.Images",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ImageUri = c.String(),
                        Name = c.String(),
                        BaseColour = c.String(),
                        Caption = c.String(),
                        Categoty = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Materials",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Payment_data",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        payment_type_id = c.Int(nullable: false),
                        data_name = c.String(nullable: false, maxLength: 255),
                        data_type = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Payment_details",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        shipment_id = c.Int(nullable: false),
                        payment_data_id = c.Int(nullable: false),
                        value = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Payment_type",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        type_name = c.String(nullable: false, maxLength: 64),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Product_type",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        type_name = c.String(nullable: false, maxLength: 64),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        product_name = c.String(nullable: false, maxLength: 64),
                        product_description = c.String(nullable: false, maxLength: 255),
                        product_type_id = c.Int(nullable: false),
                        unit = c.String(nullable: false, maxLength: 16),
                        price_per_unit = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PreviewImageId = c.Int(nullable: false),
                        all_image_ids = c.String(),
                        all_vendors = c.String(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Images", t => t.PreviewImageId, cascadeDelete: true)
                .Index(t => t.PreviewImageId);
            
            CreateTable(
                "dbo.Sarees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MaterialId = c.Int(nullable: false),
                        ColourId = c.Int(nullable: false),
                        ImageId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Colours", t => t.ColourId, cascadeDelete: true)
                .ForeignKey("dbo.Images", t => t.ImageId, cascadeDelete: true)
                .ForeignKey("dbo.Materials", t => t.MaterialId, cascadeDelete: true)
                .Index(t => t.MaterialId)
                .Index(t => t.ColourId)
                .Index(t => t.ImageId);
            
            CreateTable(
                "dbo.Shipment_details",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        shipment_id = c.Int(nullable: false),
                        product_id = c.Int(nullable: false),
                        quanitity = c.Decimal(nullable: false, precision: 18, scale: 2),
                        price_per_unit = c.Decimal(nullable: false, precision: 18, scale: 2),
                        price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Shipment_status",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        shipment_id = c.Int(nullable: false),
                        status_catalog_id = c.Int(nullable: false),
                        status_time = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "timestamp"),
                        notes = c.String(unicode: false, storeType: "text"),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Shipment_type",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        type_name = c.String(nullable: false, maxLength: 64),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Shipments",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        client_id = c.Int(nullable: false),
                        time_created = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "timestamp"),
                        shipment_type_id = c.Int(nullable: false),
                        payment_type_id = c.Int(nullable: false),
                        shipping_address = c.String(nullable: false, unicode: false, storeType: "text"),
                        billing_address = c.String(nullable: false, unicode: false, storeType: "text"),
                        products_price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        delivery_cost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        discount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        final_price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Status_catalog",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        status_name = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Stocks",
                c => new
                    {
                        product_id = c.Int(nullable: false, identity: true),
                        in_stock = c.Decimal(nullable: false, precision: 18, scale: 2),
                        last_update_time = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "timestamp"),
                    })
                .PrimaryKey(t => t.product_id);
            
            CreateTable(
                "dbo.Vendors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Sarees", "MaterialId", "dbo.Materials");
            DropForeignKey("dbo.Sarees", "ImageId", "dbo.Images");
            DropForeignKey("dbo.Sarees", "ColourId", "dbo.Colours");
            DropForeignKey("dbo.Products", "PreviewImageId", "dbo.Images");
            DropForeignKey("dbo.FeaturedItems", "FeaturedImage_Id", "dbo.Images");
            DropIndex("dbo.Sarees", new[] { "ImageId" });
            DropIndex("dbo.Sarees", new[] { "ColourId" });
            DropIndex("dbo.Sarees", new[] { "MaterialId" });
            DropIndex("dbo.Products", new[] { "PreviewImageId" });
            DropIndex("dbo.FeaturedItems", new[] { "FeaturedImage_Id" });
            DropTable("dbo.Vendors");
            DropTable("dbo.Stocks");
            DropTable("dbo.Status_catalog");
            DropTable("dbo.Shipments");
            DropTable("dbo.Shipment_type");
            DropTable("dbo.Shipment_status");
            DropTable("dbo.Shipment_details");
            DropTable("dbo.Sarees");
            DropTable("dbo.Products");
            DropTable("dbo.Product_type");
            DropTable("dbo.Payment_type");
            DropTable("dbo.Payment_details");
            DropTable("dbo.Payment_data");
            DropTable("dbo.Materials");
            DropTable("dbo.Images");
            DropTable("dbo.FeaturedItems");
            DropTable("dbo.Countries");
            DropTable("dbo.Colours");
            DropTable("dbo.Clients");
            DropTable("dbo.Cities");
        }
    }
}
