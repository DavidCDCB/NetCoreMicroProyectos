using System.Collections.Generic;
using Dominio;
using Interfaces;
using System;
using System.Linq;

//https://github.com/ttu/json-flatfile-datastore
using JsonFlatFileDataStore;

namespace Persistencia
{
    public class RepositorioMeseros : IRepositorio<Mesero, string>
    {
        public const string PATCH = "../../Persistencia/jsonDB.json";
        public DataStore store = new DataStore(PATCH);

        /*
        Adiciona un mesero a la BD
        */
        public Mesero Adicionar(Mesero mesero)
        {
            store.GetCollection("mesero")
                    .InsertOne(mesero);
            return mesero;
        }

        /**
        Verificar si el nombre completo del mesero de una colección concuerda con el nombre ingresado
        */
        public bool VerificarNombre(string n, string a, string nombre) 
        {
            string v = n + " " + a;
            return v.Equals(nombre);
        }
        
        /*
        Busca un mesero en la BD
        */
        public Mesero Buscar(string nombre)
        {
            var mesero = store.GetCollection<Mesero>("mesero")
                                .AsQueryable()
                                .FirstOrDefault(m => VerificarNombre(m.nombre, m.apellido, nombre));
            return mesero;
        }

        /*
        Busca un mesero en la BD por su documento
        */
        public Mesero BuscarPorDocumento(string documento) 
        {
            var mesero = store.GetCollection<Mesero>("mesero")
                                .AsQueryable()
                                .FirstOrDefault(m => m.documento == documento);
            return mesero;
        }

        /*
        Establece el estado un mesero de la BD a inactivo
        */
        public string Eliminar(Mesero mesero)
        {
            mesero.estado = false;
            store.GetCollection<Mesero>("mesero")
                    .UpdateOne(m => m.documento.Equals(mesero.documento), mesero);
            return "Mesero eliminado";
        }

        /*
        Actualiza un mesero en la BD
        */
        public Mesero Actualizar(Mesero mesero)
        {
            store.GetCollection<Mesero>("mesero")
                    .UpdateOne(m => m.documento.Equals(mesero.documento), mesero);
            return BuscarPorDocumento(mesero.documento);
        }
    }
}