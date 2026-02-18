using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Torres_de_Hanoi
{
    class Program
    {
        static void Main(string[] args)
        {
            
                // 1. Mensaje de bienvenida
                Console.WriteLine("El Gran Juego de las Torres de Hanoi");
                Console.WriteLine("Este juego se juega con 3 torres");
                Console.WriteLine();

                // 2. Input de Discos
                Console.Write("Indica el número de discos... ");

                int numeroDiscos;
                numeroDiscos = int.Parse(Console.ReadLine());

                Console.WriteLine("Has seleccionado " + numeroDiscos + " discos");

                Console.ReadLine(); // Pausa opcional
            

            // Keep the console window open in debug mode.
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}
