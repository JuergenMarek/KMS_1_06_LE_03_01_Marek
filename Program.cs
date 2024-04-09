using System;
using System.Collections.Generic;


/// <summary>
/// Die Hauptklasse des Programms, hier wird nur das Hauptmenü erzeugt
/// </summary>
class Program
{
    /// <summary>
    /// Hier wird die Liste erstellt und mit Anfagswerten befüllt
    /// </summary>
    static List<Aufgaben> ListeAufgaben = new List<Aufgaben>()
    {
        new Aufgaben(1, "Aufstehen", "hoch"),
        new Aufgaben(2, "Zähne putzen", "hoch"),
        new Aufgaben(3, "Zeitung lesen", "mittel"),
        new Aufgaben(4, "Frühstücken", "niedrig")
    };

    /// <summary>
    /// Das Hauptmenü
    /// </summary>
    static void Main(string[] args)
    {
        bool exit = false;

        while (!exit)
        {
            Console.Clear();
            Console.WriteLine("Hauptmenü:");
            Console.WriteLine("1___Aufgabe hinzufügen");
            Console.WriteLine("2___Alle Aufgaben anzeigen");
            Console.WriteLine("3___Aufgabe bearbeiten");
            Console.WriteLine("4___Aufgabe löschen");
            Console.WriteLine("5___Aufgaben nach Priorität sortiert anzeigen");
            Console.WriteLine("6___Aufgaben durchsuchen");
            Console.WriteLine("7___Programmende");

            Console.Write("Wählen Sie eine Option: ");
            string Auswahl = Console.ReadLine();
            
            // Verweise auf die einzelnen Methoden der Klasse Aufgaben
            switch (Auswahl)
            {
                case "1":
                    Aufgaben.AufgabeHinzufuegen(ListeAufgaben);
                    break;
                case "2":
                    Aufgaben.AlleAufgabenAnzeigen(ListeAufgaben);
                    break;
                case "3":
                    Aufgaben.AufgabeBearbeiten(ListeAufgaben);
                    break;
                case "4":
                    Aufgaben.AufgabeLoeschen(ListeAufgaben);
                    break;
                case "5":
                    Aufgaben.AufgabenNachPrioritaetSortiertAnzeigen(ListeAufgaben);
                    break;
                case "6":
                    Aufgaben.AufgabenDurchsuchen(ListeAufgaben);
                    break;
                case "7":
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Bitte nur gültige Menüpunkte auswählen");
                    Console.WriteLine("Drücken Sie eine Taste, um zurück ins Hauptmenü zu gelangen.");
                    Console.ReadLine();
                    break;
            }
        }
    } 
}
