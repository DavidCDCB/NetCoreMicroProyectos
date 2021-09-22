using System.Collections.Generic;
using Dominio;
using Interfaces;
using JsonFlatFileDataStore;

namespace Persistencia
{
    public class UsuarioRepositorio :IEntidadRepository<IDocumentCollection<Usuario>,IEnumerable<Usuario>>
    {
		public const string PATCH = "../../Persistencia/jsonDB.json";
		public DataStore store = new DataStore(PATCH);
		public IDocumentCollection<Usuario> getDataEntidad()
		{
			IDocumentCollection<Usuario> collection = store.GetCollection<Usuario>();
			return collection;
		}
		public IEnumerable<Usuario> getQueryEntidad()
		{
			IDocumentCollection<Usuario> collection = store.GetCollection<Usuario>();
			return collection.AsQueryable();
		}
    }
}