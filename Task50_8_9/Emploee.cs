using System;
namespace Task50_8_9
{
    public class Emploee
    {
        public string Name { get; set; }
        public string Position { get; set; }
        public string Office { get; set; }
        public string Salary { get; set; }
        public string Age { get; set; }



        public Emploee(string name, string position, string office, string age, string salary)
        {
            Name = name;
            Position = position;
            Office = office;
            Age = age;
            Salary = salary;
        }


    }
}
