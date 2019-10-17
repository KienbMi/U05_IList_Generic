using System;

namespace Lists.Entity
{
    public class MyPerson : IComparable
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }

        public string Fullname
        {
            get
            {
                return $"{LastName} {FirstName}";
            }
        }

        public int CompareTo(object obj)
        {
            MyPerson other = obj as MyPerson;

            if (other == null)
                throw new ArgumentException("Argument is not from type Person");

            return Fullname.CompareTo(other.Fullname);                
        }

        public override string ToString()
        {
            return $"{LastName} {FirstName}";
        }

    }
}
