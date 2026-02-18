using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Torres_de_Hanoi
{
    class Disco
    {
        public int Valor { get; }

        public Disco(int valor)
        {
            if (valor <= 0)
                throw new ArgumentOutOfRangeException(nameof(valor), "El disco debe tener tamaño > 0.");
            Valor = valor;
        }

        public bool PuedeColocarseEncimaDe(int topDestino)
        {
            return topDestino == 0 || Valor < topDestino;
        }

        public override string ToString() => Valor.ToString();
    }
}

