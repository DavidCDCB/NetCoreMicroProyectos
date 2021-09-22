using System;
namespace DTO
{
    public class PlatoDto{

        public PlatoDto(string nombre , double valor)
        {
            this.nombre = nombre;
            this.valor = valor;
        }
        public string nombre { get; set; }
        public double valor { get; set; }
    }

}
