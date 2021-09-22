
using Dominio;
using DTO;

namespace  Mapeadores
{
    public class MapeadorGestionarTurnosDto
    {

        public MapeadorGestionarTurnosDto()
        {
            
        }
        public  MeseroDto datosMesero(Mesero mesero){
            return  new MeseroDto (mesero.nombre, mesero.apellido);
        }
    }
}