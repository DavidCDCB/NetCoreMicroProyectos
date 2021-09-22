using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using Persistencia;
using Dominio;
using Interfaces;
using System.Linq;
using Excepciones;
//using Excepciones;

namespace Aplicacion
{
    public class ControladorAdministrarMeseros
    {
        private IRepositorio<Mesero, string> _repositorio;
        public ControladorAdministrarMeseros(IRepositorio<Mesero, string> repositorio)
        {
            //this._repositorio = repositorio;
            this._repositorio = new RepositorioMeseros();
        }

        // Adiciona un mesero a la BD
        // Si el mesero ya existe, lanza una excepción MeseroException
        public Mesero AdicionarMesero(Mesero mesero)
        {
            try
            {
                Mesero nuevoMesero = BuscarMesero(mesero.nombre+" "+mesero.apellido);
                if (nuevoMesero == null)
                {
                    nuevoMesero = _repositorio.Adicionar(mesero);
                    return (Mesero)nuevoMesero;
                }
                throw new MeseroException("El mesero ya existe");
            }
            catch (MeseroException ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        // Actualiza un mesero en la BD
        public Mesero ActualizarMesero(Mesero mesero)
        {
            Console.WriteLine("ActualizarMesero");
            Mesero meseroActualizado = _repositorio.Actualizar(mesero);
            return meseroActualizado;
        }

        // Busca un mesero en la BD por su nombre completo
        public Mesero BuscarMesero(string nombre)
        {
            Mesero mesero = _repositorio.Buscar(nombre);
            return mesero;
        }

        // Establece el estado un mesero de la BD a inactivo
        public string EliminarMesero(Mesero mesero)
        {
            Console.WriteLine("EliminarMesero");
            try 
            {
                Mesero meseroEliminado = _repositorio.Buscar(mesero.nombre+" "+mesero.apellido);
                Console.WriteLine("Mesero buscado");
                Console.WriteLine(meseroEliminado.documento);
                if (meseroEliminado != null)
                {
                    _repositorio.Eliminar(meseroEliminado);
                    return String.Format("Se ha eliminado de forma exitosa el mesero {0} {1}", 
                                        meseroEliminado.nombre, meseroEliminado.apellido);
                }
                throw new MeseroException("No se puede eliminar el mesero. No existe en el sistema");
            }
            catch (MeseroException ex) 
            {
                return ex.Message;
            }
        }
    }
}