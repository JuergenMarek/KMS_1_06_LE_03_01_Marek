using System;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// Die Klasse Aufgaben mit den Properties, dem Konstruktor und den einzelnen Methoden
/// </summary>
public class Aufgaben
{
    public int ID { get; set; }
    public string Beschreibung { get; set; }
    public string Prioritaet { get; set; }

    public Aufgaben(int id, string beschreibung, string prioritaet)
    {
        this.ID = id;
        this.Beschreibung = beschreibung;
        this.Prioritaet = prioritaet;
    }

    /// <summary>
    /// Hier wird eine Aufgabe hinzugefügt
    /// </summary>
    public static void AufgabeHinzufuegen(List<Aufgaben> ListeAufgaben)
    {
        Console.Clear();
        Console.Write("Geben Sie die Beschreibung der Aufgabe ein: ");
        string beschreibung = Console.ReadLine();

        string prioritaet;
        // Überprüfen, ob bei Priorität hoch, mittel oder niedrig eingegeben wurde
        do
        {
            Console.Write("Geben Sie die Priorität ein (hoch, mittel, niedrig): ");
            prioritaet = Console.ReadLine().ToLower();

            if (prioritaet != "hoch" && prioritaet != "mittel" && prioritaet != "niedrig")
            {
                Console.WriteLine("Bitte nur hoch, mittel oder niedrig eingeben");
            }
        } while (prioritaet != "hoch" && prioritaet != "mittel" && prioritaet != "niedrig");

        // Ermitteln der ID der Aufgabe
        int idNeueAufgabe = ListeAufgaben.Count > 0 ? ListeAufgaben[ListeAufgaben.Count -1].ID + 1: 1;
        // Hinzufügen der neuen Aufgabe in die Liste
        ListeAufgaben.Add(new Aufgaben(idNeueAufgabe, beschreibung, prioritaet));

        Console.WriteLine("Aufgabe erfolgreich hinzugefügt");
        Console.WriteLine("Drücken Sie eine Taste, um zurück ins Hauptmenü zu gelangen.");
        Console.ReadKey();
    }

    /// <summary>
    /// Hier werden alle Aufgaben sortiert nach der ID angezeigt
    /// </summary>
    public static void AlleAufgabenAnzeigen(List<Aufgaben> ListeAufgaben)
    {
        // Sortierung der Liste nach ID
        var sortierteAufgaben = ListeAufgaben.OrderBy(aufgabe => aufgabe.ID)
                               .ToList();

        // Ausgabe der kompletten Liste
        Console.Clear();
        Console.WriteLine("Liste aller Aufgaben:");

        foreach (var aufgabe in sortierteAufgaben)
        {
            Console.WriteLine($"ID: {aufgabe.ID}, Beschreibung: {aufgabe.Beschreibung}, Priorität: {aufgabe.Prioritaet}");
        }

        Console.WriteLine("Drücken Sie eine Taste, um zurück ins Hauptmenü zu gelangen.");
        Console.ReadKey();
    }

    /// <summary>
    /// Hier kann man einzelne Aufgaben bearbeiten
    /// </summary>
    public static void AufgabeBearbeiten(List<Aufgaben> ListeAufgaben)
    {
        // Anzeigen der kompletten Liste
        Console.Clear();
        Console.WriteLine("Liste aller Aufgaben:");

        foreach (var aufgabe in ListeAufgaben)
        {
            Console.WriteLine($"ID: {aufgabe.ID}, Beschreibung: {aufgabe.Beschreibung}, Priorität: {aufgabe.Prioritaet}");
        }

        // Abfrage der ID, die bearbeitet werden soll
        Console.Write("Geben Sie die ID der zu bearbeitenden Aufgabe ein: ");
        int idBearbeiten = int.Parse(Console.ReadLine());

        // Suchen der ID in der Liste
        var aufgabeBearbeiten = ListeAufgaben.Find(aufgabe => aufgabe.ID == idBearbeiten);

        if (aufgabeBearbeiten == null)
        {
            Console.WriteLine("Aufgabe nicht gefunden");
        }
        else
        {
            Console.WriteLine($"Aktuelle Beschreibung: {aufgabeBearbeiten.Beschreibung}");
            // Neue Beschreibung eingeben
            Console.Write("Geben Sie die neue Beschreibung ein: ");
            string neueBeschreibung = Console.ReadLine();

            string neuePrioritaet;
            // Überprüfen, ob bei Priorität hoch, mittel oder niedrig eingetragen wurde
            do
            {
                Console.WriteLine($"Aktuelle Priorität: {aufgabeBearbeiten.Prioritaet}");
                Console.Write("Geben Sie die neue Priorität ein (hoch, mittel, niedrig): ");
                neuePrioritaet = Console.ReadLine().ToLower();

                if (neuePrioritaet != "hoch" && neuePrioritaet != "mittel" && neuePrioritaet != "niedrig")
                {
                    Console.WriteLine("Bitte nur hoch, mittel oder niedrig eingeben");
                }
            } while (neuePrioritaet != "hoch" && neuePrioritaet != "mittel" && neuePrioritaet != "niedrig");

            // Schreiben der aktualisierten Werte in die Liste
            ListeAufgaben[ListeAufgaben.IndexOf(aufgabeBearbeiten)] = new Aufgaben(idBearbeiten, neueBeschreibung, neuePrioritaet);
            Console.WriteLine("Aufgabe erfolgreich aktualisiert");
        }

        Console.WriteLine("Drücken Sie eine Taste, um zurück ins Hauptmenü zu gelangen.");
        Console.ReadKey();
    }

