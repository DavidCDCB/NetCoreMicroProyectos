using System;
using System.Collections.Generic;
using System.Linq;
using JsonFlatFileDataStore;

using Persistencia;
using Interfaces;
using Dominio;
using DTO;
using Excepciones;
using Mapeadores;

namespace Aplicacion
{
    public class GenerarInformeGerencialController
    {
        public IEntidadRepository<IDocumentCollection<Plato>, IEnumerable<Plato>> repoPlato;
        public IEntidadRepository<IDocumentCollection<Venta>, IEnumerable<Venta>> repoVenta;
        public IEntidadRepository<IDocumentCollection<Cliente>, IEnumerable<Cliente>> repoCliente;
        public IEntidadRepository<IDocumentCollection<Finanza>, IEnumerable<Finanza>> repoFinanza;

        public void setRepoVenta(Object repoVenta)
        {
            this.repoVenta = (VentaRepositorio)repoVenta;
        }

        public void setRepoPlato(Object repoPlato)
        {
            this.repoPlato = (PlatoRepositorio)repoPlato;
        }

        public void setRepoCliente(Object repoCliente)
        {
            this.repoCliente = (ClienteRepositorio)repoCliente;
        }

        public void setRepoFinanza(Object repoFinanza)
        {
            this.repoFinanza = (FinanzaRepositorio)repoFinanza;
        }

        public IEnumerable<FinanzaDTO> GetIngresosPorRangoFecha(DateTime fechaInicial, DateTime fechaFinal)
        {
            var results = repoFinanza.getQueryEntidad();

            List<Finanza> ingresos = results.Where(
                x => x.tipo == "Ingreso" && x.fecha >= fechaInicial && x.fecha <= fechaFinal
            ).ToList();

            List<FinanzaDTO> ingresosDTO = ingresos.Select(
                x => Mapeador.datosFinanza(x)
            ).ToList();

            return ingresosDTO;
        }

        public IEnumerable<FinanzaDTO> GetEgresosPorRangoFecha(DateTime fechaInicial, DateTime fechaFinal)
        {
            var results = repoFinanza.getQueryEntidad();

            List<Finanza> egresos = results.Where(
                x => x.tipo == "Egreso" && x.fecha >= fechaInicial && x.fecha <= fechaFinal
            ).ToList();

            List<FinanzaDTO> egresosDTO = egresos.Select(
                x => Mapeador.datosFinanza(x)
            ).ToList();

            return egresosDTO;
        }

        public int GetNumeroDeClientesAtendidosPorRangoFecha(DateTime fechaInicial, DateTime fechaFinal)
        {
            var results = repoVenta.getQueryEntidad();

            List<Venta> ventasPorFecha = results.Where(
                x => x.fecha >= fechaInicial && x.fecha <= fechaFinal
            ).ToList();

            var consulta = from venta in ventasPorFecha
                           group venta by venta.cliente into clientes
                           select clientes;
            return consulta.Count();
        }
        public int GetNumeroDeDomiciliosPorRangoFecha(DateTime fechaInicial, DateTime fechaFinal)
        {
            var results = repoVenta.getQueryEntidad();

            int numClientes = results.Where(
                x => x.fecha >= fechaInicial && x.fecha <= fechaFinal && x.tipo == "Domicilio"
            ).ToList().Count();

            return numClientes;
        }
        public int GetNumeroDePlatosPorRangoFecha(DateTime fechaInicial, DateTime fechaFinal)
        {
            var results = repoVenta.getQueryEntidad();
            int numPlatos = 0;

            List<Venta> ventas = results.Where(
                x => x.fecha >= fechaInicial && x.fecha <= fechaFinal
            ).ToList();

            ventas.ForEach(
            x =>
            {
                numPlatos += x.platos.Count();
            }
            );

            return numPlatos;
        }

        public IEnumerable<string> GetCategoriasPorFecha(DateTime fechaInicial, DateTime fechaFinal)
        {
            var results = repoVenta.getQueryEntidad();
            List<string> categorias = new List<string>();
            List<Venta> ventas = results.Where(
                x => x.fecha >= fechaInicial && x.fecha <= fechaFinal
            ).ToList();

            foreach (Venta venta in ventas)
            {
                foreach (string plato in venta.platos)
                {
                    if (buscarPlato(plato) != null)
                    {
                        categorias.Add(buscarPlato(plato).clasificacion);
                    }
                }
            }

            categorias = categorias.Distinct().ToList();

            return categorias;
        }

        public Plato buscarPlato(string idPlato)
        {
            try
            {
                var collection = repoPlato.getQueryEntidad();
                var results = collection.First(x => x.idplato == idPlato);
                return results;
            }
            catch (PlatoException)
            {
                throw new PlatoException("no existe");
            }
        }

        public IEnumerable<EstadisticasPorPlatoDTO> GetEstadisticasPorRangoFecha(DateTime fechaInicial, DateTime fechaFinal)
        {
            var results = repoVenta.getQueryEntidad();
            IEnumerable<string> categorias = GetCategoriasPorFecha(fechaInicial, fechaFinal);
            List<EstadisticasPorPlatoDTO> estadisticas = new List<EstadisticasPorPlatoDTO>();
            List<Venta> ventas = results.Where(
                x => x.fecha >= fechaInicial && x.fecha <= fechaFinal
            ).ToList();
            int total = GetNumeroDePlatosPorRangoFecha(fechaInicial, fechaFinal);
            int value = 0;

            foreach (string auxCategoria in categorias)
            {
                value = 0;
                foreach (Venta venta in ventas)
                {
                    foreach (string plato in venta.platos)
                    {
                        if (buscarPlato(plato) != null && auxCategoria == buscarPlato(plato).clasificacion)
                        {
                            value += 1;
                        }
                    }
                }
                estadisticas.Add(Mapeador.datosEstadistica(
                    auxCategoria, Math.Round(
                        Convert.ToDecimal(value) / Convert.ToDecimal(total), 2))
                    );
            }
            return estadisticas;
        }

        public InformeDTO GetInformeGerencialRangoFecha(DateTime fechaInicial, DateTime fechaFinal)
        {
            if (fechaInicial < fechaFinal)
            {
                return Mapeador.datosInforme(
                    GetIngresosPorRangoFecha(fechaInicial, fechaFinal).ToList(),
                    GetEgresosPorRangoFecha(fechaInicial, fechaFinal).ToList(),
                    GetNumeroDeClientesAtendidosPorRangoFecha(fechaInicial, fechaFinal),
                    GetNumeroDeDomiciliosPorRangoFecha(fechaInicial, fechaFinal),
                    GetEstadisticasPorRangoFecha(fechaInicial, fechaFinal).ToList()); ;
            }
            else
            {
                throw new DateException("La fecha inicial debe ser menor que la fecha final");
            }
        }
    }
}