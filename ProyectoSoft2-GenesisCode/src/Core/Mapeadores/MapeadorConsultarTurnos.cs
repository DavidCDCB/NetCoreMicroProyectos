using DTO;
using Dominio;
using System.Collections.Generic;

namespace Mapeadores
{
    public class MapeadorConsultarTurnos
    {

        public MapeadorConsultarTurnos()
		{
		}

		public static DatosBasicosMeseroDTO CrearRespuestaDatos(Mesero mesero)
		{
			DatosBasicosMeseroDTO respuesta = new DatosBasicosMeseroDTO()
			{
				nombre = mesero.nombre,
				apellido = mesero.apellido,
				identificacion = mesero.documento,
				estado = mesero.estado
			};
			return respuesta;
		}

		public static TurnoDTO CrearConsultaTurnos(Turno turno,List<string> idMesas)
		{
			TurnoDTO respuesta = new TurnoDTO()
			{
				idMesero = turno.fkIdMesero,
				idTurno = turno.idTurno,
				tipo = turno.tipo,
				fecha = turno.fecha,
				horaInicio = turno.horaInicio.ToString(),
				horaFin = turno.horaFin.ToString(),
				mesas = idMesas
			};
			return respuesta;
		}
    }
}