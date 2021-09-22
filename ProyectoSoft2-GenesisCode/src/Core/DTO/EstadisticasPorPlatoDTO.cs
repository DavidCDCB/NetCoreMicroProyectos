namespace DTO
{
    //Caso de uso GenerarInformeGerencial{
    public class EstadisticasPorPlatoDTO
    {
        public string categoria{get;set;}
        public decimal porcentaje{get;set;}

        public EstadisticasPorPlatoDTO(string categoria, decimal porcentaje){
            this.categoria = categoria;
            this.porcentaje = porcentaje;
        }
    }
   //}Caso de uso GenerarInformeGerencial
}