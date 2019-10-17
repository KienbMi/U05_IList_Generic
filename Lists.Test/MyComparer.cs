using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Lists.Entity;

namespace Lists.Comparer
{
    public class ComparerAsc : IComparer
    {
        public int Compare(object x, object y)
        {
            IComparable leftObject = x as IComparable;
            IComparable rightObject = y as IComparable;

            if (leftObject == null || rightObject == null)
                throw new ArgumentException("Argument not from type ICompareable");

            return leftObject.CompareTo(rightObject);
        }
    }
    public class ComparerDesc : IComparer
    {
        public int Compare(object x, object y)
        {
            IComparable leftObject = x as IComparable;
            IComparable rightObject = y as IComparable;

            if (leftObject == null || rightObject == null)
                throw new ArgumentException("Argument not from type ICompareable");

            return rightObject.CompareTo(leftObject);
        }
    }

    public class ComparerFirstname : IComparer
    {
        public int Compare(object x, object y)
        {
            Person leftObject = x as Person;
            Person rightObject = y as Person;

            if (leftObject == null || rightObject == null)
                throw new ArgumentException("Argument not from type Person");

            return rightObject.FirstName.CompareTo(leftObject.FirstName);
        }
    }

    public class ComparerAge : IComparer
    {
        public int Compare(object x, object y)
        {
            Person leftObject = x as Person;
            Person rightObject = y as Person;

            if (leftObject == null || rightObject == null)
                throw new ArgumentException("Argument not from type Person");

            return rightObject.Birthdate.CompareTo(leftObject.Birthdate);
        }
    }
}
