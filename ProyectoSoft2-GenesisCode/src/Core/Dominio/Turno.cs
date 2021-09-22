using System;

namespace Dominio
{
    public class Turno
    {
        public string idTurno { get; set; }
		public string tipo { get; set; }
		public string fecha { get; set; }
		public string horaInicio { get; set; }
		public string horaFin { get; set; }
		public string fkIdMesero { get; set; }
    }
}
