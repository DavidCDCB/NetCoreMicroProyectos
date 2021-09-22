using System.Collections.Generic;
using DTO;
using Dominio;

namespace Mapeadores
{
    //Caso de uso GenerarInformeGerencial{
    public class Mapeador
    {
        public static FinanzaDTO datosFinanza(Finanza finanza)
        {
            return new FinanzaDTO(finanza);
        }

        public static EstadisticasPorPlatoDTO datosEstadistica(string categoria, decimal porcentaje)
        {
            return new EstadisticasPorPlatoDTO(categoria, porcentaje);
        }

        public static InformeDTO datosInforme(List<FinanzaDTO> ingresos, List<FinanzaDTO> egresos, int clientesAtendidos, int domicilios, List<EstadisticasPorPlatoDTO> estadisticas)
        {
            return new InformeDTO(ingresos, egresos, clientesAtendidos, domicilios, estadisticas);
        }
    }
    //}Caso de uso GenerarInformeGerencial
}
