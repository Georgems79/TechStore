LE ADJUNTO SCRIPT DE LA CREACIO DE LA BASE DE DATOS Y LA TABLA QUE SOLICITO
CREATE DATABASE TechStore
GO

USE DATABASE TechStore
GO

CREATE TABLE Producto (
    IdProducto INT IDENTITY(1,1) PRIMARY KEY,       
    Nombre NVARCHAR(100) NOT NULL,          
    Descripcion NVARCHAR(MAX),              
    Precio DECIMAL(10, 5) NOT NULL,        
    Cantidad INT NOT NULL,                 
    Fecha_Creacion DATETIME DEFAULT GETDATE() 
);
CREATE TABLE Categorias (
    IdCategoria INT IDENTITY(1,1) PRIMARY KEY,       
    Nombre NVARCHAR(100) NOT NULL,          
    Descripcion NVARCHAR(MAX)               
);

CREATE TABLE ProductoxCategoria (
    IdProducto INT NOT NULL,                   
    IdCategoria INT NOT NULL,                  
    PRIMARY KEY (IdProducto, IdCategoria),    
    FOREIGN KEY (IdProducto) REFERENCES Producto ON DELETE CASCADE,  
    FOREIGN KEY (IdCategoria) REFERENCES Categorias ON DELETE CASCADE  -
);


CREATE TABLE Usuarios
( 
	IdUsuario int identity (1,1)primary key,
	Nombre Nvarchar (250),
	FechaCreacion date,
	Clave Nvarchar (50)

)
