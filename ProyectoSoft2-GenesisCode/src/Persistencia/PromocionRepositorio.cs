using System.Collections.Generic;
using Dominio;
using Interfaces;
using JsonFlatFileDataStore;

namespace Persistencia
{
    public class PromocionRepositorio :IEntidadRepository<IDocumentCollection<Promocion>,IEnumerable<Promocion>>
    {
		public const string PATCH = "../../Persistencia/jsonDB.json";
		public DataStore store = new DataStore(PATCH);
		public IDocumentCollection<Promocion> getDataEntidad()
		{
			IDocumentCollection<Promocion> collection = store.GetCollection<Promocion>();
			return collection;
		}
		public IEnumerable<Promocion> getQueryEntidad()
		{
			IDocumentCollection<Promocion> collection = store.GetCollection<Promocion>();
			return collection.AsQueryable();
		}
    }
}