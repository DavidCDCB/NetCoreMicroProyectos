using System.Collections.Generic;
using Dominio;
using Interfaces;

//https://github.com/ttu/json-flatfile-datastore
using JsonFlatFileDataStore;

namespace Persistencia
{
    public class TurnoRepositorio: 
		IEntidadRepository<IDocumentCollection<Turno>,IEnumerable<Turno>>
	{
		// Todas las tablas van a estar almacenadas de manera ordenada en un JSON
		public const string PATCH = "../../Persistencia/jsonDB.json";
		public DataStore store = new DataStore(PATCH);

		public IDocumentCollection<Turno> getDataEntidad()
		{
			IDocumentCollection<Turno> collection = store.GetCollection<Turno>();
			return collection;
		}

		public IEnumerable<Turno> getQueryEntidad()
		{
			IDocumentCollection<Turno> collection = store.GetCollection<Turno>();
			return collection.AsQueryable();
		}
	}

}