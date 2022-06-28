using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Address
    {
        public int Id { get; set; }
        
        [MaxLength(200)] 
        public string City { get; set; }

        [MaxLength(200)]
        public string Street { get; set; }

        //public Person Person { get; set; }

        public override string ToString()
            => $"{City} {Street}";

    }
}
