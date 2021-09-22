using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using Persistencia;
using Dominio;
using Interfaces;
using JsonFlatFileDataStore;
using Excepciones;
using Mapeadores;
using DTO;
using System.Globalization;
using System.Text.Json;

namespace Aplicacion
{
    public class GestionarTurnosController
    {

        // repositorios utilizados en el controlador gestionarTurnos
        public IEntidadRepository<IDocumentCollection<Mesero>, IEnumerable<Mesero>> repoMesero;
        public IEntidadRepository<IDocumentCollection<Turno>, IEnumerable<Turno>> repoTurno;
        public IEntidadRepository<IDocumentCollection<Mesa>, IEnumerable<Mesa>> repoMesa;

        //Mapeador golbal
        public MapeadorGestionarTurnosDto mapeadorGestionarTurnosDto = new MapeadorGestionarTurnosDto();

        //DTO global del calendario (Parametros iniciales)
        public CalendarioDto datosCalendario;
        //Mesero al que se le ejecuta todo con respecto a turnos
        public Mesero MeseroActual;
        //sets del repositorio
        public void setRepoMesero(Object repoMesero)
        {
            this.repoMesero = (MeseroRepositorio)repoMesero;
        }
        public void setRepoMesa(Object repoMesa)
        {
            this.repoMesa = (MesaRepositorio)repoMesa;
        }
        public void setRepoTurno(Object repoTurno)
        {
            this.repoTurno = (TurnoRepositorio)repoTurno;
        }


        /*
		Busca un mesero a partir de un id espefificado por url 
		*/
        public Mesero GetMesero(string id)
        {
            try
            {
                IEnumerable<Mesero> meseros = repoMesero.getQueryEntidad();
                Mesero mesero = meseros.First(x => x.documento == id);
                return mesero;
            }
            catch (System.InvalidOperationException)
            {
                return null;
            }
        }
        /*
       Genera una lista de todos los meseros almacenados
       */
        public IEnumerable<Mesero> GetMeseros()
        {
            IEnumerable<Mesero> meseros = repoMesero.getQueryEntidad();
            return meseros;
        }


        //Se verifica que el nombre completo del mesero pertenesca a un mesero en la base de datos
        public bool VerificarNombreCompleto(Mesero mesero, MeseroDto meseroDto)
        {
            return mesero.nombre == meseroDto.nombre
            && mesero.apellido == meseroDto.apellido;
        }


        //Se busca entre todos los meseros quien corresponda con el nombre completo ingresado
        // retorna el nombre completo del mesero encontrado con un mapeadorDto
        public MeseroDto BuscarMesero(MeseroDto nombreCompleto)
        {

            IEnumerable<Mesero> meseros = repoMesero.getQueryEntidad();

            try
            {
                Mesero mesero = meseros.First(x =>
                VerificarNombreCompleto(x, nombreCompleto));
                this.MeseroActual = mesero;
                return mapeadorGestionarTurnosDto.datosMesero(mesero);
            }

            catch (Exception)
            {
                throw new MeseroException("El nombre y apellido ingresado no corresponde a un Mesero registrado");
            }
        }

        //Obtiene los valores del calendario dados por el usuario para realizar las operaciones conrespecto a los turnos
        //tipo puede ser laboral o inactivo, fecha dada con el formato MM/dd/AAAA, numero semana ente 1 o 4, seleccion de turno
        // que indica si se agrega o elimina un turno

        public CalendarioDto ParametrosInicialesCalendario(CalendarioDto calendario)
        {
            try
            {
                
                datosCalendario = new CalendarioDto(calendario.tipo, calendario.fecha, calendario.numeroSemana, calendario.seleccionTurno);
                if (datosCalendario.seleccionTurno != null && datosCalendario.tipo != null && datosCalendario.fecha != null
                && datosCalendario.numeroSemana != 0)
                {
                    return datosCalendario;
                }
                else
                {
                    throw new DatosFormularioException("Faltan valores por ingresar, porfavor llene todos los campos");
                }
            }
            catch (DatosFormularioException)
            {
                throw new DatosFormularioException("");
            }
        }

