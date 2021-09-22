using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Aplicacion;
using Dominio;
using DTO;

namespace RestServer
{
	//Caso de uso GenerarInformeGerencial{
    public class ServerModel
    {
		public static GenerarInformeGerencialController CU = new GenerarInformeGerencialController();
		public static AutenticarController A = new AutenticarController();
		public static GestionaPromocionesController GP = new GestionaPromocionesController();
		public static ControladorAdministrarMeseros controladorAdministrarMeseros = new ControladorAdministrarMeseros(null);

		// Fachada ConsultarTurnos{
		public static ConsultarTurnosController ConsultarTurnos = new ConsultarTurnosController();
		public static GestionarTurnosController GT = new GestionarTurnosController();
		public static DatosBasicosMeseroDTO GetDatosBasicosMesero(double id)
		{
			return ConsultarTurnos.GetMesero(id);
		}
		/*****************************************
			CASO DE USO GESTIONAR PROMOCIONES
		*****************************************/
		public static Plato GetPlato(string id)
		{
			return GP.GetPlato(id);
		}
		
		public static IEnumerable<Plato> GetPlatos()
		{
			return GP.GetPlatos();
		}

		public static Task<Plato> SetPlatoAsync(Plato plato)
		{
			return GP.SetPlatoAsync(plato);
		}

		public static void setRepositorioPlato(Object repositorioPlato)
		{
			GP.setRepositorioPlato(repositorioPlato);
		}

		public static Promocion GetPromocion(string id)
		{
			return GP.GetPromocion(id);
		}
		
		public static IEnumerable<Promocion> GetPromociones()
		{
			return GP.GetPromociones();
		}

		public static void setRepoVenta(Object repoVenta){
			CU.setRepoVenta(repoVenta);
		}

		public static void setRepoCliente(Object repoCliente){
			CU.setRepoCliente(repoCliente);
		}

		public static void setRepoFinanza(Object repoFinanza){
			CU.setRepoFinanza(repoFinanza);
		}
		
		public static void setRepoPlato(Object repoPlato){
			CU.setRepoPlato(repoPlato);
		}

		public static InformeDTO GetInformeGerencialRangoFecha(DateTime fechaInicial, DateTime fechaFinal)
		{
			return CU.GetInformeGerencialRangoFecha(fechaInicial, fechaFinal);
		}	
		public static Task<Promocion> SetPromocionAsync(Promocion promocion)
		{
			return GP.SetPromocionAsync(promocion);
		}

		public static Task<Promocion> RemovePromocion(string id)
		{
			return GP.RemovePromocion(id);
		}
		public  static Task<Promocion> UpdatePromocion(Promocion promocion)
		{
			return  GP.UpdatePromocion(promocion);		
		}
		public static void setRepositorioPromocion(Object repositorioPromocion)
		{
			GP.setRepositorioPromocion(repositorioPromocion);
		}

		/*******************************
			CASO DE USO AUTENTICACION
		********************************/
		public static Usuario GetUsuario(string id)
		{
			return A.GetUsuario(id);
		}
		
		public static IEnumerable<Usuario> GetUsuarios()
		{
			return A.GetUsuarios();
		}

		public static Task<Usuario> SetUsuarioAsync(Usuario usuario)
		{
			return A.SetUsuarioAsync(usuario);
		}

		public static Task<Usuario> RemoveUsuario(string id)
		{
			return A.RemoveUsuario(id);
		}
		
		public static void setRepositorioUsuario(Object repositorioUsuario)
		{
			A.setRepositorioUsuario(repositorioUsuario);
		}

		public static string LoginAsync(Log login)
		{
			return A.LoginAsync(login);
		}

		public static void setRepositorioLogin(Object repositorioLogin)
		{
			A.setRepositorioLogin(repositorioLogin);
		}
	//}Caso de uso GenerarInformeGerencial
		public static IEnumerable<TurnoDTO> GetConsultaTurnos(ParametrosConsultaDTO input)
		{
			return ConsultarTurnos.GetTurnos(input);
		}
		public static IEnumerable<Mesa> GetInfoMesas(int input)
		{
			return ConsultarTurnos.GetInfoMesas(input);
		}
		public static void SetRepoMesero(Object repoMesero)
		{
			ConsultarTurnos.SetRepoMesero(repoMesero);
			GT.setRepoMesero(repoMesero);
		}
		public static void SetRepoTurno(Object repoTurno)
		{
			ConsultarTurnos.SetRepoTurno(repoTurno);
			GT.setRepoTurno(repoTurno);
		}
		public static void SetRepoMesa(Object repoMesa)
		{
			ConsultarTurnos.SetRepoMesa(repoMesa);
			GT.setRepoMesa(repoMesa);
		}
        public static MeseroDto BuscarMesero(MeseroDto nombreCompleto)
        {
            return GT.BuscarMesero(nombreCompleto);
        }
        public static Mesero GetMesero(string id)
        {
            return GT.GetMesero(id);
        }
        public static Mesa GetMesa(string id)
        {
            return GT.GetMesa(id);
        }
        public static Turno GetTurno(string id)
        {
            return GT.GetTurno(id);
        }
        public static List<Mesa> GenerarAsignacionMesas()
        {
            return GT.GenerarAsignacionMesas();
        }

        public static Task<IEnumerable<Mesa>> ActualizarMesas()
        {
            return GT.ActualizarMesas();
		}

        public ServerModel() {}

        public static Mesero AdicionarMesero(Mesero mesero)
        {
            return controladorAdministrarMeseros.AdicionarMesero(mesero);
        }

        public static Mesero BuscarMeseroChingon(String nombre)
        {
            return controladorAdministrarMeseros.BuscarMesero(nombre);
        }

        public static string EliminarMesero(Mesero mesero)
        {
            return controladorAdministrarMeseros.EliminarMesero(mesero);
        }

        public static Mesero ActualizarMesero(Mesero mesero)
        {
            return controladorAdministrarMeseros.ActualizarMesero(mesero);
        }
        public static CalendarioDto ParametrosInicialesCalendario(CalendarioDto calendario)
        {
            return GT.ParametrosInicialesCalendario(calendario);
        }

        public static IEnumerable<Mesero> GetMeseros()
        {
            return GT.GetMeseros();
        }

        public static IEnumerable<Turno> GetTurnos()
        {
            return GT.GetTurnos();
        }

        public static IEnumerable<Mesa> GetMesas()
        {
            return GT.GetMesas();
        }

        public static Task<Turno> RemoveTurno(string id)
        {
            return GT.RemoveTurno(id);
        }

        public static Task<Turno> AgregarTurnoAsync(Turno turno)
        {
            return GT.AgregarTurnoAsync(turno);
        }

        public static Task<Turno> IntercambiarTurno(TurnoIntercambioDto turnosIntercambio)
        {
            return GT.IntercambiarTurno(turnosIntercambio);
        }
	}

}