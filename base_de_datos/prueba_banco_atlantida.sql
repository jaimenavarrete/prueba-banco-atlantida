-- Prueba Técnica de Banco Atlántida

CREATE DATABASE BancoAtlantida
GO
USE BancoAtlantida
GO

-- CREACIÓN DE TABLAS

-- Tabla de configuraciones
CREATE TABLE Configuraciones (
	Id CHAR(36) PRIMARY KEY,
	PorcentajeInteres DECIMAL(5,2) NOT NULL,
	PorcentajeSaldoMinimo DECIMAL(5,2) NOT NULL
)
GO

-- Tabla de cuentas
CREATE TABLE Cuentas (
	Id CHAR(36) PRIMARY KEY,
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
	CuentaId CHAR(36) NOT NULL,

	FOREIGN KEY (CuentaId) REFERENCES Cuentas (Id)
)
GO

-- Tabla de pagos
CREATE TABLE Pagos (
	Id CHAR(36) PRIMARY KEY,
	Monto DECIMAL(10,4) NOT NULL,
	FechaPago DATETIME NOT NULL,
	CuentaId CHAR(36) NOT NULL,

	FOREIGN KEY (CuentaId) REFERENCES Cuentas (Id)
)
GO

-- CREACIÓN DE TRIGGERS

-- Trigger para incrementar saldo total de cuenta al agregar compra
CREATE TRIGGER IncrementarSaldoTotalTrigger
ON Compras
FOR INSERT
AS
	DECLARE @CuentaId INT = (SELECT CuentaId FROM inserted)
	DECLARE @Monto DECIMAL(10,4) = (SELECT Monto FROM inserted)

	UPDATE Cuentas SET SaldoTotal = SaldoTotal + @Monto
	WHERE Id = @CuentaId
GO

-- Trigger para reducir saldo total de cuenta al agregar pago
CREATE TRIGGER ReducirSaldoTotalTrigger
ON Pagos
FOR INSERT
AS
	DECLARE @CuentaId INT = (SELECT CuentaId FROM inserted)
	DECLARE @Monto DECIMAL(10,4) = (SELECT Monto FROM inserted)

	UPDATE Cuentas SET SaldoTotal = SaldoTotal - @Monto
	WHERE Id = @CuentaId
GO

-- INSERTAR DATOS INICIALES

-- Tabla de cuentas
INSERT INTO Cuentas (Id, NombreTitular, NumeroTarjeta, SaldoTotal, LimiteCredito)
VALUES (
	'454a540a-f481-430c-a7ce-6a1516732ff4', 
	'Jaime Eduardo Navarrete Cubías',
	'r9WS1uT6X+/q4uEQBC7Mng==9XMMzokva8CzA3dIb52ICFCmWLX7Aj6LQgB5v7+rmS8=',
	0,
	1000);
GO

-- Tabla de configuraciones
INSERT INTO Configuraciones (Id, PorcentajeInteres, PorcentajeSaldoMinimo)
VALUES (
	'be1508e8-b34c-4dbb-90de-b540b1e708c4',
	0.05,
	0.20
);
GO