        //Se verifica que no halla cruces entre el turnos y el inactivo de un mesero
        public bool VerificarCruces(Turno turnoVerificar, string fkIdMeseroVerificar)
        {
            List<string> horasOcupadas = new List<string>();
            IEnumerable<Turno> turnos = repoTurno.getQueryEntidad().Where(x => x.fkIdMesero == fkIdMeseroVerificar);
            foreach (Turno turno in turnos)
            {
                int horaInicio = ConvertirHorasInt(turno.horaInicio);
                int horaFin = ConvertirHorasInt(turno.horaFin);
                AgregarHorasIntermedias(horasOcupadas, horaInicio, horaFin, turno.fecha);
            }
            string horaInicialEntrante = turnoVerificar.horaInicio.Split(":")[0];
            string horaFinalEntrante = turnoVerificar.horaFin.Split(":")[0];
            // //PrintObject("horas Ocupadas", horasOcupadas);
            // string ultimo = (horasOcupadas.Count()-1).ToString();
            // string horaUltima = ultimo.Split(":")[0];
            // if(horaInicialEntrante ==  horaUltima){
            // 	return false;
            // }

            return (!horasOcupadas.Contains(turnoVerificar.fecha + "-" + horaInicialEntrante) && !horasOcupadas.Contains(turnoVerificar.fecha + "-" + horaFinalEntrante));
        }

        //Recorre una lista de objetos y las imprime
        private void PrintObject(string text, Object obj)
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            Console.WriteLine(text + "\n" + JsonSerializer.Serialize(obj, options));
        }

        //Se agregan las horas ente la horaInicio y horFin del turno a una lista de horasOcupadas
        public void AgregarHorasIntermedias(List<string> horasOcupadas, int horaInicio, int horaFin, string fecha)
        {
            for (int i = horaInicio; i <= horaFin; i++)
            {
                horasOcupadas.Add(fecha + "-" + i.ToString());
            }
        }

        //Conversiones
        //convierte una cadera con el formato "00:00:00: a TimeSpan
        public TimeSpan ConvertirHorasTimeSpan(string horas)
        {
            int[] partesTime = horas.Split(new char[] { ':' }).Select(x => Convert.ToInt32(x)).ToArray();
            TimeSpan tiempo = new TimeSpan(partesTime[0], partesTime[1], partesTime[2]);
            return tiempo;

        }
        //Convierte una cadena con el formato "00:00:00" a int 00
        public int ConvertirHorasInt(string horas)
        {
            int[] partesTime = horas.Split(new char[] { ':' }).Select(x => Convert.ToInt32(x)).ToArray();
            int hora = partesTime[0];
            return hora;
        }

        //Convierte una cadena con el formato 00-00-0000 a DateTime con el formato MM-dd-yyyy
        public DateTime ConvertirFecha(string fecha)
        {
            string format = "MM-dd-yyyy";
            DateTime fechaDateTime = DateTime.ParseExact(fecha, format, CultureInfo.InvariantCulture);
            return fechaDateTime;
        }

        //Filtra los turnos de acuerdo a su fecha mendualmente
        public List<Turno> FiltrarTurnosMes(Turno turnoMesero, string fkMesero)
        {

            List<Turno> turnosxMes = new List<Turno>();
            IEnumerable<Turno> turnos = repoTurno.getQueryEntidad();

            foreach (Turno turno in turnos)
            {
                if (turno.fkIdMesero == fkMesero)
                {
                    if (turno.tipo == "Laboral")
                    {

                        if (turno.fecha.Substring(0, 2) == turnoMesero.fecha.Substring(0, 2) && turno.fecha.Substring(6) == turnoMesero.fecha.Substring(6))
                        {
                            turnosxMes.Add(turno);

                        }
                    }
                }

            }

            return turnosxMes;

        }
        //filtra los turnos deacuerdo a su fecha semanalmente
        public bool VerificarHorasTotalesLaboralesSemanales(Turno turnoMesero, string fkmesero)
        {

            List<Turno> turnosxMes = FiltrarTurnosMes(turnoMesero, fkmesero);
            int inicioSemana = 0;
            int semanaFin = 7;
            int horas = 0;
            int limite = 20;
            for (int i = 1; i <= 4; i++)
            {
                foreach (Turno turno in turnosxMes)
                {

                    string diaString = turno.fecha.Substring(3, 2);

                    int dia = Int32.Parse(diaString);

                    if (dia <= semanaFin && dia >= inicioSemana)
                    {
                        int horaInicio = ConvertirHorasInt(turno.horaInicio);
                        int horaFin = ConvertirHorasInt(turno.horaFin);
                        int bloque = horaFin - horaInicio;
                        horas += bloque;

                        //turnosxMes.Remove(turno);
                    }

                }
                string diaMeseroString = turnoMesero.fecha.Substring(3, 2);
                int diaMesero = Int32.Parse(diaMeseroString);

                if (diaMesero <= semanaFin && diaMesero >= inicioSemana)
                {

                    int horaInicio = ConvertirHorasInt(turnoMesero.horaInicio);
                    int horaFin = ConvertirHorasInt(turnoMesero.horaFin);
                    int bloque = horaFin - horaInicio;
                    horas += bloque;
                    if (horas > limite)
                    {
                        return false;
                    }

                }
                else
                {
                    inicioSemana += 7;
                    semanaFin += 7;
                    horas = 0;
                }

            }
            return true;

        }

