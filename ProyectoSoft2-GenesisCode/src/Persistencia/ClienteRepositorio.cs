using System.Collections.Generic;
using Dominio;
using Interfaces;

//https://github.com/ttu/json-flatfile-datastore
using JsonFlatFileDataStore;

namespace Persistencia
{
	//Caso de uso GenerarInformeGerencial{
    public class ClienteRepositorio :
		IEntidadRepository<IDocumentCollection<Cliente>,IEnumerable<Cliente>>
	{
		// Todas las tablas van a estar almacenadas de manera ordenada en un JSON
		public const string PATCH = "../../Persistencia/jsonDB.json";		public DataStore store = new DataStore(PATCH);

		// Este es centrado en la manipulacion de elementos individuales
		public IDocumentCollection<Cliente> getDataEntidad()
		{
			IDocumentCollection<Cliente> collection = store.GetCollection<Cliente>();
			return collection;
		}

		// Este esta centrado en el uso de consultas de una entidad
		public IEnumerable<Cliente> getQueryEntidad()
		{
			IDocumentCollection<Cliente> collection = store.GetCollection<Cliente>();
			return collection.AsQueryable();
		}
	}
	//}Caso de uso GenerarInformeGerencial
}