CREATE DATABASE PlatyPlusDB;
GO

USE PlatyPlusDB;
GO


CREATE TABLE Roles (
    IdRol INTEGER PRIMARY KEY IDENTITY(1,1),
    NombreRol VARCHAR(255) NOT NULL
);
GO

CREATE TABLE Usuarios (
    IdUsuario INTEGER PRIMARY KEY IDENTITY(1,1),
    Nombre VARCHAR(255) NOT NULL,
    Usuario VARCHAR(255) UNIQUE NOT NULL,
    Contrasena VARCHAR(255) NOT NULL,
    IdRol INTEGER,
    FOREIGN KEY (IdRol) REFERENCES Roles(IdRol)
);


CREATE TABLE Categorias (
    IdCategoria INTEGER PRIMARY KEY IDENTITY(1,1),
    Nombre VARCHAR(255) NOT NULL
);
GO

CREATE TABLE Subcategorias (
    IdSubcategoria INTEGER PRIMARY KEY IDENTITY(1,1),
    Nombre VARCHAR(255) NOT NULL,
    IdCategoria INTEGER,
    FOREIGN KEY (IdCategoria) REFERENCES Categorias(IdCategoria)
);
GO

CREATE TABLE Platos (
    IdPlato INTEGER PRIMARY KEY IDENTITY(1,1),
    Nombre VARCHAR(255) NOT NULL,
    Precio REAL NOT NULL,
    Descripcion VARCHAR(255),
    Imagen VARCHAR(255),
    Disponible BIT NOT NULL DEFAULT 1,
    IdSubcategoria INTEGER,
    FOREIGN KEY (IdSubcategoria) REFERENCES Subcategorias(IdSubcategoria)
);
GO

CREATE TABLE Insumos (
    IdInsumo INTEGER PRIMARY KEY IDENTITY(1,1),
    Nombre VARCHAR(255) NOT NULL,
    Cantidad DECIMAL NOT NULL,
    Unidad VARCHAR(255) NOT NULL
);
GO

CREATE TABLE Recetas (
    IdReceta INTEGER PRIMARY KEY IDENTITY(1,1),
    IdPlato INTEGER,
    IdInsumo INTEGER,
    CantidadNecesaria DECIMAL NOT NULL,
    FOREIGN KEY (IdPlato) REFERENCES Platos(IdPlato),
    FOREIGN KEY (IdInsumo) REFERENCES Insumos(IdInsumo)
);
GO

CREATE TABLE Mesas (
    IdMesa INTEGER PRIMARY KEY IDENTITY(1,1),
    NumeroMesa VARCHAR(255) NOT NULL,
    Estado VARCHAR(255) NOT NULL
);
GO

CREATE TABLE Pedidos (
    IdPedido INTEGER PRIMARY KEY IDENTITY(1,1),
    Fecha DATETIME DEFAULT GETDATE(),
    IdMesa INTEGER,
    Estado VARCHAR(255) NOT NULL,
    FOREIGN KEY (IdMesa) REFERENCES Mesas(IdMesa)
);
GO

CREATE TABLE DetallePedido (
    IdDetalle INTEGER PRIMARY KEY IDENTITY(1,1),
    IdPedido INTEGER,
    IdPlato INTEGER,
    Cantidad INTEGER,
    PrecioUnitario REAL,
    Subtotal REAL,
    Comentarios VARCHAR(255),
    FOREIGN KEY (IdPedido) REFERENCES Pedidos(IdPedido),
    FOREIGN KEY (IdPlato) REFERENCES Platos(IdPlato)
);
GO

CREATE TABLE Facturas (
    IdFactura INTEGER PRIMARY KEY IDENTITY(1,1),
    IdPedido INTEGER,
    Total REAL NOT NULL,
    FechaEmision DATETIME DEFAULT GETDATE(),
    NumeroControl VARCHAR(255),
    Serie VARCHAR(255),
    XML VARCHAR(255),
    EstadoEnvio VARCHAR(255), IdMetodoPago INTEGER, IdTurno INTEGER, Pagado BIT DEFAULT 0,
    FOREIGN KEY (IdPedido) REFERENCES Pedidos(IdPedido)
);
GO

CREATE TABLE MetodosPago (
    IdMetodoPago INTEGER PRIMARY KEY IDENTITY(1,1),
    Nombre VARCHAR(255) NOT NULL
);
GO

CREATE TABLE Turnos (
    IdTurno INTEGER PRIMARY KEY IDENTITY(1,1),
    IdUsuario INTEGER,
    FechaInicio DATETIME DEFAULT GETDATE(),
    FechaCierre DATETIME,
    MontoInicial REAL,
    MontoFinal REAL,
    FOREIGN KEY (IdUsuario) REFERENCES Usuarios(IdUsuario)
);
GO

-- Modificaciones para salidas justificadas no facturadas

-- Agregar columna TipoConsumo al Pedido
ALTER TABLE Pedidos ADD TipoConsumo VARCHAR(255) DEFAULT 'Cliente'; -- Ej: 'Empleado', 'Desperdicio', 'Cortesia', etc.

-- Agregar columna Justificacion
ALTER TABLE Pedidos ADD Justificacion VARCHAR(255);
GO

ALTER TABLE Facturas
ADD CONSTRAINT FK_Facturas_MetodoPago
FOREIGN KEY (IdMetodoPago) REFERENCES MetodosPago(IdMetodoPago);
GO

ALTER TABLE Facturas
ADD CONSTRAINT FK_Facturas_Turno
FOREIGN KEY (IdTurno) REFERENCES Turnos(IdTurno);
GO
