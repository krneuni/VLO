namespace VLO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AsignacionTurnoes",
                c => new
                    {
                        IdAsignacion = c.Int(nullable: false, identity: true),
                        IdTurno = c.Int(nullable: false),
                        IdEmpleado = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdAsignacion)
                .ForeignKey("dbo.Turnos", t => t.IdTurno, cascadeDelete: true)
                .ForeignKey("dbo.Empleadoes", t => t.IdEmpleado, cascadeDelete: true)
                .Index(t => t.IdTurno)
                .Index(t => t.IdEmpleado);
            
            CreateTable(
                "dbo.Empleadoes",
                c => new
                    {
                        IdEmpleado = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 50),
                        Apellido = c.String(nullable: false, maxLength: 50),
                        Dui = c.String(nullable: false, maxLength: 9),
                        Edad = c.Int(nullable: false),
                        Telefono = c.String(nullable: false),
                        Direccion = c.String(nullable: false, maxLength: 150),
                        Mail = c.String(nullable: false),
                        Cargo = c.String(nullable: false, maxLength: 10),
                        Salario = c.Double(nullable: false),
                        Estado = c.Boolean(nullable: false),
                        IdGenero = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdEmpleado)
                .ForeignKey("dbo.Generoes", t => t.IdGenero, cascadeDelete: true)
                .Index(t => t.IdGenero);
            
            CreateTable(
                "dbo.Generoes",
                c => new
                    {
                        IdGenero = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 15),
                    })
                .PrimaryKey(t => t.IdGenero);
            
            CreateTable(
                "dbo.HExtras",
                c => new
                    {
                        IdExtras = c.Int(nullable: false, identity: true),
                        Cantidad = c.Int(nullable: false),
                        IdEmpleado = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdExtras)
                .ForeignKey("dbo.Empleadoes", t => t.IdEmpleado, cascadeDelete: true)
                .Index(t => t.IdEmpleado);
            
            CreateTable(
                "dbo.Pedidoes",
                c => new
                    {
                        IdPedido = c.Int(nullable: false, identity: true),
                        Cantidad = c.Int(nullable: false),
                        Cliente = c.String(nullable: false, maxLength: 75),
                        IdMesa = c.Int(nullable: false),
                        IdEmpleado = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdPedido)
                .ForeignKey("dbo.Empleadoes", t => t.IdEmpleado, cascadeDelete: true)
                .ForeignKey("dbo.Mesas", t => t.IdMesa, cascadeDelete: true)
                .Index(t => t.IdMesa)
                .Index(t => t.IdEmpleado);
            
            CreateTable(
                "dbo.Mesas",
                c => new
                    {
                        IdMesa = c.Int(nullable: false, identity: true),
                        NumMesa = c.String(nullable: false),
                        Estado = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.IdMesa);
            
            CreateTable(
                "dbo.Prestamos",
                c => new
                    {
                        IdPrestamo = c.Int(nullable: false, identity: true),
                        IdProducto = c.Int(nullable: false),
                        IdEmpleado = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdPrestamo)
                .ForeignKey("dbo.Empleadoes", t => t.IdEmpleado, cascadeDelete: true)
                .ForeignKey("dbo.Productos", t => t.IdProducto, cascadeDelete: true)
                .Index(t => t.IdProducto)
                .Index(t => t.IdEmpleado);
            
            CreateTable(
                "dbo.Productos",
                c => new
                    {
                        IdProducto = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 75),
                        Marca = c.String(maxLength: 75),
                        Cantidad = c.Double(nullable: false),
                        Fecha = c.String(nullable: false),
                        Descripcion = c.String(nullable: false, maxLength: 500),
                        CantidadMinima = c.Double(nullable: false),
                        UnidadMedida = c.String(nullable: false, maxLength: 25),
                        Estado = c.Boolean(nullable: false),
                        IdCategoria = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdProducto)
                .ForeignKey("dbo.Categorias", t => t.IdCategoria, cascadeDelete: true)
                .Index(t => t.IdCategoria);
            
            CreateTable(
                "dbo.Categorias",
                c => new
                    {
                        IdCategoria = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 75),
                    })
                .PrimaryKey(t => t.IdCategoria);
            
            CreateTable(
                "dbo.DetalleCompras",
                c => new
                    {
                        IdDetalle = c.Int(nullable: false, identity: true),
                        Cantidad = c.Double(nullable: false),
                        ProductoPedido = c.Int(nullable: false),
                        ProductoRecibido = c.Int(nullable: false),
                        PrecioUnit = c.Double(nullable: false),
                        FechaCompra = c.String(nullable: false),
                        PrecioTotal = c.Double(nullable: false),
                        Codigo = c.String(nullable: false),
                        IdProveedor = c.Int(nullable: false),
                        IdProducto = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdDetalle)
                .ForeignKey("dbo.Productos", t => t.IdProducto, cascadeDelete: true)
                .ForeignKey("dbo.Proveedores", t => t.IdProveedor, cascadeDelete: true)
                .Index(t => t.IdProveedor)
                .Index(t => t.IdProducto);
            
            CreateTable(
                "dbo.Proveedores",
                c => new
                    {
                        IdProveedor = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 75),
                        Direccion = c.String(nullable: false, maxLength: 150),
                        Telefono = c.String(nullable: false),
                        Mail = c.String(nullable: false),
                        NombreContacto = c.String(nullable: false, maxLength: 75),
                        Estado = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.IdProveedor);
            
            CreateTable(
                "dbo.Recetas",
                c => new
                    {
                        IdReceta = c.Int(nullable: false, identity: true),
                        CantidadUtilizada = c.Double(nullable: false),
                        IdProducto = c.Int(nullable: false),
                        IdMenu = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdReceta)
                .ForeignKey("dbo.Menus", t => t.IdMenu, cascadeDelete: true)
                .ForeignKey("dbo.Productos", t => t.IdProducto, cascadeDelete: true)
                .Index(t => t.IdProducto)
                .Index(t => t.IdMenu);
            
            CreateTable(
                "dbo.Menus",
                c => new
                    {
                        IdMenu = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 75),
                        Precio = c.Double(nullable: false),
                        Descripcion = c.String(nullable: false, maxLength: 500),
                        IdTipoMenu = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdMenu)
                .ForeignKey("dbo.TipoMenus", t => t.IdTipoMenu, cascadeDelete: true)
                .Index(t => t.IdTipoMenu);
            
            CreateTable(
                "dbo.DetallePedidoes",
                c => new
                    {
                        IdDetalle = c.Int(nullable: false, identity: true),
                        IdMenu = c.Int(nullable: false),
                        IdPedido = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdDetalle)
                .ForeignKey("dbo.Menus", t => t.IdMenu, cascadeDelete: true)
                .ForeignKey("dbo.Pedidoes", t => t.IdPedido, cascadeDelete: true)
                .Index(t => t.IdMenu)
                .Index(t => t.IdPedido);
            
            CreateTable(
                "dbo.TipoMenus",
                c => new
                    {
                        IdTipoMenu = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 75),
                    })
                .PrimaryKey(t => t.IdTipoMenu);
            
            CreateTable(
                "dbo.Turnos",
                c => new
                    {
                        IdTurno = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 25),
                        HoraInicial = c.String(nullable: false),
                        HoraFinal = c.String(nullable: false),
                        Empleado_IdEmpleado = c.Int(),
                    })
                .PrimaryKey(t => t.IdTurno)
                .ForeignKey("dbo.Empleadoes", t => t.Empleado_IdEmpleado)
                .Index(t => t.Empleado_IdEmpleado);
            
            CreateTable(
                "dbo.Usuarios",
                c => new
                    {
                        IdUser = c.Int(nullable: false, identity: true),
                        Username = c.String(nullable: false, maxLength: 50),
                        Password = c.String(nullable: false, maxLength: 50),
                        IdEmpleado = c.Int(nullable: false),
                        IdRol = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdUser)
                .ForeignKey("dbo.Empleadoes", t => t.IdEmpleado, cascadeDelete: true)
                .ForeignKey("dbo.Roles", t => t.IdRol, cascadeDelete: true)
                .Index(t => t.IdEmpleado)
                .Index(t => t.IdRol);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        IdRol = c.Int(nullable: false, identity: true),
                        Tipo = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.IdRol);
            
            CreateTable(
                "dbo.Facturas",
                c => new
                    {
                        NumFactura = c.Int(nullable: false, identity: true),
                        IdDetalle = c.Int(nullable: false),
                        Precio = c.Double(nullable: false),
                        Descuento = c.Double(nullable: false),
                        FechaFactura = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.NumFactura)
                .ForeignKey("dbo.DetallePedidoes", t => t.IdDetalle, cascadeDelete: true)
                .Index(t => t.IdDetalle);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Facturas", "IdDetalle", "dbo.DetallePedidoes");
            DropForeignKey("dbo.AsignacionTurnoes", "IdEmpleado", "dbo.Empleadoes");
            DropForeignKey("dbo.Usuarios", "IdRol", "dbo.Roles");
            DropForeignKey("dbo.Usuarios", "IdEmpleado", "dbo.Empleadoes");
            DropForeignKey("dbo.Turnos", "Empleado_IdEmpleado", "dbo.Empleadoes");
            DropForeignKey("dbo.AsignacionTurnoes", "IdTurno", "dbo.Turnos");
            DropForeignKey("dbo.Recetas", "IdProducto", "dbo.Productos");
            DropForeignKey("dbo.Recetas", "IdMenu", "dbo.Menus");
            DropForeignKey("dbo.Menus", "IdTipoMenu", "dbo.TipoMenus");
            DropForeignKey("dbo.DetallePedidoes", "IdPedido", "dbo.Pedidoes");
            DropForeignKey("dbo.DetallePedidoes", "IdMenu", "dbo.Menus");
            DropForeignKey("dbo.Prestamos", "IdProducto", "dbo.Productos");
            DropForeignKey("dbo.DetalleCompras", "IdProveedor", "dbo.Proveedores");
            DropForeignKey("dbo.DetalleCompras", "IdProducto", "dbo.Productos");
            DropForeignKey("dbo.Productos", "IdCategoria", "dbo.Categorias");
            DropForeignKey("dbo.Prestamos", "IdEmpleado", "dbo.Empleadoes");
            DropForeignKey("dbo.Pedidoes", "IdMesa", "dbo.Mesas");
            DropForeignKey("dbo.Pedidoes", "IdEmpleado", "dbo.Empleadoes");
            DropForeignKey("dbo.HExtras", "IdEmpleado", "dbo.Empleadoes");
            DropForeignKey("dbo.Empleadoes", "IdGenero", "dbo.Generoes");
            DropIndex("dbo.Facturas", new[] { "IdDetalle" });
            DropIndex("dbo.Usuarios", new[] { "IdRol" });
            DropIndex("dbo.Usuarios", new[] { "IdEmpleado" });
            DropIndex("dbo.Turnos", new[] { "Empleado_IdEmpleado" });
            DropIndex("dbo.DetallePedidoes", new[] { "IdPedido" });
            DropIndex("dbo.DetallePedidoes", new[] { "IdMenu" });
            DropIndex("dbo.Menus", new[] { "IdTipoMenu" });
            DropIndex("dbo.Recetas", new[] { "IdMenu" });
            DropIndex("dbo.Recetas", new[] { "IdProducto" });
            DropIndex("dbo.DetalleCompras", new[] { "IdProducto" });
            DropIndex("dbo.DetalleCompras", new[] { "IdProveedor" });
            DropIndex("dbo.Productos", new[] { "IdCategoria" });
            DropIndex("dbo.Prestamos", new[] { "IdEmpleado" });
            DropIndex("dbo.Prestamos", new[] { "IdProducto" });
            DropIndex("dbo.Pedidoes", new[] { "IdEmpleado" });
            DropIndex("dbo.Pedidoes", new[] { "IdMesa" });
            DropIndex("dbo.HExtras", new[] { "IdEmpleado" });
            DropIndex("dbo.Empleadoes", new[] { "IdGenero" });
            DropIndex("dbo.AsignacionTurnoes", new[] { "IdEmpleado" });
            DropIndex("dbo.AsignacionTurnoes", new[] { "IdTurno" });
            DropTable("dbo.Facturas");
            DropTable("dbo.Roles");
            DropTable("dbo.Usuarios");
            DropTable("dbo.Turnos");
            DropTable("dbo.TipoMenus");
            DropTable("dbo.DetallePedidoes");
            DropTable("dbo.Menus");
            DropTable("dbo.Recetas");
            DropTable("dbo.Proveedores");
            DropTable("dbo.DetalleCompras");
            DropTable("dbo.Categorias");
            DropTable("dbo.Productos");
            DropTable("dbo.Prestamos");
            DropTable("dbo.Mesas");
            DropTable("dbo.Pedidoes");
            DropTable("dbo.HExtras");
            DropTable("dbo.Generoes");
            DropTable("dbo.Empleadoes");
            DropTable("dbo.AsignacionTurnoes");
        }
    }
}
