using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    class Program
    {
        int[] val;

        int suma = 0;
        int con = 0;
        int pro1 = 0;
        int proc = 0;
        int valc = 0;

        int[] may = new int[10];

        public void valores()
        {

            val = new int[10];

            for (int i = 1; i < 10; i++)
            {
                Console.WriteLine("ingrese los valores");
                int valores = int.Parse(Console.ReadLine());

                    val[i] = valores;
                
            }

        }


        public void pro()
        {
            for (int i = 1; i < 10; i++)
            {
                suma = val[i] + suma;
            }

             pro1 = suma / 10;

             Console.WriteLine("el promedio de los valores es:" + pro1);
             
            


            Console.ReadKey();
        }

        public void pro2()
        {

            for (int i = 1; i < 10; i++)
            {
                proc =  val[i];

                if (proc > pro1)
                {

                    con++;

                    may[i] = proc;
     
                      
                }

 
          
            }

            for (int t = 1; t < 10; t++)
            {
                Console.WriteLine("los datos mayores que el promedio son: " + may[t]);
            }   
            Console.WriteLine("la cantidad de valores mayor que el promedio son: " + con);  
        }

   public void ejer2()
   {


       int num = int.Parse(Console.ReadLine());
            int[] ver1 = new int[5];
            for (int i = 0; i < 5; i++)
            {

               int al1 = 0;
               al1 = al1 * num + 3 - 2 ;
               al1 = ver1[i];

            }
            int num2 = int.Parse(Console.ReadLine());
            int[] ver2 = new int[5];
            for (int i = 0; i < 5; i++)
            {
                int al2 = 0;
                al2 =  (num2 + 3 - 2) * al2 ;
                al2 = ver2[i];
                
            }

            int[] ver3 = new int[5];
            int[] vers = new int[5];
            for (int i = 0; i < 5; i++)
            {
                vers[i] = ver2[i] + ver1[i];

            }

             for (int j = 0; j < 5; j++)
                {
                    Console.WriteLine("los numeros sumados son: " + vers[j]);
                }
    }
   public void ejer4()
   {


   }

   static void Main(String[]Args)
   {
       Program p = new Program();
       p.ejer2();
       p.valores();
       p.pro();
       p.pro2();

                     

                 
    
    
    
    

         
     
     


      //ESTE ES EL CODIGO COMPLETADO POR MI

     
     

      /*
      Console.WriteLine("cuantos numeros quieres");
      limite = int.Parse(Console.ReadLine());
            
             //ESTABLECER ARREGLO CON UN LIMITE DETERMINADO POR EL USUARIO
      char[] arreglo = new char[limite];
      Array.Sort<char>(arreglo);
             //ESTABLECER EL CICLO PARA LLENAR CON DATOS ALEATORIOS EL ARREGLO
      for (i = 0; i < limite ; i++)
          {
             Console.WriteLine("Escribe el numero:" + i);
             linea = Console.ReadLine();
             arreglo[i] = char.Parse(linea);
          }


             //METTODO DE ORDENAMIENTO DE BURBUJA: DE MENOR A MAYOR
             //CICLO DE i
      for (i = 0; i < limite ; i++)
         {
          //CICLO DE j
             for (j = i ; j < limite ; j++) ;

          // COMPARACION DE NUMEROS
             if (arreglo[i] > arreglo[j+1])
             {
                 //ORDENAMIENTO DE NUMEROS SEGUN LA CONDICION.
                 aux = arreglo[i];
                 arreglo[j] = arreglo[j+1];
                 arreglo[j+1] = aux;
             }

         }
             //CICLO DE DEMOSTRACION DE DATOS
      for (i = 0; i < limite ; i++)
      {
          //MOSTRAR NUMEROS ORDENADOS
          Console.WriteLine("-" + arreglo[i]);
         
      }
      Console.ReadKey();

             // PROFE ESTAS FUERON LAS DIRECCIONES EN LAS CUALES INVESTIGUE PERO NINGUNA DE ELLAS SON SEMEJANTES, POR TAL RAZON ME TOCO EXTRAER PARTE DE TODAS, PARA FORMAR EL CODIGO.

      /* BIBLIOGRAFIAS:
       http://diagramas-de-flujo.blogspot.com/2013/01/Ordenar-creciente-decreciente-lista-N-numeros-CSharp.html
       http://www.identi.li/index.php?topic=240590
       http://www.youtube.com/watch?v=-XjlHxKsRa0
       http://www.youtube.com/watch?v=H26gZN9DYig
       http://www.portaltips.com/2011/06/ejemplo-c-estructura-metodo-de-ordenamiento-burbuja-simple/
       http://csharp-facilito.blogspot.com/2013/07/metodo-de-ordenamiento-burbuja-en-c-sharp.html

       */
        Console.ReadKey();
 }
    }
}