        //Verifica los bloques laborales que no sean menores a una hora o mayores a 4 horas
        public bool VerificarBloqueHora(Turno turno)
        {
            if (turno.tipo == "Laboral")
            {
                int horaInicio = ConvertirHorasInt(turno.horaInicio);
                int horaFin = ConvertirHorasInt(turno.horaFin);
                int bloque = horaFin - horaInicio;
                if (bloque <= 1 || bloque > 4)
                {
                    return false;
                }

            }
            return true;
        }
        //Agrega un turno ya sea inactivo o laboral con sus validaciones
        public async Task<Turno> AgregarTurnoAsync(Turno turno)
        {
            try
            {
                if (datosCalendario.seleccionTurno == "Agregar")
                {
                    IDocumentCollection<Turno> turnos = repoTurno.getDataEntidad();
                    List<string> ids = repoTurno.getQueryEntidad()
                        .Select(x => x.idTurno).ToList();
                    string nId = ids.Max();


                    int idInt = Int32.Parse(turno.idTurno);
                    int nIdInt = Int32.Parse(nId);

                    idInt = ++nIdInt;
                    turno.idTurno = idInt.ToString();
                    turno.fkIdMesero = MeseroActual.documento;
                    if (VerificarCruces(turno, MeseroActual.documento))
                    {
                        if (VerificarBloqueHora(turno))
                        {
                            if (VerificarHorasTotalesLaboralesSemanales(turno, turno.fkIdMesero) == true)

                            {
                                await turnos.InsertOneAsync(turno);
                            }
                            else
                            {
                                throw new TurnoException("El total de horas laborales semanales se excede de 20 horas");
                            }
                        }
                        else
                        {
                            throw new TurnoException("El bloque del turno debe ser entre 2 y 4 horas");

                        }
                    }
                    else
                    {

                        throw new TurnoException("hay existencia de cruces ");
                    }




                }
                return turno;
            }
            catch (TurnoException )
            {
                throw new TurnoException("");
            }

        }
        //Se intercambia el turno laboral de un mesero con otro mesero
        public async Task<Turno> IntercambiarTurno(TurnoIntercambioDto tunosIntercambio)
        {
            IEnumerable<Turno> turnos = repoTurno.getQueryEntidad();
            Turno turnoActual = turnos.First(x => x.idTurno == tunosIntercambio.idTurnoActual);
            Turno turnoIntercambiar = turnos.First(y => y.idTurno == tunosIntercambio.idTurnoIntercambio);
            try
            {
                if (datosCalendario.tipo == "Laboral")
                {
                    
                    if (turnoActual.tipo == "Laboral" && turnoIntercambiar.tipo == "Laboral")
                    {
                        if (VerificarCruces(turnoActual, tunosIntercambio.fkIdMeseroIntercambio) && VerificarCruces(turnoIntercambiar, tunosIntercambio.fkIdMeseroActual))
                        {
                            string idActual = tunosIntercambio.fkIdMeseroActual;
                            string idIntercambio = tunosIntercambio.fkIdMeseroIntercambio;

                            turnoActual.fkIdMesero = idIntercambio;
                            turnoIntercambiar.fkIdMesero = idActual;

                            IDocumentCollection<Turno> lTurnos = repoTurno.getDataEntidad();
                            await lTurnos.ReplaceOneAsync(e => e.idTurno == turnoActual.idTurno, turnoActual);
                            await lTurnos.ReplaceOneAsync(i => i.idTurno == turnoIntercambiar.idTurno, turnoIntercambiar);
                            return GetTurno(turnoActual.idTurno);
                        }
                        else
                        {
                            throw new TurnoException("Existen cruces con los turnos inactivos del mesero a intercambiar");
                        }
                    }
                
                }
                return null;
                

               
            }
            catch (TurnoException  )
            {
                throw new TurnoException("");
            }


        }
        // Se asigna a cada mesero las mesas a las que debe atender en sus turnos laborales
        public List<Mesa> GenerarAsignacionMesas()
        {
            IEnumerable<Turno> turnos = repoTurno.getQueryEntidad();
            Dictionary<string, int> turnoxMesero = new Dictionary<string, int>();
            foreach (Turno turno in turnos)
            {
                if (turnoxMesero.Keys.Count == 0)
                {
                    turnoxMesero.Add(turno.fecha + "|" + turno.horaInicio + "|" + turno.horaFin, 1);
                }
                else
                {
                    if (turnoxMesero.Keys.Contains(turno.fecha + "|" + turno.horaInicio + "|" + turno.horaFin))
                    {
                        turnoxMesero[turno.fecha + "|" + turno.horaInicio + "|" + turno.horaFin]++;
                    }
                    else
                    {
                        turnoxMesero.Add(turno.fecha + "|" + turno.horaInicio + "|" + turno.horaFin, 1);
                    }
                }

            }
            foreach (string llave in turnoxMesero.Keys)
            {
                float resultado = (float)CantidadTotalMesas() / turnoxMesero[llave];

                turnoxMesero[llave] = (int)Math.Round(resultado);

            }
            Mesa mesa;
            List<Mesa> mesas = repoMesa.getQueryEntidad().ToList();

            int contador = 0;
            foreach (string llave in turnoxMesero.Keys)
            {
                for (int i = 0; i < turnoxMesero[llave]; i++)
                {
                    llave.Split("|");
                    Turno turnoMesa = turnos.First(x => x.fecha == llave.Split("|")[0] && x.horaInicio == llave.Split("|")[1] && x.horaFin == llave.Split("|")[2]);
                    if (contador + i < mesas.Count)
                    {
                        mesa = mesas[i + contador];
                        mesa.fkIdTurno.Add(turnoMesa.idTurno);
                    }
                    else
                    {
                        contador = 0;
                    }
                }
                contador += turnoxMesero[llave];
            }

            PrintObject("list", turnoxMesero);
            return mesas;


        }



