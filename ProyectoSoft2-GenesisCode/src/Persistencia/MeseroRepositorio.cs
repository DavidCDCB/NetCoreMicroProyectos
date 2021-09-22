using System.Collections.Generic;
using Dominio;
using Interfaces;

//https://github.com/ttu/json-flatfile-datastore
using JsonFlatFileDataStore;

namespace Persistencia
{
	public class MeseroRepositorio : 
		IEntidadRepository<IDocumentCollection<Mesero>,IEnumerable<Mesero>>
	{
		// Todas las tablas van a estar almacenadas de manera ordenada en un JSON
		public const string PATCH = "../../Persistencia/jsonDB.json";
		public DataStore store = new DataStore(PATCH);

		public IDocumentCollection<Mesero> getDataEntidad()
		{
			IDocumentCollection<Mesero> collection = store.GetCollection<Mesero>();
			return collection;
		}

		public IEnumerable<Mesero> getQueryEntidad()
		{
			IDocumentCollection<Mesero> collection = store.GetCollection<Mesero>();
			return collection.AsQueryable();
		}
	}
}


