using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MigrationScripts
{
    public class Osoba : IVypisInfo
    {
        public string Jmeno { get; set; }

        public void VypisInfo()
        {
            Console.WriteLine($"Osoba: {Jmeno}");
        }
    }

    public class Zvire : IVypisInfo
    {
        public string Druh { get; set; }

        public void VypisInfo()
        {
            Console.WriteLine($"Zvíře druh: {Druh}");
        }
    }

    interface IVypisInfo
    {
        /// <summary>
        /// Vypis informaci o sobe do konzole
        /// </summary>
        public void VypisInfo();
    }
}
