using System;
using System.Threading;

namespace _ParkhausSimulation
{
    class Program
    {
        static void Main(string[] args)
        {
            string key; //Hilfsvariablen für die Eingabe            
            int anzahl1; //Hilfsvariablen für die Eingabe
            int anzahl2; //Hilfsvariablen für die Eingabe
            Console.WriteLine("Willkommen beim Parkhaus Simulationsprogramm.\n\nDrücken Sie eine Taste um fortzufahren."); //Ausgabe für den Nutzer
            Console.ReadKey(); //Bestätigung abwarten
            Console.Clear(); //Bildschirm löschen 

            Console.WriteLine("Bitte geben Sie die Anzahl der Etagen für diese Simulation ein."); //Ausgabe für den Nutzer
            string eingabe1 = Console.ReadLine(); //Eingabe wird in Hilfsvariable gespeichert
            while (!int.TryParse(eingabe1, out anzahl1)) //While Schleife, diese läuft bis die Eingabe eine Zahl ist
            {
                Console.WriteLine($"\n{eingabe1} ist keine Zahl\n"); //Ausgabe für den Nutzer
                Console.WriteLine("Bitte geben Sie die Anzahl der Etagen für diese Simulation ein."); //Ausgabe für den Nutzer
                eingabe1 = Console.ReadLine(); //Eingabe wird in Hilfsvariable gespeichert
            }

            Console.Clear(); //Bildschirm löschen 
            Console.WriteLine("Bitte geben Sie die Anzahl der Parkplätze pro Etage für diese Simulation ein."); //Ausgabe für den Nutzer
            string eingabe2 = Console.ReadLine(); //Eingabe wird in Hilfsvariable gespeichert
            while (!int.TryParse(eingabe2, out anzahl2)) //While Schleife, diese läuft bis die Eingabe eine Zahl ist
            {
                Console.WriteLine($"\n{eingabe2} ist keine Zahl\n"); //Ausgabe für den Nutzer
                Console.WriteLine("Bitte geben Sie die Anzahl der Etagen für diese Simulation ein."); //Ausgabe für den Nutzer
                eingabe2 = Console.ReadLine(); //Eingabe wird in Hilfsvariable gespeichert
            }
            Parkhaus parkhaus1 = new Parkhaus(anzahl2, anzahl1); // Neues Parkhaus Objekt wird erstellt
            Console.Clear(); // Kombination aus Clear + WriteLine(menuAuswahlEins) löscht den Bildschirm und schreibt das Optionsmenu neu

            const string menuAuswahlEins = "Bitte wählen Sie aus den folgenden Optionen:\n\n1 - Fahrzeug Hinzufügen \n2 - Fahrzeug Entfernen \n3 - Fahrzeug Suchen \n4 - Anzahl freier Parkplätze  \n5 - Komplette Auflistung \n6 - Simulation neustarten\n7 - Programm Beenden"; //Menu wird in eine Konstante gespeichert, es wird mehrfach aufgerufen
            Console.WriteLine(menuAuswahlEins); //Ausgabe für den Nutzer

            while ((key = Console.ReadKey().KeyChar.ToString()) != "7") //While Schleife, diese läuft bis die Eingabe 7 ist
            {
                int.TryParse(key, out int keyValue); // Eingabe wird von Char (Key) in Int geparsed 
                ProcessInput(keyValue, parkhaus1, menuAuswahlEins); //Methode mit Switchcase (unten) wird aufgerufen, mit Übergabe von Eingabe (als Integer) , Parkhausobjekt und der Menu-Konstante
            }
        }
        private static void ProcessInput(int keyValue, Parkhaus obj, string menuAuswahlEins) // Methode mit Switchcase
        {
            int keyValue2;
            string key; //Hilfsvariablen für die Eingabe
            string kennzeichenEingabe; //Hilfsvariablen für die Eingabe
            switch (keyValue) // Switchcase für das Auswahlmenu, hiermit entscheidet der Nutzer was weiter passieren soll
            {
                case 1:
                    Console.Clear(); //Bildschirm löschen
                    const string menuAuswahlZwei = "Bitte wählen Sie aus den folgenden Optionen:\n\n1 - Neues Auto hinzufügen\n2 - Neues Motorrad hinzufügen\n3 - Zurück"; //Menu wird in eine Konstante gespeichert, es wird mehrfach aufgerufen
                    Console.WriteLine(menuAuswahlZwei); //Ausgabe für den Nutzer
                    while ((key = Console.ReadKey().KeyChar.ToString()) != "3") //While Schleife, diese läuft bis die Eingabe 3 ist
                    {
                        int.TryParse(key, out keyValue2); // Eingabe wird von Char (Key) in Int geparsed 
                        switch (keyValue2) // Switchcase für das Auswahlmenu, hiermit entscheidet der Nutzer was weiter passieren soll
                        {
                            case 1:
                                Console.Clear(); //Bildschirm löschen
                                if (obj.GesammtParkplaetze == obj.BelegteParkplaetze) // Kurze Kontrolle vor dem Aufruf, damit keine Daten eingegeben werden müssen, wenn das Parkhaus schon voll wäre
                                {
                                    Console.WriteLine("Alle Parkplätze belegt!"); //Ausgabe für den Nutzer
                                    Thread.Sleep(2500); //2.5s damit der Nutzer die Ausgabe lesen kann
                                    Console.Clear(); // Kombination aus Clear + WriteLine(menuAuswahlEins) löscht den Bildschirm und schreibt das Optionsmenu neu
                                    Console.WriteLine(menuAuswahlEins);
                                    return; 
                                }
                                else
                                {
                                    Console.WriteLine("Bitte geben Sie das Kennzeichen des neuen Autos ein."); //Ausgabe für den Nutzer
                                    kennzeichenEingabe = Console.ReadLine(); //Eingabe wird in Hilfsvariable gespeichert
                                    if ((kennzeichenEingabe.Length > 9) || (kennzeichenEingabe.Length < 3)) //Kennzeichen wird auf 3 bis 9 Zeichen begrenzt
                                    {
                                        Console.WriteLine("Ungültiges Kennzeichen."); //Ausgabe für den Nutzer
                                        Thread.Sleep(2500); //2.5s damit der Nutzer die Ausgabe lesen kann
                                    }
                                    else
                                    {
                                        obj.NeuesFahrzeug(new Auto(kennzeichenEingabe)); //Erstellen eines neuen Auto-Objekts
                                    }
                                    Console.Clear(); // Kombination aus Clear + WriteLine(menuAuswahlZwei) löscht den Bildschirm und schreibt das Optionsmenu neu
                                    Console.WriteLine(menuAuswahlZwei);
                                    break; //Case Ende
                                }
                            case 2:
                                Console.Clear(); //Bildschirm löschen
                                if (obj.GesammtParkplaetze == obj.BelegteParkplaetze) // Kurze Kontrolle vor dem Aufruf, damit keine Daten eingegeben werden müssen, wenn das Parkhaus schon voll wäre
                                {
                                    Console.WriteLine("Alle Parkplätze belegt!"); //Ausgabe für den Nutzer
                                    Thread.Sleep(2500); //2.5s damit der Nutzer die Ausgabe lesen kann
                                    Console.Clear(); // Kombination aus Clear + WriteLine(menuAuswahlEins) löscht den Bildschirm und schreibt das Optionsmenu neu
                                    Console.WriteLine(menuAuswahlEins); 
                                    return;
                                }
                                else
                                {
                                    Console.WriteLine("Bitte geben Sie das Kennzeichen des neuen Motorrads ein."); //Ausgabe für den Nutzer
                                    kennzeichenEingabe = Console.ReadLine(); //Eingabe wird in Hilfsvariable gespeichert
                                    if ((kennzeichenEingabe.Length > 9) || (kennzeichenEingabe.Length < 3)) //Kennzeichen wird auf 3 bis 9 Zeichen begrenzt
                                    {
                                        Console.WriteLine("Ungültiges Kennzeichen."); //Ausgabe für den Nutzer
                                        Thread.Sleep(2500); //2.5s damit der Nutzer die Ausgabe lesen kann
                                    }
                                    else
                                    {
                                        obj.NeuesFahrzeug(new Motorrad(kennzeichenEingabe)); //Erstellen eines neuen Motorrad-Objekts
                                    }
                                    Console.Clear(); // Kombination aus Clear + WriteLine(menuAuswahlZwei) löscht den Bildschirm und schreibt das Optionsmenü neu
                                    Console.WriteLine(menuAuswahlZwei); 
                                    break; //Case Ende
                                }
                        }

                    }
                    Console.Clear(); //Bildschirm löschen
                    Console.WriteLine(menuAuswahlEins); //Ausgabe für den Nutzer
                    break; //Case Ende

                case 2:
                    const string menuAuswahlDrei = "Bitte wählen Sie aus den folgenden Optionen:\n\n1 - Fahrzeug entfernen\n2 - Zurück"; //Menü wird in eine Konstante gespeichert, es wird mehrfach aufgerufen
                    Console.Clear(); // Kombination aus Clear + WriteLine(menuAuswahlZwei) löscht den Bildschirm und schreibt das Optionsmenü neu                   
                    Console.WriteLine(menuAuswahlDrei); 

                    while ((key = Console.ReadKey().KeyChar.ToString()) != "2") //While Schleife, diese läuft bis die Eingabe 2 ist
                    {
                        int.TryParse(key, out keyValue2); // Eingabe wird von Char (Key) in Int geparsed  
                        switch (keyValue2) // Switchcase für das Auswahlmenü, hiermit entscheidet der Nutzer was weiter passieren soll
                        {
                            case 1:
                                Console.Clear(); //Bildschirm löschen
                                Console.WriteLine("Bitte geben Sie das Kennzeichen des Fahrzeugs ein, das Sie entfernen wollen."); //Ausgabe für den Nutzer
                                kennzeichenEingabe = Console.ReadLine(); //Eingabe wird in Hilfsvariable gespeichert
                                if ((kennzeichenEingabe.Length > 9) || (kennzeichenEingabe.Length < 3)) //Kennzeichen wird auf 3 bis 9 Zeichen begrenzt
                                {
                                    Console.WriteLine("Ungültiges Kennzeichen.");  //Ausgabe für den Nutzer
                                    Thread.Sleep(2500); //2.5s damit der Nutzer die Ausgabe lesen kann
                                }
                                else
                                {
                                    obj.FahrzeugEntfernen(obj, kennzeichenEingabe); // Methode um das Fahrzeug aus dem Array zu entfernen
                                }
                                Console.Clear(); // Kombination aus Clear + WriteLine(menuAuswahlDrei) löscht den Bildschirm und schreibt das Optionsmenü neu
                                Console.WriteLine(menuAuswahlDrei);
                                break; //Case Ende
                        }
                    }
                    Console.Clear(); // Kombination aus Clear + WriteLine(menuAuswahlEins) löscht den Bildschirm und schreibt das Optionsmenü neu
                    Console.WriteLine(menuAuswahlEins);
                    break; //Case Ende

                case 3:
                    const string menuAuswahlVier = "Bitte wählen Sie aus den folgenden Optionen:\n\n1 - Fahrzeug suchen\n2 - Zurück";
                    Console.Clear(); // Kombination aus Clear + WriteLine(menuAuswahlVier) löscht den Bildschirm und schreibt das Optionsmenü neu
                    Console.WriteLine(menuAuswahlVier);

                    while ((key = Console.ReadKey().KeyChar.ToString()) != "2") //Schleife die aufgerufen wird, bis die Eingabe 2 ist - Die Eingabe wird sofort von Char auf String konvertiert
                    {
                        int.TryParse(key, out keyValue2); // String wird in Int konvertiert
                        switch (keyValue2) //Switchcase für Auswahlmenü, keyValue3 ist die Nutzereingabe von Char zu String zu Int konvertiert
                        {
                            case 1:
                                Console.Clear();  //Bildschirm löschen
                                Console.WriteLine("Bitte geben Sie das Kennzeichen des Fahrzeugs ein, das Sie suchen wollen."); //Ausgabe für den Nutzer
                                kennzeichenEingabe = Console.ReadLine(); // Eingabe wird in Hilfsvariable C gespeichert
                                if ((kennzeichenEingabe.Length > 9) || (kennzeichenEingabe.Length < 3)) // Kontrolle ob die Eingabe größer 9 oder kleiner 3 ist , begrenzt die Kennzeichen Eingabe
                                {
                                    Console.WriteLine("Ungültiges Kennzeichen."); //Ausgabe für den Nutzer
                                    Thread.Sleep(2500); // 2.5 Sekunden bevor das Programm weiter geht, damit die Meldung gelesen werden kann
                                }
                                else
                                {
                                    obj.FahrzeugSuchen(obj, kennzeichenEingabe); //Methode für die Suche des Fahrzeugs, obj = Parkhaus Objekt , kennzeichenEingabe = eingegebenes Kennzeichen
                                }
                                Console.Clear(); // Kombination aus Clear + WriteLine(menuAuswahlVier) löscht den Bildschirm und schreibt das Optionsmenü neu
                                Console.WriteLine(menuAuswahlVier);
                                break; //Case Ende
                        }
                    }
                    Console.Clear(); // Kombination aus Clear + WriteLine(menuAuswahlEins) löscht den Bildschirm und schreibt das Optionsmenü neu
                    Console.WriteLine(menuAuswahlEins);
                    break;

                case 4:
                    Console.Clear(); // Kombination aus Clear + WriteLine(menuAuswahlEins) löscht den Bildschirm und schreibt das Optionsmenü neu
                    Console.WriteLine(menuAuswahlEins);
                    Console.WriteLine("\nEs gibt momentan " + (obj.GesammtParkplaetze - obj.BelegteParkplaetze) + " freie Plätze."); //Ausgabe für den Nutzer
                    Console.WriteLine("Drücken Sie eine Taste um fortzufahren."); //Ausgabe für den Nutzer
                    Console.ReadKey(); //Bestätigung abwarten
                    Console.Clear(); // Kombination aus Clear + WriteLine(menuAuswahlEins) löscht den Bildschirm und schreibt das Optionsmenü neu
                    Console.WriteLine(menuAuswahlEins);
                    break; //Case Ende

                case 5:
                    Console.Clear();
                    Console.WriteLine("Momentan befinden sich folgende Fahrzeuge im Parkhaus:\n"); //Ausgabe für den Nutzer
                    obj.AlleFahrzeuge(obj); // Methode für die Ausgabe aller Fahrzeuge ausführen, obj ist unser Parkhaus-Objekt
                    Console.WriteLine("\nDrücken Sie eine Taste um fortzufahren."); //Ausgabe für den Nutzer
                    Console.ReadKey(); //Bestätigung abwarten
                    Console.Clear(); // Kombination aus Clear + WriteLine(menuAuswahlEins) löscht den Bildschirm und schreibt das Optionsmenü neu
                    Console.WriteLine(menuAuswahlEins);
                    break; //Case Ende

                case 6:
                    Console.Clear(); //Bildschirm löschen
                    Console.WriteLine("Sind Sie sicher? Alle gespeicherten Fahrzeuge gehen verloren.\n\n1 - Ja\n2 - Abbrechen"); //Ausgabe für den Nutzer                                      
                    do
                    {
                        key = Console.ReadKey().KeyChar.ToString(); // Eingabe wird in String konvertiert
                        int.TryParse(key, out keyValue2); // String wird in Int konvertiert
                    } while (keyValue2 != 1 && keyValue2 != 2); // Do-While Schleife, wird erst verlassen wenn die Eingabe '1' oder '2' ist
                    switch (keyValue2) //Switchcase für Auswahlmenü, keyValue3 ist die Nutzereingabe von Char zu String zu Int konvertiert
                    {
                        case 1: 
                            int anzahl1, anzahl2; //Erstellen von 2 Variablen zum speichern der Eingabe
                            Console.Clear(); //Bildschirm löschen
                            Console.WriteLine("Bitte geben Sie die neue Anzahl der Etagen für diese Simulation ein."); //Ausgabe für den Nutzer
                            string eingabe1 = Console.ReadLine(); //Neue Eingabe wird in 'eingabe1' gespeichert
                            while (!int.TryParse(eingabe1, out anzahl1)) //Kontrolle der Eingabe - String wird in Int konvertiert, falls nicht möglich, wird die Eingabe erneut aufgerufen
                            {
                                Console.WriteLine($"\n{eingabe1} ist keine Zahl\n"); //Ausgabe für den Nutzer
                                Console.WriteLine("Bitte geben Sie die neue Anzahl der Etagen für diese Simulation ein."); //Ausgabe für den Nutzer
                                eingabe1 = Console.ReadLine(); //Neue Eingabe wird in 'eingabe1' gespeichert
                            }
                            Console.Clear(); //Bildschirm löschen
                            Console.WriteLine("Bitte geben Sie die neue Anzahl der Parkplätze pro Etage für diese Simulation ein."); //Ausgabe für den Nutzer
                            string eingabe2 = Console.ReadLine(); //Neue Eingabe wird in 'eingabe2' gespeichert
                            while (!int.TryParse(eingabe2, out anzahl2)) //Kontrolle der Eingabe - String wird in Int konvertiert, falls nicht möglich, wird die Eingabe erneut aufgerufen
                            {
                                Console.WriteLine($"\n{eingabe2} ist keine Zahl\n"); //Ausgabe für den Nutzer
                                Console.WriteLine("Bitte geben Sie die neue Anzahl der Etagen für diese Simulation ein."); //Ausgabe für den Nutzer
                                eingabe2 = Console.ReadLine(); //Neue Eingabe wird in 'eingabe2' gespeichert
                            }
                            Parkhaus.NeuEingabe(obj, anzahl2, anzahl1); //Methode für Neueingabe der Dimensionen der Etagen und Parkplätze pro Etage
                            Console.Clear(); //Bildschirm löschen
                            Console.WriteLine("Die Größe des Parkhauses wurde erfolgreich geändert.\nAlle Fahrzeuge wurden aus dem Parkhaus entfernt.\n\nDrücken Sie eine Taste um fortzufahren.");
                            Console.ReadKey(); //Bestätigung abwarten
                            Console.Clear(); //Bildschirm löschen
                            Console.WriteLine(menuAuswahlEins); //Erneut das Auswahlmenü auf der Konsole zeichnen
                            break; //Case Ende
                        case 2: 
                            Console.Clear(); //Bildschirm löschen
                            Console.WriteLine(menuAuswahlEins); //Erneut das Auswahlmenü auf der Konsole zeichnen
                            break; //Case Ende
                    }
                    break; //Case Ende
            }
        }
    }
}
