using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Knn_algorithm
{
    internal class Probka
    {
        public double[] Wartosci;
        public int Klasa;

        public Probka(double[] wartosci, int klasa)
        {
            Wartosci = wartosci;
            Klasa = klasa;
        }
    }
}
