using System;
using System.Collections.Generic;

namespace Dominio
{
    //Caso de uso GenerarInformeGerencial{
    public class Venta
    {
        public DateTime fecha{get;set;}
        public string tipo{get;set;}
        public string cliente{get;set;}
        public virtual List<string> platos{ get; set;}
    }
    //}Caso de uso GenerarInformeGerencial
}