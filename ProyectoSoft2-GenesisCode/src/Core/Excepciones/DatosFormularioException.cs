using System;
namespace Excepciones{


    public class DatosFormularioException: Exception
    {
        public DatosFormularioException (string msg): base( msg) {
            {
                Console.WriteLine(msg);
            }
        }
    }
}