namespace Excepciones
{
    public class MeseroInactivoException : System.Exception
	{
		public MeseroInactivoException(string msg) : base(msg)
		{
		}
    }
}