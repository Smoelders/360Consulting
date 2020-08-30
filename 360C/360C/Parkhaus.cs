using System;
using System.Threading;

namespace _ParkhausSimulation
{
    /// <summary>
    /// Wir erzeugen die Klasse 'Parkhaus' , diese wird benötigt, um später das Parkhaus-Objekt zu erstellen und beinhaltet Funktionen die wir für unser Programm benötigen.
    /// ParkplaetzeProEtage sowie die Anzahl der Etagen werden wir als Eingabe vom Nutzer eingeben lassen, damit das Parkhaus flexibel getestet werden kann.
    /// </summary>

    public class Parkhaus
    { 
        public int ParkplaetzeProEtage { get; private set; } //Anzahl der Parkplätze auf jeder Etage
        public int Etagen { get; private set; } //Anzahl der Etagen des Parkhauses 
        public int GesammtParkplaetze { get; private set; } //Variable zum Abspeichern der Gesammtanzahl der Parkplätze im Parkhaus
        public int BelegteParkplaetze { get; private set; } //Variable zum Abspeichern der belegten Parkplätze
        public object[,] ArrayFahrzeuge { get; private set; } // Array worin wir unsere Fahrzeuge speichern bzw entfernen
        public Parkhaus(int parkplaetze, int etagen) //Parkhaus Konstruktor
        {
            ParkplaetzeProEtage = parkplaetze;
            Etagen = etagen;
            BelegteParkplaetze = 0;
            GesammtParkplaetze = ParkplaetzeProEtage * Etagen;
            ArrayFahrzeuge = new object[Etagen, ParkplaetzeProEtage];
        }

        public static void NeuEingabe(Parkhaus obj, int parkplaetze, int etagen) //Methode zum Ändern der Parkhaus Dimensionen
        {
            obj.ParkplaetzeProEtage = parkplaetze;
            obj.Etagen = etagen;
            obj.GesammtParkplaetze = obj.Etagen * obj.ParkplaetzeProEtage;
            obj.BelegteParkplaetze = 0;
            obj.ArrayFahrzeuge = new object[obj.Etagen, obj.ParkplaetzeProEtage];

        }
        private bool CheckFahrzeug(Fahrzeuge obj) //Methode um zu kontrollieren ob ein Fahrzeug sich bereits im Parkhaus befindet
        {
            bool check = false;
            for (int column = 0; column < Etagen; column++)
            {
                for (int row = 0; row < ParkplaetzeProEtage; row++)
                {
                    if (ArrayFahrzeuge[column, row] != null)
                    {
                        if (ArrayFahrzeuge[column, row].ToString() == obj.Id)
                        {
                            check = true;
                            Console.WriteLine($"Das {obj.GetType().Name} mit dem Kennzeichen {obj.Id} befindet sich im Parkhaus.\nEtage: {column}\nParkplatznummer: {row} ");
                            Thread.Sleep(2500); // 2.5s damit der Nutzer den Bildschirm lesen kann
                        }
                    }
                }
            }
            return check;
        }
        public void NeuesFahrzeug(Fahrzeuge obj) //Methode zum Parken eines Fahrzeugs im Parkhaus, der Parkplatz wird automatisch zugeteilt
        {
            if (!CheckFahrzeug(obj))
            {
                for (int column = 0; column < Etagen; column++)
                {
                    for (int row = 0; row < ParkplaetzeProEtage; row++)
                    {
                        if (ArrayFahrzeuge[column, row] == null)
                        {
                            ArrayFahrzeuge[column, row] = obj;
                            BelegteParkplaetze += 1;
                            Console.WriteLine($"Das {obj.GetType().Name} mit Kennzeichen {obj.Id} wurde gespeichert!");
                            Console.WriteLine($"Es wurde auf Etage {column}, Parkplatznummer {row + 1} geparkt.");
                            Thread.Sleep(2500); // 2.5s damit der Nutzer den Bildschirm lesen kann
                            column = Etagen;
                            break;
                        }
                    }
                }

            }
            else
            {
                Console.WriteLine($"Das {obj.GetType().Name} mit Kennzeichen {obj.Id} existiert bereits!");
                Thread.Sleep(2500); // 2.5s damit der Nutzer den Bildschirm lesen kann
            }
        }

