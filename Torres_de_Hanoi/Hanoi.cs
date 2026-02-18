using System;
using System.Collections.Generic;
using System.Linq;

namespace Torres_de_Hanoi
{
    class Hanoi
    {
        private Dictionary<Pila, string> _nombre;
        private Pila _ini, _fin, _aux;
        private int _n;
        private int _movimientos;

        // ------------------------------------------------------
        // 1) Mover un disco entre dos palos (elige el movimiento)
        // ------------------------------------------------------
        public void mover_disco(Pila a, Pila b)
        {
            // Si ambos vacíos, no hay nada que hacer
            if (a.isEmpty() && b.isEmpty())
                return;

            // Determinar el movimiento legal (siempre hay como máximo 1)
            Pila origen = null;
            Pila destino = null;

            if (a.isEmpty())
            {
                origen = b;
                destino = a;
            }
            else if (b.isEmpty())
            {
                origen = a;
                destino = b;
            }
            else
            {
                // Ambos tienen discos. Solo puede moverse el más pequeño encima del más grande.
                // Usamos la lógica de Disco.PuedeColocarseEncimaDe(...)
                int topA = a.Top.Valor;
                int topB = b.Top.Valor;

                if (a.Top.PuedeColocarseEncimaDe(topB))
                {
                    origen = a;
                    destino = b;
                }
                else if (b.Top.PuedeColocarseEncimaDe(topA))
                {
                    origen = b;
                    destino = a;
                }
                else
                {
                    // Este caso no debería ocurrir en Hanoi correcto
                    return;
                }
            }

            // Ejecutar movimiento (siempre será legal según lo anterior)
            Disco d = origen.pop();
            destino.push(d);

            _movimientos++;
            Console.WriteLine($"Movimiento {_movimientos}: {_nombre[origen]} -> {_nombre[destino]} (disco {d.Valor})");
            ImprimirEstado();
        }

        // ------------------------------------------------------
        // 2) Iterativo mínimo según paridad (pseudocódigo dado)
        // ------------------------------------------------------
        public int iterativo(int n, Pila ini, Pila fin, Pila aux)
        {
            PrepararContexto(n, ini, fin, aux);

            Console.WriteLine("=== Estado inicial (iterativo) ===");
            ImprimirEstado();

            while (fin.Size != n)
            {
                if (n % 2 == 1)
                {
                    mover_disco(ini, fin);
                    if (fin.Size == n) break;

                    mover_disco(ini, aux);
                    if (fin.Size == n) break;

                    mover_disco(aux, fin);
                }
                else
                {
                    mover_disco(ini, aux);
                    if (fin.Size == n) break;

                    mover_disco(ini, fin);
                    if (fin.Size == n) break;

                    mover_disco(aux, fin);
                }
            }

            return _movimientos;
        }

        // ------------------------------------------------------
        // 3) Recursivo mínimo (clásico)
        // ------------------------------------------------------
        public int recursivo(int n, Pila ini, Pila fin, Pila aux)
        {
            PrepararContexto(n, ini, fin, aux);

            Console.WriteLine("=== Estado inicial (recursivo) ===");
            ImprimirEstado();

            ResolverRec(n, ini, fin, aux);

            return _movimientos;
        }

        private void ResolverRec(int n, Pila origen, Pila destino, Pila auxiliar)
        {
            if (n <= 0) return;

            // 1) mover n-1 de origen -> auxiliar
            ResolverRec(n - 1, origen, auxiliar, destino);

            // 2) mover 1 de origen -> destino (movimiento dirigido)
            mover_disco_dirigido(origen, destino);

            // 3) mover n-1 de auxiliar -> destino
            ResolverRec(n - 1, auxiliar, destino, origen);
        }

        // Movimiento dirigido (origen -> destino) para recursivo
        private void mover_disco_dirigido(Pila origen, Pila destino)
        {
            if (origen.isEmpty())
                return;

            int topDestino = destino.isEmpty() ? 0 : destino.Top.Valor;

            // Si no es legal, no hacemos nada (en recursivo correcto siempre será legal)
            if (!origen.Top.PuedeColocarseEncimaDe(topDestino))
                return;

            Disco d = origen.pop();
            destino.push(d);

            _movimientos++;
            Console.WriteLine($"Movimiento {_movimientos}: {_nombre[origen]} -> {_nombre[destino]} (disco {d.Valor})");
            ImprimirEstado();
        }

        // ------------------------------------------------------
        // Helpers: contexto + impresión
        // ------------------------------------------------------
        private void PrepararContexto(int n, Pila ini, Pila fin, Pila aux)
        {
            _n = n;
            _ini = ini;
            _fin = fin;
            _aux = aux;
            _movimientos = 0;

            _nombre = new Dictionary<Pila, string>
            {
                { ini, "INI" },
                { aux, "AUX" },
                { fin, "FIN" }
            };
        }

        private void ImprimirEstado()
        {
            Console.WriteLine($"INI: {FormatearPila(_ini)}");
            Console.WriteLine($"AUX: {FormatearPila(_aux)}");
            Console.WriteLine($"FIN: {FormatearPila(_fin)}");
            Console.WriteLine();
        }

        private string FormatearPila(Pila p)
        {
            if (p.isEmpty())
                return "[] (Top=0, Size=0)";

            // Elementos está en orden: [abajo, ..., arriba]
            string contenido = string.Join(",", p.Elementos.Select(d => d.Valor));
            return $"[{contenido}] (Top={p.Top.Valor}, Size={p.Size})";
        }
    }
}
