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
            string sciezka = "iris.txt";

            try
            {
                var probki = Probka.WczytajBazeDanych(sciezka);

                WynikiAlgorytmu.Items.Clear();

                foreach (var p in probki)
                {
                    WynikiAlgorytmu.Items.Add("Wartoœci: " + string.Join(", ", p.Wartosci) + " Klasa: " + p.Klasa);
                }
            } catch (Exception ex)
            {
                MessageBox.Show("B³¹d podczas wczytywania: " + ex.Message);
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
    }
}
