// LINQ werkt op elke IEnumerable<T>: een array, een List<T>, enzovoort.
int[] getallen = [5, 12, 8, 130, 44, 3, 27];

// Method-syntax: LINQ-operators als methods, aan elkaar geketend.
IEnumerable<int> viaMethods = getallen
    .Where(g => g > 10)
    .OrderBy(g => g);

// Query-syntax: dezelfde query, met sleutelwoorden die op SQL lijken.
IEnumerable<int> viaQuery =
    from g in getallen
    where g > 10
    orderby g
    select g;

// Beide leveren exact hetzelfde op. Kies de vorm die het leesbaarst is.
Console.WriteLine("Boven 10 (method-syntax): " + string.Join(", ", viaMethods));
Console.WriteLine("Boven 10 (query-syntax):  " + string.Join(", ", viaQuery));

List<Student> studenten =
[
    new("Ana", 16),
    new("Bram", 9),
    new("Cem", 12),
    new("Dana", 18),
];

// Projectie naar een anoniem type: we houden enkel de properties die we nodig hebben.
// Het type heeft geen naam; de compiler leidt het af uit de gebruikte properties.
var overzicht = studenten
    .OrderByDescending(s => s.Punten)
    .Select(s => new { s.Naam, s.Punten });

Console.WriteLine("\nStudenten, hoogste punten eerst:");
foreach (var regel in overzicht)
{
    Console.WriteLine($"  {regel.Naam}: {regel.Punten}");
}

// First geeft het eerste element; gooit als er geen is.
Student beste = studenten.OrderByDescending(s => s.Punten).First();

// FirstOrDefault geeft null (voor referentietypes) als er geen match is.
Student? eersteGezakte = studenten.FirstOrDefault(s => s.Punten < 10);

Console.WriteLine($"\nBeste student: {beste.Naam} ({beste.Punten})");
Console.WriteLine($"Eerste gezakte: {eersteGezakte?.Naam ?? "geen"}");

// Count, All en Any beantwoorden vragen over de hele reeks.
Console.WriteLine($"Aantal geslaagd: {studenten.Count(s => s.Punten >= 10)}");
Console.WriteLine($"Iedereen geslaagd? {studenten.All(s => s.Punten >= 10)}");
Console.WriteLine($"Iemand met 18 of meer? {studenten.Any(s => s.Punten >= 18)}");

record Student(string Naam, int Punten);
