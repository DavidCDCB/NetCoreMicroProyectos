using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

using Persistencia;
using Dominio;
using Interfaces;
using JsonFlatFileDataStore;
using Excepciones;
using DTO;
using Mapeadores;
using System.Globalization;

//http://www.7sabores.com/blog/descargar-un-branch-remoto-cuando-usamos-git

namespace Aplicacion
{
	public class ConsultarTurnosController
	{
		private IEntidadRepository<IDocumentCollection<Mesero>, IEnumerable<Mesero>> repoMesero;
		private IEntidadRepository<IDocumentCollection<Turno>, IEnumerable<Turno>> repoTurno;
		private IEntidadRepository<IDocumentCollection<Mesa>, IEnumerable<Mesa>> repoMesa;

		private string meseroActual;
		public void SetRepoMesero(Object repoMesero)
		{
			this.repoMesero = (MeseroRepositorio)repoMesero;
		}
		public void SetRepoTurno(Object repoTurno)
		{
			this.repoTurno = (TurnoRepositorio)repoTurno;
		}
		public void SetRepoMesa(Object repoMesa)
		{
			this.repoMesa = (MesaRepositorio)repoMesa;
		}

		// Imprime cualquier estructura y objetos
		private void PrintObject(string text, Object obj)
		{
			var options = new JsonSerializerOptions { WriteIndented = true };
			Console.WriteLine(text + "\n" + JsonSerializer.Serialize(obj, options));
		}

		// Valida si un turno corresponde a un mes y un año determinado
		private bool verificarEnFecha(Turno turno, ParametrosConsultaDTO parametros)
		{
			return turno.fkIdMesero.Equals(this.meseroActual)
				&& DateTime.ParseExact(turno.fecha,"MM-dd-yyyy", CultureInfo.InvariantCulture).Year == parametros.anio
				&& DateTime.ParseExact(turno.fecha,"MM-dd-yyyy", CultureInfo.InvariantCulture).Month == parametros.mes;
		}

		// Obtiene los datos basicos a partir del número de documento de un mesero
		public DatosBasicosMeseroDTO GetMesero(double id)
		{
			try
			{
				IEnumerable<Mesero> collection = repoMesero.getQueryEntidad();
				Mesero mesero = collection.First(x => x.documento.Equals(id.ToString()));

				if (!mesero.estado)
				{
					throw new MeseroInactivoException($"\n->El mesero {mesero.documento} se encuentra inactivo");
				}
				else
				{
					this.meseroActual = mesero.documento;
					return (mesero != null) ? MapeadorConsultarTurnos.CrearRespuestaDatos(mesero) : null;
				}
			}
			catch (MeseroInactivoException ex)
			{
				Console.WriteLine(ex.Message);
				return null;
			}
			catch (Exception)
			{
				return null;
			}
		}

		// Se obtiene una lista de turnos de acuerdo a los parametros de año y mes
		public IEnumerable<TurnoDTO> GetTurnos(ParametrosConsultaDTO input)
		{
			List<string> idMesas;
			IEnumerable<Turno> turnos = repoTurno.getQueryEntidad();
			IEnumerable<Mesa> mesas = repoMesa.getQueryEntidad();
			TurnoDTO respuesta = new TurnoDTO();
			List<TurnoDTO> consulta = new List<TurnoDTO>();

			PrintObject("Datos entrantes:", input);

			List<Turno> lTurnos = turnos.Where(
				x => verificarEnFecha(x, input)
			).ToList();

			foreach (Turno turno in lTurnos)
			{
				List<Mesa> lMesas = mesas.Where(
					x => x.fkIdTurno.Contains(turno.idTurno)
				).ToList();

				idMesas = lMesas.Select(x => x.idMesa).ToList();
				consulta.Add(MapeadorConsultarTurnos.CrearConsultaTurnos(turno, idMesas));
			}

			PrintObject("Datos de respuesta:", consulta);
			return consulta;
		}

		// Obtiene las mesas que corresponden a un determinado turno
		public IEnumerable<Mesa> GetInfoMesas(int idTurno)
		{
			IEnumerable<Mesa> collection = repoMesa.getQueryEntidad();

			List<Mesa> lMesas = collection.Where(
				x => x.fkIdTurno.Contains(idTurno.ToString())
			).ToList();

			return lMesas;
		}
	}
}