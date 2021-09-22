using System;

public class Puerta
{

	private int ancho;     // Ancho en centimetros
	public int alto;      // Alto en centimetros
	public int color;     // Color en formato RGB
	private bool abierta;  // Abierta o cerrada

	public Puerta(){
		this.ancho=0;
		this.alto=0;
		this.color=0;
	}
	
	public void Abrir()
	{
		abierta = true;
	}

	public void Cerrar()
	{
		abierta = false;
	}

	public int GetAncho()
	{
		return ancho;
	}

	public void SetAncho(int nuevoValor)
	{
		ancho = nuevoValor;
	}

	public void MostrarEstado()
	{
		Console.WriteLine("Ancho: {0}", ancho);
		Console.WriteLine("Alto: {0}", alto);
		Console.WriteLine("Color: {0}", color);
		Console.WriteLine("Abierta: {0}", abierta);
	}

} // Final de la clase Puerta 
