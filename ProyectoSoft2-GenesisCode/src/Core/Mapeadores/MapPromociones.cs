using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;

using Persistencia;
using Dominio;
using DTO;

namespace  Mapeadores
{
    public class MapPromocionDTO
    {
        public MapPromocionDTO()
        {
        }
        public  PromocionDto datosPromocion(Promocion promocion){
            return  new PromocionDto ();
        }

        public  PlatoDto datosPlato(Plato plato){
            return  new PlatoDto (plato.nombre, plato.valor);
        }

    }
}