        // retorna la cantidad total de mesas del restaurante
        public int CantidadTotalMesas()
        {
            return GetMesas().Count();
        }
        /*
       Busca un Turno a partir de un id espefificado por url
       */
        public Turno GetTurno(string id)
        {
            try
            {
                IEnumerable<Turno> turnos = repoTurno.getQueryEntidad();
                Turno turno = turnos.First(x => x.idTurno == id);
                return turno;
            }
            catch (System.InvalidOperationException)
            {
                return null;
            }
        }
        //Busca una mesa dado su id

        public Mesa GetMesa(string id)
        {
            try
            {
                IEnumerable<Mesa> mesas = repoMesa.getQueryEntidad();
                Mesa mesa = mesas.First(x => x.idMesa == id);
                return mesa;
            }
            catch (System.InvalidOperationException)
            {
                return null;
            }
        }

        /*
      Genera una lista de todos los turnos almacenados
      */
        public IEnumerable<Turno> GetTurnos()
        {
            IEnumerable<Turno> turnos = repoTurno.getQueryEntidad();
            return turnos;
        }

        /*
      Genera una lista de todas las mesas almacenadas
      */
        public IEnumerable<Mesa> GetMesas()
        {
            IEnumerable<Mesa> mesas = repoMesa.getQueryEntidad();
            return mesas;
        }


        //Actualiza las measas de acuerdo a la generacion de asignacion de mesas para los mesero en su respectivo turno
        public async Task<IEnumerable<Mesa>> ActualizarMesas()
        {
            IEnumerable<Mesa> actuales = this.GetMesas().ToList();
            List<Mesa> mesasAsignadas = GenerarAsignacionMesas();
            IDocumentCollection<Mesa> mesas = repoMesa.getDataEntidad();
            int contador = 0;
            foreach (Mesa mesa in actuales)
            {
                if (actuales != null)
                {

                    mesa.fkIdTurno = mesasAsignadas[contador].fkIdTurno;


                    await mesas.ReplaceOneAsync(e => e.idMesa == mesa.idMesa, mesa);

                }
                contador++;
            }
            return actuales;



        }

        /*
		Elimina un turno 
		*/
        public async Task<Turno> RemoveTurno(string id)
        {


            Turno actual = this.GetTurno(id);
            if (datosCalendario.seleccionTurno == "Eliminar")
            {
                if (actual != null)
                {
                    var turnos = repoTurno.getDataEntidad();
                    await turnos.DeleteOneAsync(e => e.idTurno == id);
                }else
                {
                    
                    return null;
                }

            }
            return actual;
        }
    }
}
