using System.Collections.Generic;
using Dominio;
using Interfaces;

//https://github.com/ttu/json-flatfile-datastore
using JsonFlatFileDataStore;

namespace Persistencia
{
	//Caso de uso GenerarInformeGerencial{
    public class FinanzaRepositorio :
		IEntidadRepository<IDocumentCollection<Finanza>,IEnumerable<Finanza>>
	{
		// Todas las tablas van a estar almacenadas de manera ordenada en un JSON
		public const string PATCH = "../../Persistencia/jsonDB.json";
		public DataStore store = new DataStore(PATCH);

		// Este es centrado en la manipulacion de elementos individuales
		public IDocumentCollection<Finanza> getDataEntidad()
		{
			IDocumentCollection<Finanza> collection = store.GetCollection<Finanza>();
			return collection;
		}

		// Este esta centrado en el uso de consultas de una entidad
		public IEnumerable<Finanza> getQueryEntidad()
		{
			IDocumentCollection<Finanza> collection = store.GetCollection<Finanza>();
			return collection.AsQueryable();
		}
	}
	//}Caso de uso GenerarInformeGerencial
}