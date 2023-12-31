﻿using PruebaTecnica.WebApi.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PruebaTecnica.WebApi.Core.Interfaces.Repositories
{
    public interface ITransaccionesRepository
    {
        Task<List<Transaccion>> ObtenerTransaccionesPorMes(int anio, int mes);
    }
}
