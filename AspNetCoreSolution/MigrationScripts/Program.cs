// See https://aka.ms/new-console-template for more information
using Data;
using Microsoft.EntityFrameworkCore;

Console.WriteLine("Hello, World!");

using var db = new PeopleContext();

var osoba = db.Persons
    .Include(p => p.Contracts)
    .Where(p =>p.Contracts.Any())
    .First();

var contract = osoba.Contracts.First();

var cntr = db.Contracts.Include(x => x.Person).Skip(10).First();

Console.WriteLine(  );