using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    // * název smlouvy (name)
    // * evidenční číslo (number)
    // * datum podpisu (signed)
    // * zda je platná (active)

    public class Contract
    {
        public string Name { get; set; }

        public string Number { get; set; }

        public DateTime Signed { get; set; }

        public bool IsActive { get; set; }
    }
}
