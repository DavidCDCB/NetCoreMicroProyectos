using System.Collections.Generic;
using Dominio;
using Interfaces;
using JsonFlatFileDataStore;

namespace Persistencia
{
    public class LogRepositorio :IEntidadRepository<IDocumentCollection<Log>,IEnumerable<Log>>
    {
        	// Todas las tablas van a estar almacenadas de manera ordenada en un JSON
		public const string PATCH = "../../Persistencia/jsonDB.json";
		public DataStore store = new DataStore(PATCH);

		// Este es centrado en la manipulacion de elementos individuales
		public IDocumentCollection<Log> getDataEntidad()
		{
			IDocumentCollection<Log> collection = store.GetCollection<Log>();
			return collection;
		}

		// Este esta centrado en el uso de consultas de una entidad
		public IEnumerable<Log> getQueryEntidad()
		{
			IDocumentCollection<Log> collection = store.GetCollection<Log>();
			return collection.AsQueryable();
		}
    }
}