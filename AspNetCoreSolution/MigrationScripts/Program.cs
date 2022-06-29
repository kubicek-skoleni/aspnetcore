// See https://aka.ms/new-console-template for more information


using System.Globalization;

CultureInfo ci = new CultureInfo("cz-CS");
Thread.CurrentThread.CurrentCulture = ci;
Thread.CurrentThread.CurrentUICulture = ci;

DateTime d = DateTime.Now;

Console.WriteLine(d);



//using MigrationScripts;


//Zvire pes = new Zvire() { Druh = "pes"};
//Osoba petr = new Osoba() { Jmeno = "Petr"};

//List<IVypisInfo> list = new List<IVypisInfo>() { pes, petr };

//VypisInfoDoKonzole(list);

//void VypisInfoDoKonzole(List<IVypisInfo> items)
//{
//    foreach (var item in items)
//    {
//        item.VypisInfo();
//    }
//}
