using System;
using System.Collections.Generic;

namespace DTO
{
    public partial class TurnoDTO
    {
        public TurnoDTO(){}
		public string idMesero { get; set; }
		public string idTurno { get; set; }
		public string tipo { get; set; }
		public string fecha { get; set; }
		public string horaInicio { get; set; }
		public string horaFin { get; set; }
		public virtual List<string> mesas { get; set; }
    }
}