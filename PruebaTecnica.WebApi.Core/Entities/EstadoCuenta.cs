namespace PruebaTecnica.WebApi.Core.Entities
{
    public class EstadoCuenta : Cuenta
    {
        public decimal SaldoTotal { get; set; }

        public decimal LimiteCredito { get; set; }

        public decimal SaldoDisponible { get; set; }

        public decimal MontoComprasMesAnterior { get; set; }

        public decimal MontoComprasMesActual { get; set; }

        public decimal InteresBonificable { get; set; }

        public decimal CuotaMinima { get; set; }

        public decimal SaldoTotalConInteres { get; set; }
    }
}
