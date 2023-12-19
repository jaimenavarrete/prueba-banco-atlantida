-- PRUEBA TÉCNICA DE BANCO ATLÁNTIDA
----------------------------------------------------

-- CREACIÓN DE BASE DE DATOS

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
	DECLARE @CuentaId CHAR(36) = (SELECT CuentaId FROM inserted)
	DECLARE @Monto DECIMAL(10,4) = (SELECT Monto FROM inserted)

	UPDATE Cuentas SET SaldoTotal = SaldoTotal + @Monto
	WHERE Id = @CuentaId
GO

-- Trigger para reducir saldo total de cuenta al agregar pago
CREATE TRIGGER ReducirSaldoTotalTrigger
ON Pagos
FOR INSERT
AS
	DECLARE @CuentaId CHAR(36) = (SELECT CuentaId FROM inserted)
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

-- CREACIÓN DE PROCEDIMIENTOS ALMACENADOS

-- Obtener estado cuenta
CREATE PROCEDURE spObtenerEstadoCuenta
AS
BEGIN
	DECLARE @PorcentajeInteres DECIMAL(5, 2) = (SELECT PorcentajeInteres FROM Configuraciones);
	DECLARE @PorcentajeSaldoMinimo DECIMAL(5, 2) = (SELECT PorcentajeSaldoMinimo FROM Configuraciones);

	DECLARE @FechaMesActual DATETIME = GETDATE()
	DECLARE @FechaMesAnterior DATETIME = DATEADD(MONTH, -1, @FechaMesActual)

	SELECT TOP(1)
		Id,
		NombreTitular,
		NumeroTarjeta,
		SaldoTotal,
		LimiteCredito,
		SaldoDisponible = LimiteCredito - SaldoTotal,
		MontoComprasMesAnterior = 
			ISNULL((SELECT SUM(Monto) FROM Compras WHERE YEAR(FechaCompra) = YEAR(@FechaMesAnterior) AND MONTH(FechaCompra) = MONTH(@FechaMesAnterior)), 0),
		MontoComprasMesActual = 
			ISNULL((SELECT SUM(Monto) FROM Compras WHERE YEAR(FechaCompra) = YEAR(@FechaMesActual) AND MONTH(FechaCompra) = MONTH(@FechaMesActual)), 0),
		InteresBonificable = SaldoTotal * @PorcentajeInteres,
		CuotaMinima = SaldoTotal * @PorcentajeSaldoMinimo,
		SaldoTotalConInteres = SaldoTotal * (1 + @PorcentajeInteres)
	FROM Cuentas
END
GO

-- Obtener cuenta
CREATE PROCEDURE spObtenerCuenta
AS
BEGIN
	SELECT TOP(1)
		Id,
		NombreTitular,
		NumeroTarjeta
	FROM Cuentas
END
GO

-- Obtener listado de compras
CREATE PROCEDURE spObtenerCompras
	@FechaActual DATETIME 
AS
BEGIN
	IF(@FechaActual IS NULL)
		BEGIN
			SELECT
				Id,
				Descripcion,
				Monto,
				FechaCompra
			FROM Compras
		END
	ELSE
		BEGIN
			SELECT
				Id,
				Descripcion,
				Monto,
				FechaCompra
			FROM Compras
			WHERE YEAR(FechaCompra) = YEAR(@FechaActual) AND MONTH(FechaCompra) = MONTH(@FechaActual)
		END
END
GO