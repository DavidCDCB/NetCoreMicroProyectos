using System;

namespace script
{
    class Program
    {
		public static String title=@"
 __           _       _       ___ _ _  
/ _\ ___ _ __(_)_ __ | |_    / _ (_) |_ 
\ \ / __| '__| | '_ \| __|  / /_\/ | __|
_\ \ (__| |  | | |_) | |_  / /_)\| | |_  
\__/\___|_|  |_| .__/ \__| \____/|_|\__|
               |_|        
		";

		public static String text=@"
[0] Establecer usuario
[1] Clonar proyecto
[2] Crear cambio
[3] Comparar Ramas
[4] Fusionar Rama
[5] Ver historial y estado
[6] Subir rama local
[7] Ir a Commit o Rama
[8] Crear rama
[9] Deshacer ultimo commit
		";

        static void Main(string[] args)
        {
            Console.WriteLine(title);
        }
    }
}
