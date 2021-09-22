using System;

namespace Excepciones
{
    public class MeseroException: Exception 
    {
        public MeseroException(string msg): base(msg)
        {
            Console.WriteLine(msg);
        }
    }
    
}