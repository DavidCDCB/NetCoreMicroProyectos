using System.Collections.Generic;
namespace Dominio
{
    public class Mesa
    {
        public string idMesa { get; set; }
		public bool estado { get; set; }
		public int capacidad { get; set; }
		public string ubicacion { get; set; }
		public List<string> fkIdTurno { get; set; }
    }
}