using System;

namespace PruebaTecnica.WebApi.Core.Entities
{
    public class Transaccion
    {
        public string Id { get; set; }

        public decimal Monto { get; set; }

        public DateTime FechaTransaccion { get; set; }
    }
}
