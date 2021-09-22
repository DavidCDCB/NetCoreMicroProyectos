using System.Collections.Generic;
using Dominio;
using Interfaces;
using JsonFlatFileDataStore;

namespace Persistencia
{
    public class PlatoRepositorio :IEntidadRepository<IDocumentCollection<Plato>,IEnumerable<Plato>>
    {
		public const string PATCH = "../../Persistencia/jsonDB.json";
		public DataStore store = new DataStore(PATCH);
		public IDocumentCollection<Plato> getDataEntidad()
		{
			IDocumentCollection<Plato> collection = store.GetCollection<Plato>();
			return collection;
		}
		public IEnumerable<Plato> getQueryEntidad()
		{
			IDocumentCollection<Plato> collection = store.GetCollection<Plato>();
			return collection.AsQueryable();
		}
    }
}