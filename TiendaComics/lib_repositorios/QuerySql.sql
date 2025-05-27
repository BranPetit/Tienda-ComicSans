CREATE DATABASE db_comics;
GO
USE db_comics;
GO

CREATE TABLE [Categorias](
	[Id] INT PRIMARY KEY IDENTITY (1,1) NOT  NULL,
	[Nombre] NVARCHAR (50) NOT NULL,
	[Edad_Recomendada] NVARCHAR (20) NOT NULL
);
GO

CREATE TABLE [Editoriales](
	[Id] INT PRIMARY KEY IDENTITY (1,1) NOT  NULL,
	[Nombre] NVARCHAR (50) NOT NULL,
	[Distribuidor_Asociado] NVARCHAR (50) NOT NULL
);
GO

CREATE TABLE [Comics](
	[Id] INT PRIMARY KEY IDENTITY (1,1) NOT  NULL,
	[Nombre] NVARCHAR (50) NOT NULL,
	[Precio] DECIMAL (10,2) NOT NULL,
	[Editorial] INT NOT NULL,
	[Categoria] INT NOT NULL,
	FOREIGN KEY ([Editorial]) REFERENCES [Editoriales]([Id]),
	FOREIGN KEY ([Categoria]) REFERENCES [Categorias]([Id])

);
GO

CREATE TABLE [Roles] (
	[Id] INT NOT NULL IDENTITY (1,1) PRIMARY KEY,
	[Nombre] NVARCHAR (50),
	[Descripcion] NVARCHAR (70)
);
GO

CREATE TABLE [Usuarios] (
	[Id] INT NOT NULL IDENTITY (1,1) PRIMARY KEY,
	[Email] NVARCHAR (50) UNIQUE NOT NULL,
	[Contraseña] NVARCHAR (100),
	[Rol] INT NOT NULL,
	FOREIGN KEY ([Rol]) REFERENCES [Roles]([Id]) 
		
);
GO

CREATE TABLE [Vendedores](
	[Id] INT PRIMARY KEY IDENTITY (1,1) NOT  NULL,
	[Carnet] NVARCHAR (50) UNIQUE NOT NULL,
	[Nombre] NVARCHAR (50) NOT NULL,
	[Usuario] INT NOT NULL,
	FOREIGN KEY ([Usuario]) REFERENCES [Usuarios]([Id])
);
GO

CREATE TABLE [Clientes](
	[Id] INT PRIMARY KEY IDENTITY (1,1) NOT  NULL,
	[Cedula] NVARCHAR (50) UNIQUE NOT NULL,
	[Nombre] NVARCHAR (50) NOT NULL,
	[Usuario] INT NOT NULL,
	FOREIGN KEY ([Usuario]) REFERENCES [Usuarios]([Id])
);
GO

CREATE TABLE [Sucursales](
	[Id] INT PRIMARY KEY IDENTITY (1,1) NOT  NULL,
	[Nombre] NVARCHAR (50) NOT NULL,
	[Direccion] NVARCHAR (150) NOT NULL
);
GO

CREATE TABLE [Metodos_de_Pagos](
	[Id] INT PRIMARY KEY IDENTITY (1,1) NOT  NULL,
	[Nombre] NVARCHAR (50) NOT NULL,
	[Tipo] NVARCHAR (50) NOT NULL
);
GO

CREATE TABLE [Ventas](
	[Id] INT PRIMARY KEY IDENTITY (1,1) NOT  NULL,
	[Sucursal] INT NOT NULL,
	[Cliente] INT NOT NULL,
	[Vendedor] INT NOT NULL,
	[Fecha] SMALLDATETIME NOT NULL,
	[Codigo] NVARCHAR (150) NOT NULL,
	[Metodo_de_Pago] INT NOT NULL,
	FOREIGN KEY ([Sucursal]) REFERENCES [Sucursales]([Id]),
	FOREIGN KEY ([Cliente]) REFERENCES [Clientes]([Id]),
	FOREIGN KEY ([Vendedor]) REFERENCES [Vendedores]([Id]),
	FOREIGN KEY ([Metodo_de_Pago]) REFERENCES [Metodos_de_Pagos]([Id])

);
GO

CREATE TABLE [Detalles_Ventas](
	[Id] INT PRIMARY KEY IDENTITY (1,1) NOT  NULL,
	[CodigoDetalle] NVARCHAR (50),
	[Comic] INT NOT NULL,
	[Venta] INT NOT NULL,
	FOREIGN KEY ([Comic]) REFERENCES [Comics]([Id]),
	FOREIGN KEY ([Venta]) REFERENCES [Ventas]([Id]),
	[Cantidad] INT NOT NULL,

);
GO

