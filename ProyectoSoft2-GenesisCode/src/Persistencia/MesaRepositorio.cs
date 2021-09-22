using System.Collections.Generic;
using Dominio;
using Interfaces;

//https://github.com/ttu/json-flatfile-datastore
using JsonFlatFileDataStore;

namespace Persistencia
{
    public class MesaRepositorio: 
		IEntidadRepository<IDocumentCollection<Mesa>,IEnumerable<Mesa>>
	{
		// Todas las tablas van a estar almacenadas de manera ordenada en un JSON
		public const string PATCH = "../../Persistencia/jsonDB.json";
		public DataStore store = new DataStore(PATCH);

		public IDocumentCollection<Mesa> getDataEntidad()
		{
			IDocumentCollection<Mesa> collection = store.GetCollection<Mesa>();
			return collection;
		}

		public IEnumerable<Mesa> getQueryEntidad()
		{
			IDocumentCollection<Mesa> collection = store.GetCollection<Mesa>();
			return collection.AsQueryable();
		}
	}

}