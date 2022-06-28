using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model
{
    [Index(nameof(Email))]
    public class Person
    {
     
        #region konstruktory
        public Person(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public Person()
        {

        }
        #endregion

        #region vlastnosti

        
        public int Id { get; set; }

        [MaxLength(200)]
        public string FirstName { get; set; } = "John";

        [MaxLength(200)]
        public string LastName { get; set; } = "Doe";

        public string FullName
        {
            get
            {
                return GetFullName();
            }
        }

        // databazova property
        public DateTime DateOfBirth { get; set; }

        // gui property pro datum narozeni
        [NotMapped]
        public DateOnly DateOfBirthDateOnly 
        {  
            get { return DateOnly.FromDateTime(DateOfBirth); }
            set { DateOfBirth = value.ToDateTime(new TimeOnly(0)); }
        }


        public Address HomeAddress { get; set; }
                                        = new Address();
        [MaxLength(128)]
        [Required]
        public string Email { get; set; }

        public List<Contract> Contracts { get; set; }
                                    = new List<Contract>();
        #endregion

        #region metody
        public override string ToString()
            => $"{FirstName} {LastName}";


        public int Age()
        {
            DateTime today = DateTime.Today;

            int age = today.Year - DateOfBirth.Year;

            if (today.Month < DateOfBirth.Month ||
           ((today.Month == DateOfBirth.Month) && (today.Day < DateOfBirth.Day)))
            {
                age--;  //birthday in current year not yet reached, we are 1 year younger ;)
            }

            return age;
        }

        public string GetFullName()
            => $"{FirstName} {LastName}";

        #endregion

    }
}