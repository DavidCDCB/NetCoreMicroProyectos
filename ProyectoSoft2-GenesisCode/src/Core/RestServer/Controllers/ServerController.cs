using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Excepciones;
using Dominio;
using Interfaces;
using Persistencia;
using DTO;
using JsonFlatFileDataStore;

namespace RestServer
{
    //Caso de uso GenerarInformeGerencial{
    [Route("api")]
    [ApiController]
    public class ServerController : ControllerBase
    {
        //private readonly ServerModel _publicacionController = new ServerModel();
        //Caso de uso GenerarInformeGerencial{
        public IEntidadRepository<IDocumentCollection<Venta>, IEnumerable<Venta>> repoVenta
        	= new VentaRepositorio();
        public IEntidadRepository<IDocumentCollection<Cliente>, IEnumerable<Cliente>> repoCliente
        	= new ClienteRepositorio();
        public IEntidadRepository<IDocumentCollection<Finanza>, IEnumerable<Finanza>> repoFinanza
        	= new FinanzaRepositorio();
        public IEntidadRepository<IDocumentCollection<Plato>, IEnumerable<Plato>> repoPlato
        	= new PlatoRepositorio();

        public IEntidadRepository<IDocumentCollection<Usuario>, IEnumerable<Usuario>> usuarioRepositorio = new UsuarioRepositorio();
        public IEntidadRepository<IDocumentCollection<Promocion>, IEnumerable<Promocion>> promocionRepositorio = new PromocionRepositorio();
        public IEntidadRepository<IDocumentCollection<Log>, IEnumerable<Log>> loginRepositorio = new LogRepositorio();
        // ... El serverController usa varios objetos de tipo repositorio segun su entidad

        // Repos de ConsultarTurnos{
        public IEntidadRepository<IDocumentCollection<Mesero>, IEnumerable<Mesero>> meseroRepositorio
            = new MeseroRepositorio();
        public IEntidadRepository<IDocumentCollection<Turno>, IEnumerable<Turno>> turnoRepositorio
            = new TurnoRepositorio();
        public IEntidadRepository<IDocumentCollection<Mesa>, IEnumerable<Mesa>> mesaRepositorio
            = new MesaRepositorio();
        // }Repos de ConsultarTurnos

        public ServerController()
        {
            //this._publicacionController = publicacionController;
            // Desde afuera se asigna el tipo de repositoria que se usa para una entidad espeficifca
            ServerModel.setRepoCliente(repoCliente);
            ServerModel.setRepoFinanza(repoFinanza);
            ServerModel.setRepoVenta(repoVenta);
            ServerModel.setRepoPlato(repoPlato);

            ServerModel.setRepositorioPlato(repoPlato);
            ServerModel.setRepositorioUsuario(usuarioRepositorio);
            ServerModel.setRepositorioPromocion(promocionRepositorio);
            ServerModel.setRepositorioLogin(loginRepositorio);

            ServerModel.SetRepoMesero(meseroRepositorio);
            ServerModel.SetRepoTurno(turnoRepositorio);
            ServerModel.SetRepoMesa(mesaRepositorio);
            _serverModel = new ServerModel();
            // }Creacion de repos ConsultarTurnos
        }
        //http://localhost:5000/api/informe?fechaInicial=2017-05-18T02:36:57&fechaFinal=2022-05-18T02:36:57
        [HttpGet("informe")]
        public IActionResult GetInformeGerencial(DateTime fechaInicial, DateTime fechaFinal)
        {
            var egresos = ServerModel.GetInformeGerencialRangoFecha(fechaInicial, fechaFinal);
            return Ok(egresos);
        }

        /*
        GET http://localhost:5000/api/usuarios
        */
        [HttpGet("usuarios")]
        public IActionResult GetUsuariosAsync()
        {
            var usuarios = ServerModel.GetUsuarios();
            return Ok(usuarios);
        }

        /*
        GET http://localhost:5000/api/platos
        */
        [HttpGet("platos")]
        public IActionResult GetPlatosAsync()
        {
            var platos = ServerModel.GetPlatos();
            return Ok(platos);
        }
        private readonly ICUController _postRepository;
        private ServerModel _serverModel;

        /*
        GET http://localhost:5000/api/promociones
        */
        [HttpGet("promociones")]
        public IActionResult GetPromocionesAsync()
        {
            var promociones = ServerModel.GetPromociones();
            return Ok(promociones);
        }

