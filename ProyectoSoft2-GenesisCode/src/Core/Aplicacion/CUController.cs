using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using Persistencia;
using Dominio;
using Interfaces;
using System.Linq;

namespace Aplicacion
{
	public class CUController : ICUController
	{
		public PublicacionRepository repo = new PublicacionRepository();

		/*
		Busca un elemento a partir de un id espefificado por url
		GET http://localhost:5000/api/Publicacion/102
		*/
		public Publicacion GetPublicacion(int id)
		{
			try
			{
				var collection = repo.getDataQueryPublicacion();
				var results = collection.First(x=>x.IdPublicacion==id);
				return results;
			}
			catch (System.InvalidOperationException)
			{
				return null;
			}
		}

		/*
		Genera una lista de todos los elementos almacenados
		GET http://localhost:5000/api/Publicacion
		*/
		public IEnumerable<Publicacion> GetPublicaciones()
		{
			var results = repo.getDataQueryPublicacion();
			return results;
		}

		/*
		Almacena una lista de elementos pasada por POST en formato json
		POST http://localhost:5000/api/Publicacion
		*/
		public async Task<IEnumerable<Publicacion>> SetPublicacionAsync(List<Publicacion> publicaciones)
		{
			var collection = repo.getDataPublicacion();
			List<int> ids = repo.getDataQueryPublicacion()
				.Select(x=>x.IdPublicacion)
				.ToList();
			int nId = ids.Max();

			foreach (var item in publicaciones)
			{
				item.IdPublicacion = ++nId;
				await collection.InsertOneAsync(item);
			}
			
			return publicaciones;
		}

		/*
		Actualiza un elemento especificado por id y pasado por json
		PUT http://localhost:5000/api/Publicacion/102
		*/
		public async Task<Publicacion> UpdatePublicacion(Publicacion publicacion)
		{
			Publicacion actual = this.GetPublicacion(publicacion.IdPublicacion);

			if(actual != null){
				var collection = repo.getDataPublicacion();
				await collection.ReplaceOneAsync(e => e.IdPublicacion == publicacion.IdPublicacion,publicacion);
				return GetPublicacion(publicacion.IdPublicacion);
			}
			return null;
		}

		/*
		Elimina un elemento especificado por id en la url
		DELETE http://localhost:5000/api/Publicacion/102
		*/
		public async Task<Publicacion> RemovePublicacion(int id)
		{
			Publicacion actual = this.GetPublicacion(id);

			if(actual != null){
				var collection = repo.getDataPublicacion();
				await collection.DeleteOneAsync(e => e.IdPublicacion == id);
			}
			return actual;
		}
	}

}