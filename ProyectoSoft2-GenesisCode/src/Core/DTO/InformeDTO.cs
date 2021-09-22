using System.Collections.Generic;

namespace DTO
{
    //Caso de uso GenerarInformeGerencial{
    public class InformeDTO
    {
        public List<FinanzaDTO> ingresos{get;set;}
        public List<FinanzaDTO> egresos{get;set;}
        public int clientesAtendidos{get;set;}
        public int domicilios{get;set;}
        public List<EstadisticasPorPlatoDTO> estadisticas{get;set;}
    
        public InformeDTO(List<FinanzaDTO> ingresos, List<FinanzaDTO> egresos, int clientesAtendidos, int domicilios, List<EstadisticasPorPlatoDTO> estadisticas){
            this.ingresos = ingresos;
            this.egresos = egresos;
            this.clientesAtendidos = clientesAtendidos;
            this.domicilios = domicilios;
            this.estadisticas = estadisticas;
        }
    }
    //}Caso de uso GenerarInformeGerencial
}