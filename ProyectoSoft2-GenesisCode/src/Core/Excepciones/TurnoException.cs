using System;

namespace Excepciones
{
    public class TurnoException: Exception 
    {
        public TurnoException(string msg): base(msg)
        {
            Console.WriteLine(msg);
        }
    }
    
}