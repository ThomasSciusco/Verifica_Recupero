using System;
using System.Threading;
using Verifica;


namespace Verifica
{

    class Percorso
    {
        public string Nome { get; set; }
        public List<Tappa> Tappe { get; set; }

        public double CalcolaCostoTotale()
        {
            double costoTotale = 0;
            foreach (var tappa in Tappe)
            {
                costoTotale += tappa.CalcolaCosto();
            }
            return costoTotale;
        }

        public int CalcolaTempoTotale()
        {
            int tempoTotale = 0;
            foreach (var tappa in Tappe)
            {
                tempoTotale += tappa.TempoVisita;
            }
            return tempoTotale;
        }
    }

    abstract class Tappa
    {
        public string Descrizione { get; set; }
        public int TempoVisita { get; set; }

        public abstract double CalcolaCosto();
    }

    class TappaStorica : Tappa
    {
        public string Nome { get; set; }
        public string Storia { get; set; }
        public double PrezzoBiglietto { get; set; }

        public override double CalcolaCosto() { return PrezzoBiglietto; }

    }

    class TappaPanoram : Tappa
    {
        public override double CalcolaCosto()
        {
            return 0;
        }
    }

    class Program
    {
        static void Main()
        {
            // Crea un percorso di esempio con tappe
            var percorso = new Percorso
            {
                Nome = "Percorso Storico",
                Tappe = new List<Tappa>
                {
                    new TappaStorica
                    {
                        Nome = "Tappa 1",
                        Descrizione = "Descrizione tappa 1 storica",
                        TempoVisita = 60,
                        PrezzoBiglietto = 10
                    },
                    new TappaStorica
                    {
                        Nome = "Tappa 2",
                        Descrizione = "Descrizione tappa 2 storica",
                        TempoVisita = 90,
                        PrezzoBiglietto = 15
                    }
                }
            };

            // Calcola costo totale e tempo totale del percorso
            double costoTotale = percorso.CalcolaCostoTotale();
            int tempoTotale = percorso.CalcolaTempoTotale();

            Console.WriteLine("Costo totale: $" + costoTotale);
            Console.WriteLine("Tempo totale: " + tempoTotale + " minuti");
        }
    }
}