    /// <summary>
    /// Hier wird die ausgewählte Aufgabe gelöscht
    /// </summary>
    public static void AufgabeLoeschen(List<Aufgaben> ListeAufgaben)
    {
        // Ausgabe der gesamt Liste
        Console.Clear();
        Console.WriteLine("Liste aller Aufgaben:");

        foreach (var aufgabe in ListeAufgaben)
        {
            Console.WriteLine($"ID: {aufgabe.ID}, Beschreibung: {aufgabe.Beschreibung}, Priorität: {aufgabe.Prioritaet}");
        }

        // Abfrage der ID zum Löschen
        Console.Write("Geben Sie die ID der zu löschenden Aufgabe ein: ");
        int idLoeschen = int.Parse(Console.ReadLine());

        // Suchen der ID in der Liste
        var aufgabeLoeschen = ListeAufgaben.Find(aufgabe => aufgabe.ID == idLoeschen);

        if (aufgabeLoeschen == null)
        {
            Console.WriteLine("Aufgabe nicht gefunden");
        }
        else
        {
            // Löschen des Listeneintrags
            ListeAufgaben.Remove(aufgabeLoeschen);
            Console.WriteLine("Aufgabe erfolgreich gelöscht");
        }

        Console.WriteLine("Drücken Sie eine Taste, um zurück ins Hauptmenü zu gelangen.");
        Console.ReadKey();
    }

    /// <summary>
    /// Hier werden die Aufgaben nach Priorität sortiert angezeigt
    /// </summary>
    public static void AufgabenNachPrioritaetSortiertAnzeigen(List<Aufgaben> ListeAufgaben)
    {
        // Sortierung der Liste nach Priorität und dann alphabetisch
        var sortierteAufgaben = ListeAufgaben.OrderBy(aufgabe => aufgabe.Prioritaet)
                               .ThenBy(aufgabe => aufgabe.Beschreibung)
                               .ToList();

        Console.Clear();
        Console.WriteLine("Liste aller Aufgaben nach Priorität sortiert:");

        // Ausgabe der sortierten Liste
        foreach (var aufgabe in sortierteAufgaben)
        {
            Console.WriteLine($"ID: {aufgabe.ID}, Beschreibung: {aufgabe.Beschreibung}, Priorität: {aufgabe.Prioritaet}");
        }

        Console.WriteLine("Drücken Sie eine Taste, um zurück ins Hauptmenü zu gelangen.");
        Console.ReadKey();
    }

    /// <summary>
    /// Hier werden alle Aufgaben nach dem Schlüsselwort durchsucht
    /// </summary>
    public static void AufgabenDurchsuchen(List<Aufgaben> ListeAufgaben)
    {
        // Abfrage des Schlüsselworts
        Console.Clear();
        Console.Write("Geben Sie ein Schlüsselwort ein, nach dem gesucht werden soll: ");
        string suchwort = Console.ReadLine();

        // Durchsuchen der Liste nach dem Schlüsselwort
        var gefundeneAufgaben = ListeAufgaben.Where(aufgabe => aufgabe.Beschreibung.ToLower().Contains(suchwort.ToLower()));

        // Ausgeabe der gefundenen Elemente der Liste
        Console.WriteLine($"Aufgaben mit dem Schlüsselwort '{suchwort}':");
        foreach (var aufgabe in gefundeneAufgaben)
        {
            Console.WriteLine($"ID: {aufgabe.ID}, Beschreibung: {aufgabe.Beschreibung}, Priorität: {aufgabe.Prioritaet}");
        }

        Console.WriteLine("Drücken Sie eine Taste, um zurück ins Hauptmenü zu gelangen.");
        Console.ReadKey();
    }
}
