using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public int Id { get; set; }

        [MaxLength(200)]
        public string Name { get; set; }

        [MaxLength(200)]
        public string Number { get; set; }

        public DateTime Signed { get; set; }

        public bool IsActive { get; set; }

        public Person Person { get; set; }

    }
}