        public void AlleFahrzeuge(Parkhaus parkhaus) //Methode zum Ausgeben aller sich im Parkhaus befindenden Fahrzeuge, gibt Kennzeichen und Fahrzeugtyp aus
        {
            for (int column = 0; column < parkhaus.Etagen; column++)
            {
                Console.WriteLine($"\nEtage: {column}");
                for (int row = 0; row < parkhaus.ParkplaetzeProEtage; row++)
                {
                    if (row%4 == 0)
                    {
                        if (parkhaus.ArrayFahrzeuge[column, row] != null)
                        {
                            Console.WriteLine($"\tParkplatznummer: {row + 1}\t{parkhaus.ArrayFahrzeuge[column, row].GetType().Name} - {parkhaus.ArrayFahrzeuge[column, row]}\t");
                        }
                        else
                        {
                            Console.WriteLine($"\tParkplatznummer: {row + 1}\tLeerer Parkplatz\t");
                        }
                    }
                    else
                    {
                        if (parkhaus.ArrayFahrzeuge[column, row] != null)
                        {
                            Console.WriteLine($"\tParkplatznummer: {row + 1}\t{parkhaus.ArrayFahrzeuge[column, row].GetType().Name} - {parkhaus.ArrayFahrzeuge[column, row]}\t");
                        }
                        else
                        {
                            Console.WriteLine($"\tParkplatznummer: {row + 1}\tLeerer Parkplatz\t");
                        }
                    }                    
                }

            }
        }


        public void FahrzeugEntfernen(Parkhaus parkhaus, string kennzeichen) //Entfernen eines Fahrzeugs aus dem Parkhaus, das Fahrzeugobjekt wird aus dem Array gelöscht
        {
            for (int column = 0; column < parkhaus.Etagen; column++)
            {
                for (int row = 0; row < parkhaus.ParkplaetzeProEtage; row++)
                {

                    if ((column + 1) * (row + 1) == parkhaus.Etagen * ParkplaetzeProEtage)
                    {
                        Console.WriteLine($"Fahrzeug mit dem Kennzeichen {kennzeichen} wurde nicht gefunden.");
                        Thread.Sleep(2500); // 2.5s damit der Nutzer den Bildschirm lesen kann
                    }
                    else
                    {
                        if (ArrayFahrzeuge[column, row] != null)
                        {


                            if (ArrayFahrzeuge[column, row].ToString() == kennzeichen)
                            {
                                Console.Clear();
                                ArrayFahrzeuge[column, row] = null;
                                BelegteParkplaetze -= 1;
                                Console.WriteLine($"Fahrzeug mit dem Kennzeichen {kennzeichen} wurde Entfernt!");
                                Thread.Sleep(2500); // 2.5s damit der Nutzer den Bildschirm lesen kann
                                column = parkhaus.Etagen;
                                break;
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("Suche Fahrzeug..");
                                Thread.Sleep(500); // 0.5s pro Parkplatz, damit es aussieht als ob das Programm den Parkplatz suchen müsste - Kann entfernt werden
                            }
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Suche Fahrzeug..");
                            Thread.Sleep(500); // 0.5s pro Parkplatz, damit es aussieht als ob das Programm den Parkplatz suchen müsste - Kann entfernt werden
                        }
                    }
                }
            }
        }
        public void FahrzeugSuchen(Parkhaus parkhaus, string kennzeichen) //Methode zum Suchen eines Fahrzeuges im Parkhaus mittels Kennzeichen
        {
            for (int column = 0; column < parkhaus.Etagen; column++)
            {
                for (int row = 0; row < parkhaus.ParkplaetzeProEtage; row++)
                {

                    if ((column + 1) * (row + 1) == parkhaus.Etagen * ParkplaetzeProEtage)
                    {
                        Console.WriteLine($"Fahrzeug mit dem Kennzeichen {kennzeichen} wurde nicht gefunden.");
                        Thread.Sleep(2500);
                    }
                    else
                    {
                        if (ArrayFahrzeuge[column, row] != null)
                        {


                            if (ArrayFahrzeuge[column, row].ToString() == kennzeichen)
                            {
                                Console.Clear();
                                Console.WriteLine($"Fahrzeug mit dem Kennzeichen {kennzeichen} wurde gefunden!");
                                Console.WriteLine($"\nEtage: {column}");
                                Console.WriteLine($"Parkplatznummer: {row + 1}");
                                Console.WriteLine($"{parkhaus.ArrayFahrzeuge[column, row].GetType().Name} - {parkhaus.ArrayFahrzeuge[column, row]}\n");
                                Thread.Sleep(2500);
                                column = parkhaus.Etagen;
                                break;
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("Suche Fahrzeug..");
                                Thread.Sleep(500); // 0.5s pro Parkplatz, damit es aussieht als ob das Programm den Parkplatz suchen müsste - Kann entfernt werden
                            }
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Suche Fahrzeug..");
                            Thread.Sleep(500); // 0.5s pro Parkplatz, damit es aussieht als ob das Programm den Parkplatz suchen müsste - Kann entfernt werden
                        }
                    }
                }
            }
        }
    }
}
