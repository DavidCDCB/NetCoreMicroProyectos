using Dominio;

namespace DTO
{
    //Caso de uso GenerarInformeGerencial{
    public class FinanzaDTO
    {
        public string descripcion{get;set;}
        public double valor{get;set;}

        public FinanzaDTO(Finanza finanza){
            descripcion = finanza.tipo;
            valor = finanza.valor;
        }
    }
    //}Caso de uso GenerarInformeGerencial
}