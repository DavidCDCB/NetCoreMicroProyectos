using System.Collections.Generic;
using Dominio;

//https://github.com/ttu/json-flatfile-datastore
using JsonFlatFileDataStore;

namespace Persistencia
{
	public class PublicacionRepository 
	{
		// Todas las tablas van a estar almacenadas de manera ordenada en un JSON
		public const string PATCH = "../../Persistencia/jsonDB.json";
		public DataStore store = new DataStore(PATCH);

		public IDocumentCollection<Publicacion> getDataPublicacion(){
			IDocumentCollection<Publicacion> collection = store.GetCollection<Publicacion>();
			return collection;
		}

		public IEnumerable<Publicacion> getDataQueryPublicacion(){
			IDocumentCollection<Publicacion> collection = store.GetCollection<Publicacion>();
			return collection.AsQueryable();
		}
	}
}