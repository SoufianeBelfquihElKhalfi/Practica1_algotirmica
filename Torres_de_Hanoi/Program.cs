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

            // hecho manualmente 
            // Crear un arreglo de discos (del más grande al más pequeño)
            Disco[] discos = new Disco[numeroDiscos];
            for (int i = 0; i < numeroDiscos; i++)
            {
                // Los discos más grandes tienen valores mayores
                // Así que el disco de abajo (posición 0) tiene el valor más alto
                discos[i] = new Disco(numeroDiscos - i);
            }

            //Console.WriteLine("\nDiscos creados (del más grande al más pequeño):");
            //foreach (var disco in discos)
            //{
            //    Console.WriteLine($"Disco de tamaño: {disco}");
            //}

            Console.WriteLine("Has seleccionado " + numeroDiscos + " discos");

                

            // Mensaje para elegir método
            Console.Write("Indica I para Iterativo o R para Recursivo... ");

            char metodo = Char.ToUpper(Console.ReadKey().KeyChar);
            Console.WriteLine();

            Console.WriteLine("Has seleccionado el método " + metodo);


            // Keep the console window open in debug mode.
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}
