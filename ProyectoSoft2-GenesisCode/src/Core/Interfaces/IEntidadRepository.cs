using System;

namespace Interfaces
{
    public interface IEntidadRepository<T,U>
    {
		public T getDataEntidad();
		public U getQueryEntidad();
    }

    public interface IRepositorio<T, U>
    {
        public T Adicionar(T objeto);
        public T Buscar(U identificador);
        public U Eliminar(T objeto);
        public T Actualizar(T objeto);
    }
}