        /*
        GET http://localhost:5000/api/plato/1000
        */

        [HttpGet("plato/{id}")]
        public IActionResult GetPlato(string id)
        {
            var publicacion = ServerModel.GetPlato(id);
            if (publicacion == null)
            {
                throw new PromocionesException("No se pudo obtener el plato para el id suministrado.");
            }
            return Ok(publicacion);
        }

        /*
        GET http://localhost:5000/api/usuario/12345
        */
        [HttpGet("usuario/{id}")]
        public IActionResult GetUsuario(string id)
        {
            var usuario = ServerModel.GetUsuario(id);
            if (usuario == null)
            {
                throw new PromocionesException("No se pudo obtener el usuario para el id suministrado.");
            }
            return Ok(usuario);
        }

        /*
        GET http://localhost:5000/api/promocion/2000
        */
        [HttpGet("promocion/{id}")]
        public IActionResult GetPromociones(string id)
        {
            var promocion = ServerModel.GetPromocion(id);
            if (promocion == null)
            {
                throw new PromocionesException("No se pudo obtener la promoción para el id suministrado.");
            }

            return Ok(promocion);
        }

        /*
        POST http://localhost:5000/api/platos
        {
            "idplato": "1010",
            "nombre": "Hamburgesa",
            "valor": 20000.0,
            "clasificacion": "comida rapida"
        }
        */
        [HttpPost("platos")]
        public async Task<IActionResult> SetPlatoAsync(Plato plato)
        {
            try
            {
                var creado = await ServerModel.SetPlatoAsync(plato);
                return Ok(creado);
            }
            catch (Exception)
            {
                 throw new PromocionesException("El objeto JSON suministrado es inválido y no se pudo crear el plato.");
            }

        }


        //Inicio EndPoints Gestionar Turnos

        //POST http://localhost:5000/api/calendario
        /*
        El tipo puede ser "Laboral" o "Inactivo"
        La seleccionTurno puede ser "Agregar", "Eliminar"
            {
                "tipo" : "Laboral",
                "fecha" : "12-09-2021",
                "numeroSemana" : "2",
                "seleccionTurno": "Agregar"
            }
        */

        [HttpPost("calendario")]
        public IActionResult ParametrosInicialesCalendario(CalendarioDto calendario)
        {
            try
            {
                CalendarioDto calendarioDto = ServerModel.ParametrosInicialesCalendario(calendario);
                return Ok(calendario);
            }
            catch (DatosFormularioException)
            {

                return BadRequest();


            }
        }

