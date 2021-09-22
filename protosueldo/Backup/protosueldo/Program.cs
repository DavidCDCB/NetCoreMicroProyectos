using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace calculosueldo
{
    class Program
    {
        static void Main(string[] args)
        {
                
            //NOMBRE DE VARIABLES "MAIN"
                //numeros enteros 
                int horasTrabajadas;
                // decimales
                float costoHora;
                float sueldo;
                // letras
                string linea;
                
            //ESTABLESER CADENA
                Console.Write("Ingrese horas  : ");
            //IMPRIMIR CADENA CON USUARIO 
                linea = Console.ReadLine();
            //CONVERTIR CADENA A ENTERO 
                horasTrabajadas = int.Parse(linea);

            //ESTABLESER CADENA 2
                Console.Write("Ingrsese el pago por hora");
            //IMPRIMIR CADENA CON USUARIO 
                linea = Console.ReadLine();
            //CONVERTIR CADENA A DECIMAL 
                costoHora = float.Parse(linea);

            //OPERACION CON DATOS
                sueldo = horasTrabajadas * costoHora;
                
            //MENSAGE Y RESULTADO FINAL
                Console.Write("El sueldo total diario es:");
                Console.Write(sueldo);
                Console.ReadKey();
            
            //          FIN
               
            
        }
    }
}