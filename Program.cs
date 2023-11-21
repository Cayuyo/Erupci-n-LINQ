﻿// See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");
#pragma warning disable CS8602
List<Eruption> eruptions = new List<Eruption>()
{
    new Eruption("La Palma", 2021, "Canary Is", 2426, "Stratovolcano"),
    new Eruption("Villarrica", 1963, "Chile", 2847, "Stratovolcano"),
    new Eruption("Chaiten", 2008, "Chile", 1122, "Caldera"),
    new Eruption("Kilauea", 2018, "Hawaiian Is", 1122, "Shield Volcano"),
    new Eruption("Hekla", 1206, "Iceland", 1490, "Stratovolcano"),
    new Eruption("Taupo", 1910, "New Zealand", 760, "Caldera"),
    new Eruption("Lengai, Ol Doinyo", 1927, "Tanzania", 2962, "Stratovolcano"),
    new Eruption("Santorini", 46,"Greece", 367, "Shield Volcano"),
    new Eruption("Katla", 950, "Iceland", 1490, "Subglacial Volcano"),
    new Eruption("Aira", 766, "Japan", 1117, "Stratovolcano"),
    new Eruption("Ceboruco", 930, "Mexico", 2280, "Stratovolcano"),
    new Eruption("Etna", 1329, "Italy", 3320, "Stratovolcano"),
    new Eruption("Bardarbunga", 1477, "Iceland", 2000, "Stratovolcano")
};
// Example Query - Prints all Stratovolcano eruptions
IEnumerable<Eruption> stratovolcanoEruptions = eruptions.Where(c => c.Type == "Stratovolcano");
PrintEach(stratovolcanoEruptions, "Stratovolcano eruptions.");
// Execute Assignment Tasks here!
    // 1. Use LINQ to find the first eruption that is in Chile and print the result.
        Eruption? firstChileEruption = eruptions.FirstOrDefault(c => c.Location == "Chile");
        Console.WriteLine("**********************************");
        Console.WriteLine("First eruption in Chile: {0}", firstChileEruption);

    // 2.Find the first eruption from the "Hawaiian Is" location and print it. If none is found, print "No Hawaiian Is Eruption found."
        Eruption? firstHawaiianEruption = eruptions.FirstOrDefault(c => c.Location == "Hawaiian Is");
        Console.WriteLine("**********************************");
        if (firstHawaiianEruption == null)
        {
            Console.WriteLine("No Hawaiian Is Eruption found.");
        }
        else
        {
            Console.WriteLine("First eruption from the Hawaiian Is: {0}", firstHawaiianEruption);
        }

    // 3. Find the first eruption that is after the year 1900 AND in "New Zealand", then print it.

        Eruption? firstNewZealandEruption = eruptions.FirstOrDefault(c => c.Year > 1900 && c.Location == "New Zealand");
        Console.WriteLine("**********************************");
        Console.WriteLine("First eruption after 1900 in New Zealand: {0}", firstNewZealandEruption);

    // 4. Find all eruptions where the volcano's elevation is over 2000m and print them.
        IEnumerable<Eruption> highElevationEruptions = eruptions.Where(c => c.ElevationInMeters > 2000);
        Console.WriteLine("**********************************");
        PrintEach(highElevationEruptions, "Eruptions with elevation over 2000m.");  


    // 5. Find all eruptions where the volcano's name starts with "L" and print them. Also print the number of eruptions found.
        IEnumerable<Eruption> lNameEruptions = eruptions.Where(c => c.Volcano.StartsWith("L"));
        int lNameEruptionsCount = lNameEruptions.Count();
        Console.WriteLine("**********************************");
        PrintEach(lNameEruptions, $"Eruptions with volcano name starting with L ({lNameEruptionsCount} found).");


    // 6. Find the highest elevation, and print only that integer (Hint: Look up how to use LINQ to find the max!)
        int highestElevation = eruptions.Max(c => c.ElevationInMeters);
        Console.WriteLine("**********************************");
        Console.WriteLine("The highest elevation is {0} meters.", highestElevation);

    // 7. Use the highest elevation variable to find a print the name of the Volcano with that elevation.
        Eruption? highestElevationVolcano = eruptions.FirstOrDefault(c => c.ElevationInMeters == highestElevation);
        Console.WriteLine("**********************************");
        Console.WriteLine("The name of the volcano with the highest elevation is {0}.", highestElevationVolcano.Volcano);   
    // 8. Print all Volcano names alphabetically.
        IEnumerable<string> volcanoNames = eruptions.OrderBy(c => c.Volcano).Select(c => c.Volcano);
        Console.WriteLine("**********************************");
        PrintEach(volcanoNames, "Volcano names in alphabetical order.");

    // 9. Print all the eruptions that happened before the year 1000 CE alphabetically according to Volcano name.
        IEnumerable<Eruption> ancientEruptions = eruptions.Where(c => c.Year < 1000).OrderBy(c => c.Volcano);
        Console.WriteLine("**********************************");
        PrintEach(ancientEruptions, "Eruptions before 1000 CE in alphabetical order by volcano name.");

    // BONUS: Redo the last query, but this time use LINQ to only select the volcano's name so that only the names are printed.
        IEnumerable<string> ancientVolcanoNames = eruptions.Where(c => c.Year < 1000).OrderBy(c => c.Volcano).Select(c => c.Volcano);
        Console.WriteLine("**********************************");
        PrintEach(ancientVolcanoNames, "Volcano names before 1000 CE in alphabetical order.");

// Helper method to print each item in a List or IEnumerable.This should remain at the bottom of your class!
static void PrintEach(IEnumerable<dynamic> items, string msg = "")
{
    Console.WriteLine("\n" + msg);
    foreach (var item in items)
    {
        Console.WriteLine(item.ToString());
    }
}