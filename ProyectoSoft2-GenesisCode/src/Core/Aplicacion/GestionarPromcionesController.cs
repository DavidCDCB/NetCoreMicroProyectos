using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using Persistencia;
using Dominio;
using Interfaces;
using System.Globalization;
using Excepciones;
using JsonFlatFileDataStore;

namespace Aplicacion
{
	public class GestionaPromocionesController
	{
		
		public IEntidadRepository<IDocumentCollection<Plato>,IEnumerable<Plato>> repositorioPlato;
		public IEntidadRepository<IDocumentCollection<Promocion>, IEnumerable<Promocion>> repositorioPromocion;

		/***
			Inicializa el repositorio plato.
		*/
		public void setRepositorioPlato(Object repositorioPlato)
		{
			this.repositorioPlato = (PlatoRepositorio) repositorioPlato;
		}

		/***
			Inicializa el repositorio promocion.
		*/
		public void setRepositorioPromocion(Object repositorioPromocion)
		{
			this.repositorioPromocion = (PromocionRepositorio) repositorioPromocion;
		}

		/***
		Obtiene el plato especificado por el id.
		*/
		public Plato GetPlato(string id)
		{
			try
			{
				var collection = repositorioPlato.getQueryEntidad();
				var results = collection.First(x=>x.idplato==id);
				return results;
			}
			catch (Exception)
			{
				return null;
			}
		}

		/***
		Obtiene la promocion especificada por el id.
		*/
		public Promocion GetPromocion(string id)
		{
			try
			{
				var collection = repositorioPromocion.getQueryEntidad();
				var results = collection.First(x=>x.idpromocion==id);
				return results;
			}
			catch (System.InvalidOperationException)
			{
				return null;
			}
		}

		/***
			Obtiene una lista de todos los platos almacenados
		*/
		public IEnumerable<Plato> GetPlatos()
		{		
			var results = repositorioPlato.getQueryEntidad();
			return results;
		}

		/***
			Obtiene una lista de todos las promociones almacenadas
		*/
		public IEnumerable<Promocion> GetPromociones()
		{		
			var results = repositorioPromocion.getQueryEntidad();
			return results;
		}

		/***
			Crea un plato de manera asincronica recibiendo el objeto el plato 
			ademas de validar que el plato no exista por medio del POST de una
			plataforma externa (postman).
		*/
		public async Task<Plato> SetPlatoAsync(Plato plato)
		{
			if (PlatoExistente(plato.idplato))
			{
				try
				{
					IDocumentCollection<Plato> platos = repositorioPlato.getDataEntidad();
					await platos.InsertOneAsync(plato);
					return plato;
				}
				catch (Exception)
				{
					return null;
				}
			}else
			{
				return null;
			}
		}

		/***
			Crea una promocion de manera asincronica recibiendo como parametro un objeto promocion
			en el metodo validamos internamente que no exista una promocion con el mismo id, tambien
			se verifica que la llave foranea corresponda con un plato existente, verificamos que la fecha
			de expiracion sea posterior a la actual ademas de que el valor del descuento sea menor que
			el del valor total del plato. Esto lo realiza por medio del POST.
		*/
		public async Task<Promocion> SetPromocionAsync(Promocion promocion)
		{	
			Plato platoActual = this.GetPlato(promocion.fkIdplato);
			if (platoActual != null && PromocionExistente(promocion.idpromocion))
			{
				if (ValidarPrecioMenorPlato(promocion))
				{
					if (FechaValidaPromocion(ConvertirFecha(promocion.fechaExpiracion)))
					{
						try
						{
							{
								IDocumentCollection<Promocion> promociones = repositorioPromocion.getDataEntidad();
								await promociones.InsertOneAsync(promocion);
								return promocion;
							}
						}
						catch (Exception)
						{
							throw new PromocionesException("Se asignaron parametros inválidos o no procesables en el formato json");
						}
					}else
					{
						throw new PromocionesException("La fecha suministrada es inválida por que es anterior a la fecha actual.");
					}
				}else
				{
					throw new PromocionesException("El valor de descuento suministrado es inválido para este plato");
				}
			}else
			{
				throw new PromocionesException("El plato suministrado no existe ó la promoción ya existe.");
			}
		}


		/*
		Actualiza la promocion suministrada validando que esta exista, ademas de que si se modifica
		el id del plato, este exista.
		*/
		public async Task<Promocion> UpdatePromocion(Promocion promocion)
		{
			Promocion promoActual = this.GetPromocion(promocion.idpromocion);
			Plato platoActual = this.GetPlato(promocion.fkIdplato);

			if(promoActual != null && platoActual != null)
			{
				var collection = repositorioPromocion.getDataEntidad();
				await collection.ReplaceOneAsync(e => e.idpromocion == promocion.idpromocion, promocion);
				return GetPromocion(promocion.idpromocion);
			}
			return null;
		}

		/***
		Elimina la promocion especificado por medio del id en la url
		*/
		public async Task<Promocion> RemovePromocion(string id)
		{
			Promocion actual = this.GetPromocion(id);

			if(actual != null){
				var collection = repositorioPromocion.getDataEntidad();
				await collection.DeleteOneAsync(e => e.idpromocion == id);
			}
			return actual;
		}

		/***
			Convierte la fecha de string a DateTime
		*/
		public DateTime ConvertirFecha(string fecha)
        {
            string format = "MM-dd-yyyy";
            DateTime fechaDateTime = DateTime.ParseExact(fecha, format, CultureInfo.InvariantCulture);
            return fechaDateTime;
        }
	
		/***
			Válida que la fecha suministrada sea posterior a la actual
		*/
		public Boolean FechaValidaPromocion(DateTime fecha)
		{	
			string fechaActualString = DateTime.Today.ToString("MM-dd-yyyy");
			DateTime fechaActual = ConvertirFecha(fechaActualString);

			//El valor de la comparación retorna 0 si es la misma fecha, < 0 si la fecha 1 es menor que la 2 y > 0 si la fecha 1 es mayor que la 2.
			int result = DateTime.Compare(fecha,fechaActual);
			if (result >= 0)
			{
				return true;
			} else 
			{
			return false;
			}
		}

		/***
			Válida que el precio de la promocion sea menor que el del plato
		*/
		public Boolean ValidarPrecioMenorPlato (Promocion promocion)
		{		
			Plato platoActual = this.GetPlato(promocion.fkIdplato);
			if (platoActual.valor > promocion.descuento)
			{
				return true;
			}else
			{
				return false;		
			}
		}

		/***
			Verifica que el plato exista, si existe retorna false, si no existe retorna true
		*/
		private Boolean PlatoExistente(string id)
		{	
			IEnumerable<Plato> platos = GetPlatos();
			foreach (var plato in platos)
			{
				if (plato.idplato == id)
				{
					return false;
				}
			}
			return true;
		}

		/***
			Verifica que la promocion exista, si existe retorna false, si no existe retorna true
		*/
		private Boolean PromocionExistente(string id)
		{	
			IEnumerable<Promocion> promociones = GetPromociones();
			foreach (var promocion in promociones)
			{
				if (promocion.idpromocion == id)
				{
					return false;
				}
			}
			return true;
		}

		/***
			Imprime un objeto para saber que contiene este
		*/
		private void PrintObject(string text, Object obj)
		{
			var options = new JsonSerializerOptions { WriteIndented = true };
			Console.WriteLine(text + "\n" + JsonSerializer.Serialize(obj, options));
 		}
	}

}