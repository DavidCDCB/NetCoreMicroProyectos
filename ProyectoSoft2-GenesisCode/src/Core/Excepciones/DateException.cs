using System;

namespace Excepciones
{
    //Caso de uso GenerarInformeGerencial{
    [Serializable]
    public class DateException : Exception
    {
        public DateException(string message)
        : base(message) { }
    }
    //}Caso de uso GenerarInformeGerencial
}
