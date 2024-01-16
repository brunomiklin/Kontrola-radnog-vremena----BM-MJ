using System;
using System.Runtime.CompilerServices;

namespace MyApp
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Zaposlenik zaposlenik1 = new Zaposlenik("Bruno", "Miklin");
            Zaposlenik zaposlenik2 = new Zaposlenik("Niko", "Trstenjak");

            RadnoVrijeme radnoVrijemePromming = new RadnoVrijeme(TimeSpan.Parse("08:00"), TimeSpan.Parse("17:00"));

            Tvrtka Promming = new Tvrtka("Promming", "Cakovec", radnoVrijemePromming);
     

            zaposlenik1.Dolazak =  TimeSpan.Parse("09:30");
            zaposlenik1.Odlazak = TimeSpan.Parse("16:00");

            DodajZaposlenika(Promming, zaposlenik1);
            DodajZaposlenika(Promming, zaposlenik2);

           

            Promming.ispisTvrtke();
            Console.WriteLine("\n");
            zaposlenik1.ProvjeriRadnoVrijeme();

        }

        static void DodajZaposlenika(Tvrtka tvrtka, Zaposlenik zaposlenik)
        {
            if (zaposlenik.trenutnaTvrtka != null)
            {
                Console.WriteLine("Zaposlenik " + zaposlenik.ime + " " + zaposlenik.prezime + " već je zaposlen!");
            }
            else
            {
                Array.Resize(ref tvrtka.Zaposlenici, tvrtka.Zaposlenici.Length + 1);
                tvrtka.Zaposlenici[tvrtka.Zaposlenici.Length - 1] = zaposlenik.ime + " " + zaposlenik.prezime;
                zaposlenik.trenutnaTvrtka = tvrtka; 
            }
        }
    }
    public class RadnoVrijeme
    {
        public TimeSpan Pocetak;
        public TimeSpan Kraj;
    

        public RadnoVrijeme(TimeSpan pocetak, TimeSpan kraj)
        {
            Pocetak = pocetak;
            Kraj = kraj;
        }
    }

    public class Zaposlenik
    {
        public string ime;
        public string prezime;
        public Tvrtka trenutnaTvrtka = null;
        public TimeSpan Dolazak;
        public TimeSpan Odlazak;

        public Zaposlenik(string Ime, string Prezime)
        {
            this.ime = Ime;
            this.prezime = Prezime;
        }
        public bool ProvjeriRadnoVrijeme()
        {
            if (trenutnaTvrtka == null)
            {
                Console.WriteLine("Zaposlenik " + ime + " " + prezime + " nije zaposlen!");
                return false;
            }

            if ((Dolazak >= trenutnaTvrtka.RadnoVrijeme.Pocetak) && (Odlazak <= trenutnaTvrtka.RadnoVrijeme.Kraj))
            {
                Console.WriteLine("Zaposlenik " + ime + " " + prezime + " nalazio se na poslu unutar ranog vremena!");
                return true;
            }
            else
            {
                Console.WriteLine("Zaposlenik " + ime + " " + prezime + " nije bio na poslu unatar radnog vremena!");
                return false;
            }
        }
    }

    public class Tvrtka
    {
        public string naziv;
        public string mjesto;
        public string[] Zaposlenici;
        public RadnoVrijeme RadnoVrijeme;

        public Tvrtka(string Naziv, string Mjesto, RadnoVrijeme radnovrijeme)
        {
            this.naziv = Naziv;
            this.mjesto = Mjesto;
            this.Zaposlenici = new string[0];
            this.RadnoVrijeme = radnovrijeme;
        }
       
        public void ispisTvrtke()
        {
            Console.WriteLine("Zaposlenici u tvrki: " + this.naziv + ", Mjesto: " + this.mjesto);
            foreach (string s in Zaposlenici)
            {
                Console.WriteLine(s);
            }
        }
    }
}