        //POST http://localhost:5000/api/mesero
        /*
        {
            "Nombre": "Jhonny",
            "Apellido": "Jostar"
        }
        */
        [HttpPost("mesero")]
        public IActionResult BuscarMesero(MeseroDto nombreCompleto)
        {
            try
            {
                MeseroDto mesero = ServerModel.BuscarMesero(nombreCompleto);
                return Ok(mesero);
            }
            catch (MeseroException)
            {

                return NotFound();


            }

        }
        //POST http://localhost:5000/api/turno
        /*
        {
        "idTurno": "34",
            "tipo": "Laboral",
            "fecha": "12-16-2021",
            "horaInicio": "18:00:00",
            "horaFin": "21:00:00",
            "fkIdMesero": "1"
        }
        */
        [HttpPost("turno")]
        public async Task<IActionResult> AgregarTurnoAsync(Turno turno)
        {
            try
            {

                Turno creado = await ServerModel.AgregarTurnoAsync(turno);              //1231111111111111111111111111111111111111111111111111111
                return Ok(creado);
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }

        /*
        POST http://localhost:5000/api/promociones
        {
            "idpromocion": "2001",
            "fechaExpiracion": "08-01-2021",
            "descuento": 5000.0,
            "fkIdplato": "1001"
        }
        */
        [HttpPost("promociones")]
        public async Task<IActionResult> SetPromocionAsync(Promocion promocion)
        {
            try
            {
                var creado = await ServerModel.SetPromocionAsync(promocion);
                return Ok(creado);
            }
            catch (Exception)
            {
                throw new PromocionesException("El objeto JSON suministrado es inválido y no se pudo crear la promoción.");
            }
        }
        //GET http://localhost:5000/api/meseros
        [HttpGet("meseros")]
        public IActionResult GetMeserosAsync()
        {
            IEnumerable<Mesero> meseros = ServerModel.GetMeseros();
            return Ok(meseros);
        }

        //GET http://localhost:5000/api/turnos
        [HttpGet("turnos")]
        public IActionResult GetTurnosAsync()
        {
            IEnumerable<Turno> turnos = ServerModel.GetTurnos();
            return Ok(turnos);
        }

        //GET http://localhost:5000/api/mesas
        [HttpGet("mesas")]
        public IActionResult GetMesasAsync()
        {
            IEnumerable<Mesa> mesa = ServerModel.GetMesas();
            return Ok(mesa);
        }

        //GET http://localhost:5000/api/meseros/1
        [HttpGet("meseros/{id}")]
        public IActionResult GetMesero(string id)
        {
            Mesero mesero = ServerModel.GetMesero(id);
            if (mesero == null)
            {
                return NotFound();
            }

            return Ok(mesero);
        }

        //GET http://localhost:5000/api/mesas/1
        [HttpGet("mesas/{id}")]
        public IActionResult GetMesa(string id)
        {
            Mesa mesa = ServerModel.GetMesa(id);
            if (mesa == null)
            {
                return NotFound();
            }

            return Ok(mesa);
        }

        //GET http://localhost:5000/api/turno/10
        [HttpGet("turno/{id}")]
        public IActionResult GetTurno(string id)
        {
            Turno turno = ServerModel.GetTurno(id);
            if (turno == null)
            {
                return NotFound();
            }

            return Ok(turno);
        }

        //PUT http://localhost:5000/api/turnoIntercambio
        /*
            {
            "fkIdMeseroActual": "110546789843",
            "fkIdMeseroIntercambio":"10546789811",
            "idTurnoActual": "21",
            "idTurnoIntercambio":"10"
            }
        */
        [HttpPut("turnoIntercambio")]
        public async Task<IActionResult> IntercambiarTurno(TurnoIntercambioDto turnosIntercambio)
        {
            try
            {
                Turno actualizado = await ServerModel.IntercambiarTurno(turnosIntercambio);

                if (actualizado == null)
                {
                    return NotFound();
                }

                return Ok(actualizado);
            }catch(TurnoException)
            {
                return BadRequest();
            }
        }

        /*
        POST http://localhost:5000/api/usuarios
        {
            "documento": "79797",
            "correo": "elbailarin@gmail.com",
            "rol": "mesero",
            "nombre": "Roberto",
            "apellido": "Roena"
        }
        */
        [HttpPost("usuarios")]
        public async Task<IActionResult> SetUsuarioAsync(Usuario usuario)
        {
            try
            {
                var creado = await ServerModel.SetUsuarioAsync(usuario);
                return Ok(creado);
            }
            catch (Exception)
            {
                throw new PromocionesException("El objeto JSON suministrado es inválido y no se pudo crear el usuario.");
            }
        }

        /*
        POST http://localhost:5000/api/login
        {
            "fkdocumento": "12345",
            "clave": "keyingreso"
        }
        */
        [HttpPost("login")]
        public IActionResult LoginAsync(Log login)
        {
            try
            {
                var creado = ServerModel.LoginAsync(login);
                return Ok(creado);
            }
            catch (Exception)
            {
                throw new PromocionesException("El objeto JSON suministrado es inválido y no se pudo realizar la autenticación, revise los parametros y las credenciales de ingreso.");
            }
        }


        /*
        PUT http://localhost:5000/api/promociones
        {
            "idpromocion": "2000",
            "fechaExpiracion": "08-30-2021",
            "descuento": 5000.0,
            "fkIdplato": "1001"
        }
        */
        [HttpPut("promociones")]
        public async Task<IActionResult> UpdatePromocion(Promocion promocion)
        {
            var actualizado = await ServerModel.UpdatePromocion(promocion);

            if (actualizado == null)
            {
                throw new PromocionesException("No se pudo realizar la actualización debido a que alguno de los parametros suministrados en inválido.");
            }
            return Ok(actualizado);
        }

        //DELETE http://localhost:5000/api/turnos/10
        [HttpDelete("turnos/{id}")]
        public async Task<IActionResult> RemoveTurno(string id)
        {
            Turno eliminado = await ServerModel.RemoveTurno(id);

            if (eliminado == null)
            {
               return NotFound();
               
            }

            return Ok(eliminado);
        }

        /*
        DELETE http://localhost:5000/api/usuarios/12345
        */
        [HttpDelete("usuarios/{id}")]
        public async Task<IActionResult> RemoveUsuario(string id)
        {
            var eliminado = await ServerModel.RemoveUsuario(id);

            if (eliminado == null)
            {
                throw new PromocionesException("El documento suministrado es inválido.");
            }
            return Ok(eliminado);
        }

		/*
        DELETE http://localhost:5000/api/promociones/2001
        */
        [HttpDelete("promociones/{id}")]
        public async Task<IActionResult> RemovePromocion(string id)
        {
            var eliminado = await ServerModel.RemovePromocion(id);

            if (eliminado == null)
            {
                throw new PromocionesException("El id suministrado es inválido.");
            }

            return Ok(eliminado);
        }

        // }Endpoinds ConsultarTurnos

        // Endpoinds ConsultarTurnos{
        // GET http://localhost:5000/api/consultarTurnos/datosMesero/10546789843
        [HttpGet("consultarTurnos/datosMesero/{id}")]
        public IActionResult GetDatosBasicosMesero(double id)
        {
            DatosBasicosMeseroDTO datosMesero = ServerModel.GetDatosBasicosMesero(id);
            if (datosMesero == null)
            {
                return NotFound();
            }
            return Ok(datosMesero);
        }
        // GET http://localhost:5000/api/consultarTurnos/mesasEnTurno/20
        [HttpGet("consultarTurnos/mesasEnTurno/{id}")]
        public IActionResult GetInfoMesas(int id)
        {
            IEnumerable<Mesa> datosMesero = ServerModel.GetInfoMesas(id);
            if (datosMesero == null)
            {
                return NotFound();
            }
            return Ok(datosMesero);
        }
        // POST http://localhost:5000/api/consultarTurnos/turnos
        [HttpPost("consultarTurnos/turnos")]
        public IActionResult GetConsultaTurnos(ParametrosConsultaDTO input)
        {
            IEnumerable<TurnoDTO> turnos = ServerModel.GetConsultaTurnos(input);
            if (turnos == null)
            {
                return NotFound();
            }
            return Ok(turnos);
        }
        // }Endpoinds ConsultarTurnos
        //GET http://localhost:5000/api/asignacion

        [HttpGet("asignacion")]
        public IActionResult GenerarAsignacionMesas()
        {
            List<Mesa> mesasAsignadas = ServerModel.GenerarAsignacionMesas();
            return Ok(mesasAsignadas);

        }

        //PUT http://localhost:5000/api/mesas
        [HttpPut("mesas")]
        public async Task<IActionResult> ActualizarMesas()
        {
            IEnumerable<Mesa> actualizado = await ServerModel.ActualizarMesas();

            if (actualizado == null)
            {
                return NotFound();
            }

            return Ok(actualizado);
        }

        //POST http://localhost:5000/api/meseros/post
        [HttpPost("meseros/post")]
        public IActionResult AdicionarMesero(Mesero mesero)
        {
            Mesero meseroAdicionado = ServerModel.AdicionarMesero(mesero);
            if (meseroAdicionado == null)
            {
                return StatusCode(500, "No se pudo adicionar el mesero");
            }
            return Ok(meseroAdicionado);
        }

        //GET http://localhost:5000/api/meseros/nombre%20apeliido
        [HttpGet("meseros/get/{nombre}")]
        public IActionResult BuscarMeseroChingon(String nombre)
        {
            Console.WriteLine(nombre);
            Mesero mesero = ServerModel.BuscarMeseroChingon(nombre);
            if (mesero == null)
            {
                return NotFound("No se pudo encontrar el mesero");
            }
            return Ok(mesero);
        }

        //PUT http://localhost:5000/api/meseros/put
        [HttpPut("meseros/put")]
        public IActionResult ActualizarMesero(Mesero mesero) 
        {
            Mesero meseroActualizado = ServerModel.ActualizarMesero(mesero);
            if (meseroActualizado == null) 
            {
                return StatusCode(500, "No se pudo actualizar el mesero");
            }
            return Ok(meseroActualizado);
        }

        //PUT http://localhost:5000/api/meseros/delete
        [HttpPut("meseros/delete")]
        public IActionResult EliminarMesero(Mesero mesero) 
        {
            string mensaje = ServerModel.EliminarMesero(mesero);
            if (mensaje.Equals("No se puede eliminar el mesero. No existe en el sistema"))
            {
                return StatusCode(500, mensaje);
            }
            return Ok(mensaje);
        }
    }
}