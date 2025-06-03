namespace Knn_algorithm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void buttonGenerujProbki_Click(object sender, EventArgs e)
        {
            string sciezka = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "iris.txt");

            try
            {
                var probki = Probka.WczytajBazeDanych(sciezka);
                Normalizacja(probki);

                WynikiAlgorytmu.Items.Clear();

                if (!int.TryParse(textBoxParametrK.Text, out int k))
                {
                    MessageBox.Show("Nieprawid³owy parametr k!", "B³¹d", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                Metryka wybranaMetryka;

                switch (comboBoxMetryka.SelectedItem?.ToString())
                {
                    case "Euklidesowa":
                        wybranaMetryka = Euklidesowa;
                        break;
                    case "Manhattan":
                        wybranaMetryka = Manhattan;
                        break;
                    case "Czebyszewa":
                        wybranaMetryka = Czebyszew;
                        break;
                    case "Minkowski":
                        if (!int.TryParse(textBoxParametrP.Text, out int p))
                {
                    MessageBox.Show("Nieprawid³owy parametr p!", "B³¹d", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                        wybranaMetryka = (a, b) => Minkowski(a, b, p);
                        break;
                    case "Z logarytmem":
                        wybranaMetryka = zLogarytmem;
                        break;
                    default:
                        MessageBox.Show("Wybierz metrykê!");
                        return;

                }

                double dokladnosc = Test1KontraReszta(probki, k, wybranaMetryka);
                WynikiAlgorytmu.Items.Add("Dok³adnoœæ klasyfikacji (1 kontra reszta): " + Math.Round(dokladnosc,2) + "%");
            }
            catch (Exception ex)
            {
                MessageBox.Show("B³¹d podczas wczytywania: " + ex.Message);
            }
        }

        public static void Normalizacja(List<Probka> probki)
        {
            int liczbaWartosci = probki[0].Wartosci.Length;
            double[] minWartosc = new double[liczbaWartosci];
            double[] maxWartosc = new double[liczbaWartosci];

            for (int i = 0; i < liczbaWartosci; i++)
            {
                minWartosc[i] = probki[0].Wartosci[i];
                maxWartosc[i] = probki[0].Wartosci[i];
            }

            foreach (var p in probki)
            {
                for (int i = 0; i < liczbaWartosci; i++)
                {
                    if (p.Wartosci[i] < minWartosc[i])
                    {
                        minWartosc[i] = p.Wartosci[i];
                    }
                    if (p.Wartosci[i] > maxWartosc[i])
                    {
                        maxWartosc[i] = p.Wartosci[i];
                    }
                }
            }
            foreach (var p in probki)
            {
                for (int i = 0; i < liczbaWartosci; i++)
                {
                    p.Wartosci[i] = (p.Wartosci[i] - minWartosc[i]) / (maxWartosc[i] - minWartosc[i]);
                }
            }
        }

        public delegate double Metryka(double[] A, double[] B);

        static double Euklidesowa(double[] A, double[] B)
        {
            double wynik = 0;
            for (int i = 0; i < A.Length; i++)
            {
                wynik += (A[i] - B[i]) * (A[i] - B[i]);
            }
            return Math.Sqrt(wynik);
        }

        static double Manhattan(double[] A, double[] B)
        {
            double wynik = 0;
            for (int i = 0; i < A.Length; i++)
            {
                wynik += Math.Abs(A[i] - B[i]);
            }
            return wynik;
        }

        static double Czebyszew(double[] A, double[] B)
        {
            double[] wyniki = new double[A.Length];
            for (int i = 0; i < A.Length; i++)
            {
                wyniki[i] = Math.Abs(A[i] - B[i]);
            }
            double wynikMax = wyniki[0];
            for (int i = 1; i < wyniki.Length; i++)
            {
                if (wyniki[i] > wynikMax)
                {
                    wynikMax = wyniki[i];
                }
            }
            return wynikMax;
        }

        static double Minkowski(double[] A, double[] B, double p)
        {
            double wynik = 0;
            for (int i = 0; i < A.Length; i++)
            {
                wynik += Math.Pow(Math.Abs(A[i] - B[i]), p);
            }
            wynik = Math.Pow(wynik, 1.0 / p);
            return wynik;
        }

        static double zLogarytmem(double[] A, double[] B)
        {
            double wynik = 0;
            for (int i = 0; i < A.Length; i++)
            {
                wynik += Math.Abs(Math.Log10(A[i]) - Math.Log10(B[i]));
            }
            return wynik;
        }

        public int KnnKlasyfikuj(Probka testowa, List<Probka> uczace, int k, Metryka metryka)
        {
            List<SasiedniaProbka> sasiedzi = new List<SasiedniaProbka>();

            for (int i = 0; i < uczace.Count; i++)
            {
                double odleglosc = metryka(testowa.Wartosci, uczace[i].Wartosci);
                sasiedzi.Add(new SasiedniaProbka(odleglosc, uczace[i].Klasa));
            }

            for (int i = 0; i < sasiedzi.Count - 1; i++)
            {
                for (int j = i + 1; j < sasiedzi.Count; j++)
                {
                    if (sasiedzi[j].Odleglosc < sasiedzi[i].Odleglosc)
                    {
                        SasiedniaProbka temp = sasiedzi[i];
                        sasiedzi[i] = sasiedzi[j];
                        sasiedzi[j] = temp;
                    }
                }
            }

            int[] licznikKlas = new int[4];

            for (int i = 0; i < k; i++)
            {
                int klasa = sasiedzi[i].Klasa;
                licznikKlas[klasa]++;
            }

            int najczestszaKlasa = 0;
            int maxLiczba = licznikKlas[0];
            bool remis = false;

            for (int i = 1; i < licznikKlas.Length; i++)
            {
                if (licznikKlas[i] > maxLiczba)
                {
                    maxLiczba = licznikKlas[i];
                    najczestszaKlasa = i;
                    remis = false;
                }
                else if (licznikKlas[i] == maxLiczba)
                {
                    remis = true;
                }
            }

            if (remis)
            {
                return -1;
            }
            else
            {
                return najczestszaKlasa;
            }
        }

        public double Test1KontraReszta(List<Probka> probki, int k, Metryka metryka)
        {
            int poprawne = 0;
            int liczbaProb = probki.Count;

            for (int walid_nr = 0; walid_nr < liczbaProb; walid_nr++)
            {
                Probka testowa = probki[walid_nr];
                List<Probka> uczace = new List<Probka>();

                for (int i = 0; i < liczbaProb; i++)
                {
                    if (i != walid_nr)
                    {
                        uczace.Add(probki[i]);
                    }
                }

                int przewidzianaKlasa = KnnKlasyfikuj(testowa, uczace, k, metryka);

                if (przewidzianaKlasa == testowa.Klasa)
                {
                    poprawne++;
                }

                WynikiAlgorytmu.Items.Add("Klasa próbki " + (walid_nr + 1) + ": " + testowa.Klasa + " | Przewidziana klasa: " + przewidzianaKlasa);
            }

            double dokladnosc = (double)poprawne / liczbaProb * 100.0;
            return dokladnosc;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
    
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
