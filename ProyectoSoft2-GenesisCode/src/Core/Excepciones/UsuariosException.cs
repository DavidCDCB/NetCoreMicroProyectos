using System;

namespace Excepciones
{
    public class UsuariosException: Exception 
    {
        public UsuariosException(string msg): base(msg)
        {
            Console.WriteLine(msg);
        }
    }
    
}
