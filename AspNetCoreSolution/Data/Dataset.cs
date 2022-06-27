using Model;
using System.Xml.Serialization;

namespace Data
{
    public class DataSet
    {
        public static List<Person> People;

        public static void LoadPeople()
        {
            People = new List<Person>();

            var p1 = new Person("Ondřej", "Kolomazník");
            p1.DateOfBirth = new DateTime(1986, 12, 30);
            p1.HomeAddress.Street = "Vedlejší 57";
            p1.HomeAddress.City = "Vyškov";
            p1.Email = "kolomaznik@example.com";
            Contract c = new Contract()
            {
                Number = "A1214",
                IsActive = true,
                Name = "Smlouva 1",
                Signed = new DateTime(2020, 5, 1)
            };
            p1.Contracts.Add(c);
            People.Add(p1);

            var p2 = new Person("Alena", "Veselá");
            p2.DateOfBirth = new DateTime(2000, 12, 30);
            p2.HomeAddress.Street = "Horkého 14";
            p2.HomeAddress.City = "Praha";
            p2.Email = "alena@example.com";
            Contract c2 = new Contract()
            {
                Number = "A1215",
                IsActive = true,
                Name = "Smlouva 1",
                Signed = new DateTime(2020, 8, 12)
            };
            p2.Contracts.Add(c2);
            People.Add(p2);
        }

        public static void LoadFromXML(string file = @"dataset.xml")
        {
            People = Serialization.DeSerialize<List<Person>>(file);
        }

    
        //pridani osoby do datasetu
        public static void AddPerson(Person person)
        {
            People.Add(person);
        }

        //najiti osoby podle emailu
        public static (bool success, Person person) FindPerson(string email)
        {
            try
            {
                if (People.Any(osoba => osoba.Email == email))
                {
                    var p = People
                        .Where(os => os.Email == email)
                        .First();

                    return (true, p);
                }

                return (false, null);
                //People.Where(os => os.Email == email)
                //      .FirstOrDefault();

            }

            catch (InvalidOperationException iex)
            {
                //log
                return (false, null);
            }

            catch (Exception ex)
            {
                //log
                return (false, null);
            }
        }

        public class Serialization
        {
            public static bool Serialize<T>(T input, string outputFile)
            {
                try
                {
                    // Serialization
                    XmlSerializer s = new XmlSerializer(typeof(T));
                    using (TextWriter w = new StreamWriter(outputFile))
                    {
                        s.Serialize(w, input);
                    }

                    return true;
                }
                catch (Exception Ex)
                {
                    return false;
                }
            }

            public static T DeSerialize<T>(string inputFile)
            {
                XmlSerializer s = new XmlSerializer(typeof(T));
                T newClass;
                using (TextReader r = new StreamReader(inputFile))
                {
                    newClass = (T)s.Deserialize(r);
                }
                return newClass;
            }

            public static T DeSerializeString<T>(string inputContent)
            {
                XmlSerializer s = new XmlSerializer(typeof(T));
                T newClass;
                using (TextReader r = new StringReader(inputContent))
                {
                    newClass = (T)s.Deserialize(r);
                }

                return newClass;
            }
        }
    }
}