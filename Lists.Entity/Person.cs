using System;

namespace Lists.Entity
{
    public class Person : IComparable
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public DateTime Birthdate { get; set; }

        public override string ToString()
        {
            return $"{LastName} {FirstName}";
        }

        public int CompareTo(object other)
        {
            Person otherPerson = other as Person;

            if (otherPerson == null)
                throw new ArgumentException("Argument is not from type Person");

            return ToString().CompareTo(other.ToString());
        }
    }
}
