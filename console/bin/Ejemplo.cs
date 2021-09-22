//mcs Ejemplo.cs Puerta.cs -out:ejemploPuerta.exe;mono ejemploPuerta.exe
 
using System;
 
public class Ejemplo_06_03a
{
 
    public static void Main()
    {
        Puerta p = new Puerta();
 
        Console.WriteLine("Valores iniciales...");
        p.MostrarEstado();
 
        Console.WriteLine();
 
        Console.WriteLine("Vamos a abrir...");
        p.Abrir();
        p.SetAncho(80);
        p.MostrarEstado();
    }
	
	public void ej()
	{
		
	}
 
} 
