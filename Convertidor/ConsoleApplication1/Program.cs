using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            string nombre;
            int nom;
            float a;

            Console.WriteLine("\n***********************************");
            Console.Write("*CONVERTIDOR DE UNIDADES DE TIEMPO*");
            Console.WriteLine("\n***************CDCB****************");
            Console.Write("_________________________________________________________");
            

            Console.Write("\n_1_De minutos a segundos.");
            Console.Write("\n_2_De segundos a minutos.");
            Console.Write("\n_3_De minutos a horas.");
            Console.Write("\n_4_De horas a minutos.");
            Console.Write("\n_5_De segundos a horas.");
            Console.Write("\n_6_De horas a segundos.");
            Console.Write("\n_7_De horas a dias");
            Console.Write("\n_8_De dias a horas");
            Console.Write("\n_9_De minutos a dias");
            Console.Write("\n_10_De dias a segundos");
            Console.Write("\n\nQUE NUMERO DE TIPO DE CONVERSION ELIGES?: ");
            
            nombre = Console.ReadLine();
            nom = int.Parse(nombre);

            if (nom == 1)
            {
                Console.Write("\nQue cantidad de minutos quieres convertir a segundos?: ");
                nom = int.Parse(nombre);


                a = 
            }

            Console.ReadKey();
        }
    }
}
