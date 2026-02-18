using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Torres_de_Hanoi
{
    class Pila
    {

        // 1. Atributos / Propiedades requeridas

        // Representa la cantidad de discos actuales en el palo
        public int Size { get; private set; }

        // Representa el disco que está en la parte superior
        public Disco Top { get; private set; }

        // Estructura que contiene el conjunto de discos
        public List<Disco> Elementos { get; private set; }


        // 2. Métodos obligatorios

        // Constructor que inicializa la pila
        public Pila()
        {
            Elementos = new List<Disco>();
            Size = 0;
            Top = null;
        }

        // Coloca un disco en la parte superior
        public void push(Disco d)
        {
            Elementos.Add(d);
            Size++;
            Top = d;
        }

        // Extrae y devuelve el disco de la parte superior
        public Disco pop()
        {
            if (isEmpty())
                return null;

            Disco discoSuperior = Elementos[Size - 1];
            Elementos.RemoveAt(Size - 1);
            Size--;

            Top = isEmpty() ? null : Elementos[Size - 1];

            return discoSuperior;
        }

        // Devuelve true si la pila no tiene discos
        public bool isEmpty()
        {
            return Size == 0;
        }

    }
}
