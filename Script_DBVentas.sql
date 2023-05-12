--CREATE DATABASE DBVentas

USE DBVentas
GO

CREATE TABLE Rol
(
	idRol INT PRIMARY KEY IDENTITY(1,1),
	rol VARCHAR(50),
	fechaRegistro DATETIME DEFAULT GETDATE(),
	usuarioRegistro INT,
	fechaModificacion DATETIME,
	usuarioModificacion INT
)

GO

CREATE TABLE Menu
(
	idMenu INT PRIMARY KEY IDENTITY(1,1),
	menu NVARCHAR(50),
	icono NVARCHAR(50),
	urlMenu NVARCHAR(50)
)

GO

CREATE TABLE MenuRol
(
	idMenuRol INT PRIMARY KEY IDENTITY(1,1),
	idMenu INT REFERENCES Menu(idMenu),
	idRol INT REFERENCES Rol(idRol)
)

GO

CREATE TABLE Usuario
(
	idUsuario INT PRIMARY KEY IDENTITY(1,1),
	nombreCompleto NVARCHAR(200),
	correo NVARCHAR(50),
	idRol INT REFERENCES Rol(idRol),
	clave NVARCHAR(40),
	esActivo BIT DEFAULT 1,
	fechaRegistro DATETIME DEFAULT GETDATE(),
	usuarioRegistro INT,
	fechaModificaicon DATETIME,
	usuarioModificaicon INT
)

GO

CREATE TABLE Categoria
(
	idCategoria INT PRIMARY KEY IDENTITY(1,1),
	categoria NVARCHAR(50),
	esActivo BIT DEFAULT 1,
	fechaRegistro DATETIME DEFAULT GETDATE(),
	usuarioRegistro INT,
	fechaModificacion DATETIME,
	usuarioModificacion INT
)

GO

CREATE TABLE Producto
(
	idProducto INT PRIMARY KEY IDENTITY(1,1),
	producto NVARCHAR(100),
	idcategoria INT REFERENCES Categoria(idCategoria),
	stock INT,
	precio MONEY,
	esActivo BIT DEFAULT 1,
	fechaRegistro DATETIME DEFAULT GETDATE(),
	usuarioRegistro INT,
	fechaModificacion DATETIME,
	usuarioModificacion INT
)

GO

CREATE TABLE Documento
(
	idDocumento INT PRIMARY KEY IDENTITY(1,1),
	ultimoNumero INT NOT NULL,
	fechaRegistro DATETIME DEFAULT GETDATE(),
	usuarioRegistro INT,
	fechaModificacion DATETIME,
	usuarioModificacion INT
)

GO

CREATE TABLE Venta
(
	idVenta INT PRIMARY KEY IDENTITY(1,1),
	numeroDocumento NVARCHAR(40),
	tipoPago NVARCHAR(50),
	total MONEY,
	fechaRegistro DATETIME DEFAULT GETDATE(),
	usuarioRegistro INT,
	fechaModificacion DATETIME,
	usuarioModificacion INT
)

GO

CREATE TABLE DetalleVenta
(
	idDetalleVenta INT PRIMARY KEY IDENTITY(1,1),
	idVenta INT REFERENCES Venta(idVenta),
	idProducto INT REFERENCES Producto(idProducto),
	cantidad INT,
	precio MONEY,
	total MONEY
)

GO

--Ingresar Roles
SELECT * FROM Rol
INSERT INTO Rol(rol,usuarioRegistro)
VALUES('Administrador',1)
INSERT INTO Rol(rol,usuarioRegistro)
VALUES('Empleado',1)
INSERT INTO Rol(rol,usuarioRegistro)
VALUES('Supervisor',1)

--Ingresar Usuario
SELECT * FROM Usuario
INSERT INTO Usuario(nombreCompleto,correo,idRol,clave,usuarioRegistro)
VALUES('Desarrollo','desarrollo@gmail.com',1,'12345',1)

--Ingresar Categoría
SELECT * FROM Categoria
INSERT INTO Categoria(categoria,usuarioRegistro)
VALUES('Laptops',1),
('Monitores',1),
('Teclados',1),
('Auriculares',1),
('Memorias',1),
('Accesorios',1)

--Insertar Producto
SELECT * FROM Producto
INSERT INTO Producto(producto,idCategoria,stock,precio,usuarioRegistro) VALUES
('Laptop Samsung book pro',1,20,2500,1),
('Laptop Lenovo Idea pad',1,30,2200,1),
('Laptop Asus Zenbook duo',1,30,2100,1),
('Monitor Teros gaming te-2',2,25,1050,1),
('Monitor Samsung curvo',2,15,1400,1),
('Monitor Huawei gamer',2,10,1350,1),
('Teclado Seisen gamer',3,10,800,1),
('Teclado Antryx gamer',3,10,1000,1),
('Teclado Logitech',3,10,1000,1),
('Auricular Logitech gamer',4,15,800,1),
('Auricular Hyperx gamer',4,20,680,1),
('Auricular Redragon rgb',4,25,950,1),
('Memoria Kingston rgb',5,10,200,1),
('Ventilador Cooler master',6,20,200,1),
('Mini Ventilador Lenovo',6,15,200,1)


--Insertar opciones Menú
SELECT * FROM Menu
INSERT INTO Menu(menu,icono,urlMenu) VALUES
('DashBoard','dashboard','/pages/dashboard'),
('Usuarios','group','/pages/usuarios'),
('Productos','collections_bookmark','/pages/productos'),
('Venta','currency_exchange','/pages/venta'),
('Historial Ventas','edit_note','/pages/historial_venta'),
('Reportes','receipt','/pages/reportes')

go

--menus para administrador
SELECT * FROM MenuRol
INSERT INTO MenuRol(idMenu,idRol) VALUES
(1,1),
(2,1),
(3,1),
(4,1),
(5,1),
(6,1)

go

--menus para empleado
INSERT INTO MenuRol(idMenu,idRol) VALUES
(4,2),
(5,2)

go

--menus para supervisor
INSERT INTO MenuRol(idMenu,idRol) VALUES
(3,3),
(4,3),
(5,3),
(6,3)

go

SELECT * FROM Documento
INSERT INTO Documento(ultimoNumero,usuarioRegistro) VALUES
(0,1)
