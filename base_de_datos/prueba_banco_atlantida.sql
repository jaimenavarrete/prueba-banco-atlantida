-- Prueba Técnica de Banco Atlántida

CREATE DATABASE BancoAtlantida
GO
USE BancoAtlantida
GO

-- CREACIÓN DE TABLAS

-- Tabla de configuraciones
CREATE TABLE Configuraciones (
	Id INT IDENTITY(1,1) PRIMARY KEY,
	PorcentajeInteres DECIMAL(5,2) NOT NULL,
	PorcentajeSaldoMinimo DECIMAL(5,2) NOT NULL
)
GO

-- Tabla de cuentas
CREATE TABLE Cuentas (
	Id INT IDENTITY(1,1) PRIMARY KEY,
	NombreTitular NVARCHAR(128) NOT NULL,
	NumeroTarjeta CHAR(68) NOT NULL,
	SaldoTotal DECIMAL(10,4) NOT NULL,
	LimiteCredito DECIMAL(10,4) NOT NULL
)
GO

-- Tabla de compras
CREATE TABLE Compras (
	Id CHAR(36) PRIMARY KEY,
	Descripcion TEXT,
	Monto DECIMAL(10,4) NOT NULL,
	FechaCompra DATETIME NOT NULL,
	CuentaId INT NOT NULL,

	FOREIGN KEY (CuentaId) REFERENCES Cuentas (Id)
)
GO

-- Tabla de pagos
CREATE TABLE Pagos (
	Id CHAR(36) PRIMARY KEY,
	Monto DECIMAL(10,4) NOT NULL,
	FechaPago DATETIME NOT NULL,
	CuentaId INT NOT NULL,

	FOREIGN KEY (CuentaId) REFERENCES Cuentas (Id)
)
GO