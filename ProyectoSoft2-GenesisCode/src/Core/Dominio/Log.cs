using System.ComponentModel.DataAnnotations;

namespace Dominio
{
    public class Log
    {   
        public Log(){}
        [Required(ErrorMessage="El usuario es obligatorio.")]
        public string fkdocumento{get; set;}
        [Required(ErrorMessage=" La contraseña es obligatoria.")]
        public string clave{get;set;}
    }
}