CREATE TABLE [Auditorias] (
	[Id] INT NOT NULL IDENTITY (1,1) PRIMARY KEY,
	[Usuario] NVARCHAR (50),
	[Entidad] NVARCHAR (50),
	[Operacion] NVARCHAR (50),
	[Datos] NVARCHAR (250),
	[Fecha] DATETIME 
);
GO



INSERT INTO [Categorias]([Nombre],[Edad_Recomendada])
VALUES 
	('Super Heroes','7+'),
	('Terror','15+'),
	('Accion','7+'),
	('One Shot','18+'),
	('Comedia','5+');
GO

	
INSERT INTO [Editoriales]([Nombre],[Distribuidor_Asociado])
VALUES 
	('Marvel','Dark Horse'),
	('Fear','Panini'),
	('DC','Lunar Distribution'),
	('Shonen','Shonen Jump'),
	('LE PER','Sortir'),
	('Lumen','Lerner');
GO


INSERT INTO [Comics]([Nombre],[Precio],[Editorial],[Categoria])
VALUES 
	('SPIDERMAN',25000,1,1),
	('CANARY',18000,2,2),
	('BATMAN',27500,3,1),
	('VAGABOND',33000,4,3),
	('CHAINSAWMAN',30000,4,3),
	('LINEA DE PUNTOS',15000,5,4),
	('MAFALDA',8000,6,5);
GO

INSERT INTO [Roles] ([Nombre],[Descripcion])
VALUES 
	('Cliente','Comprador'),
	('Vendedor','Empleado'),
	('Administrador','Dueño');
GO

INSERT INTO [Usuarios]([Email],[Contraseña],[Rol])
VALUES 
	('Andres@gmail.com','1234',1),
	('Paulina@gmail.com','134',1),
	('Santiago@gmail.com','234',1),
	('Alex@gmail.com','123',1),
	('Pepe@gmail.com','1111',1),
	('Karen@gmail.com','2222',1),
	('samuel@gmail.com','111',1),
	('Pablo@gmail.com','333',2),
	('Dayana@gmail.com','444',2),
	('Carlos@gmail.com','567',2),
	('Albert@gmail.com','789',2),
	('Sara@gmail.com','4323',2),
	('Maria@gmail.com','786',2),
	('AdminPro','Fiunba',3);
GO

INSERT INTO [Vendedores]([Carnet],[Nombre],[Usuario])
VALUES 
	('321','Pablo',8),
	('456','Dayana',9),
	('364','Carlos',10),
	('469','Albert',11),
	('444','Sara',12),
	('555','Maria',13);
GO


INSERT INTO [Clientes]([Cedula],[Nombre],[Usuario])
VALUES 
	('123','Andres',1),
	('456','Paulina',2),
	('879','Santiago',3),
	('444','Alex',4),
	('564','Pepe',5),
	('888','Karen',6),
	('255','Samuel',7);
GO

	
INSERT INTO [Sucursales]([Nombre],[Direccion])
VALUES 
	('BELLO','CRA 23 #23-23'),
	('ENVIGADO','CRA 56 #56-57'),
	('ITAGUI','CRA 88 #11-23'),
	('MEDELLIN','CRA 14 #66-74');
GO


INSERT INTO [Metodos_de_Pagos]([Nombre],[Tipo])
VALUES 
	('EFECTIVO','Presencial'),
	('TARJETA','En linea'),
	('PAYPAL','En linea');
GO


INSERT INTO [Ventas]([Sucursal],[Cliente],[Vendedor],[Fecha],[Codigo],[Metodo_de_Pago])
VALUES 
	(1,1,1,'2025-05-10','V-20250510-001',1),
	(1,2,1,'2025-05-12','V-20250512-002',2),
	(2,3,2,'2025-06-12','V-20250612-003',1),
	(3,4,3,'2025-06-13','V-20250613-004',2),
	(3,5,4,'2025-06-13','V-20250613-005',3),
	(4,6,5,'2025-07-02','V-20250702-006',1),
	(1,7,6,'2025-07-02','V-20250702-007',3);
GO


INSERT INTO [Detalles_Ventas]([CodigoDetalle],[Comic],[Venta],[Cantidad])
VALUES 
	('123',1,1,1),
	('54345',2,2,1),
	('3213123',3,3,1),
	('213',4,3,1),
	('3123',5,4,1),
	('312',6,5,1),
	('2311',1,6,1),
	('445',7,7,1);
GO

SELECT * FROM [Categorias];
SELECT * FROM [Editoriales];
SELECT * FROM [Comics];
SELECT * FROM [Vendedores];
SELECT * FROM [Clientes];
SELECT * FROM [Sucursales];
SELECT * FROM [Metodos_de_Pagos];
SELECT * FROM [Detalles_Ventas];
SELECT * FROM [Ventas]
SELECT * FROM [Auditorias]
SELECT * FROM [Roles]
SELECT * FROM [Usuarios]

drop database db_comics

