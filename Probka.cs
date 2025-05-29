using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

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

        public static List<Probka> WczytajBazeDanych(string sciezka)
        {
            List<Probka> probki = new List<Probka>();
            foreach (var linia in File.ReadLines(sciezka))
            {
                var wiersz = linia.Split(' ');
                if (wiersz.Length != 5)
                {
                    continue;
                }

                var parametry = new double[4];

                for (int i = 0; i < 4; i++)
                {
                    parametry[i] = double.Parse(wiersz[i], CultureInfo.InvariantCulture);
                }

                var klasa = int.Parse(wiersz[4]);
                probki.Add(new Probka(parametry, klasa));
            }
            return probki;
        }
    }
}

