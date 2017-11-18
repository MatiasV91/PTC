namespace PTCData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class productos : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Productos",
                c => new
                    {
                        ProductosId = c.Int(nullable: false, identity: true),
                        NombreProducto = c.String(nullable: false, maxLength: 150),
                        FechaIntroduccion = c.DateTime(nullable: false),
                        Url = c.String(nullable: false, maxLength: 2000),
                        Precio = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ProductosId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Productos");
        }
    }
}
