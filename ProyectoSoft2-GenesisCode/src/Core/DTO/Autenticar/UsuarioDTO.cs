using System;
namespace DTO
{
    public class UsuarioDto{

        public UsuarioDto(string nombre , string apellido)
        {
            this.nombre = nombre;
            this.apellido = apellido;
        }
        public string nombre { get; set; }
        public string apellido { get; set; }
    }
}
