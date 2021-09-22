using System;
namespace Excepciones
{
    [Serializable]
    public class PlatoException : Exception
    {
        public PlatoException(string message)
        : base(message) { }
    }
}