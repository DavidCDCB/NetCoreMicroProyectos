using System;

namespace Excepciones
{
    public class PromocionesException: Exception 
    {
        public PromocionesException(string msg): base(msg)
        {
            Console.WriteLine(msg);
        }
    }
}
