using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using static System.Console;
using static System.Math;
/*
https://code.visualstudio.com/docs/setup/linux
dotnet new console
dotnet run
Windows 10 --> dotnet publish -c Release -r win10-x64
Linux --> dotnet publish -c Release -r linux-x64
MacOS --> dotnet publish -c Release -r osx-x64
https://docs.microsoft.com/es-es/dotnet/core/tools/
https://www.youtube.com/watch?v=RWQ-Qm5tJJs&list=PLfkODrpjGnhnrgG1BcLW_XzyhmXTHR3QB&index=14
https://www.youtube.com/watch?v=utRvQ6KpWAU
https://www.youtube.com/watch?v=XzKL94OMDV4&list=PLU8oAlHdN5BmpIQGDSHo5e1r4ZYWQ8m4B&index=45
https://docs.microsoft.com/es-es/dotnet/csharp/programming-guide/interfaces/explicit-interface-implementation
https://github.com/OmniSharp/omnisharp-vscode/issues/2846
https://docs.microsoft.com/es-es/dotnet/api/?view=netcore-3.1&term=list
*/

namespace protoNet
{

	class Program
	{

		private String name { get; set; }
		public Program(String name)
		{
			this.name = name;
		}

		public int met(int dato)
		{
			return dato;
		}

		static void Main(string[] args)
		{
			Puerta p = new Puerta();
			Action<string> print = (n) => Console.WriteLine(n);

			print("Valores iniciales...");
			p.MostrarEstado();

			print("Vamos a abrir...");

			int a = 4;
			int b = 6;

			b = a++;
			Write(++b);
			List<String> lista = new List<string>();

			p.Abrir();
			p.SetAncho(80);
			p.MostrarEstado();


			// El objeto toma la forma segun al elemento al que se le asigna
			C1 p1 = new otroProgram(name: "");
			p1.NAME = "";
			print(p1.getName());

			Ipru p2 = new otroProgram(name: "otroNombre");
			print(p2.getOtroNombre());
		}


	}

	// Interfaz
	interface Ipru
	{
		String getOtroNombre();
	}

	abstract class C1
	{
		// Campo privado de clase
		private String name;

		// Propiedad de clase a partir de campo
		public String NAME
		{
			get => this.name;
			set => this.name = this.validacion(value);
		}

		// Funcion abstracta
		public abstract String concatenar(String text);

		// Contructor de clase
		public C1(String name)
		{
			this.name = name;
		}

		// Funcion para sobreescribir
		public virtual String getName()
		{
			return this.name;
		}

		// Metodo privado
		private String validacion(String name)
		{
			if (name.Equals(""))
			{
				return "Proceso";
			}
			else
			{
				return name;
			}
		}
	}

	// Clase que hereda e implementa
	class otroProgram : C1, Ipru
	{
		// Constructor que asigna el parametro del constructor padre
		public otroProgram(String name) : base(name)
		{
			System.Console.WriteLine("Creado");
			//base.NAME=name;
		}

		// Sobreescritura de metodo abstracto
		public override String getName()
		{
			return this.concatenar(base.getName());
		}

		// Sobreescritura de miembro de interfaz
		String Ipru.getOtroNombre()
		{
			return base.NAME;
		}

		// Implementacion de funcion abstracta
		public override string concatenar(string text)
		{
			return  $"{text} sobreescrito";
		}

	}
}