// See https://aka.ms/new-console-template for more information
using Data;

Console.WriteLine("Hello, World!");


// inicializace People (memory) z XML
Data.DataSet.LoadFromXML(@"C:\Users\StudentEN\source\repos\kubicek-skoleni\aspnetcore\dataset.xml");

Console.WriteLine($"Načetl jsem {Data.DataSet.People.Count} lidí");

using var db = new PeopleContext();

//db.Persons.AddRange(Data.DataSet.People);

db.SaveChanges();
