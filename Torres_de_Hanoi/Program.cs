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

            Pila torreInicial = new Pila();
            Pila torreFinal = new Pila();
            Pila torreAuxiliar = new Pila();
            Hanoi juego = new Hanoi();
            int movimientos = 0;

            // 1. Mensaje de bienvenida
            Console.WriteLine("El Gran Juego de las Torres de Hanoi");
            Console.WriteLine("Este juego se juega con 3 torres");
            Console.WriteLine();

            // 2. Input de Discos
            Console.Write("Indica el número de discos... ");

            int numeroDiscos;
            numeroDiscos = int.Parse(Console.ReadLine());

            Console.WriteLine("\nPreparando discos...");
            for (int i = numeroDiscos; i >= 1; i--)
            {
                Disco disco = new Disco(i);
                torreInicial.push(disco);
                Console.WriteLine($"Disco de tamaño {i} agregado a la torre inicial");
            }

            Console.WriteLine("Has seleccionado " + numeroDiscos + " discos");



            // Mensaje para elegir método
            Console.Write("Indica I para Iterativo o R para Recursivo... ");

            char metodo = Char.ToUpper(Console.ReadKey().KeyChar);
            Console.WriteLine();

            Console.WriteLine("Has seleccionado el método " + metodo);


           

            if (metodo == 'I')
            {
                Console.WriteLine("Ejecutando método Iterativo...");
                movimientos = juego.iterativo(numeroDiscos, torreInicial, torreFinal, torreAuxiliar);
            }
            else if (metodo == 'R')
            {
                Console.WriteLine("Ejecutando método Recursivo...");
                movimientos = juego.recursivo(numeroDiscos, torreInicial, torreFinal, torreAuxiliar);
            }
            else
            {
                Console.WriteLine("Opción no válida. Por favor, selecciona I o R.");
            }
        }
    }
}
