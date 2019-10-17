using System.Collections;
using System.Text;
using Lists.ListLogic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lists.Entity;
using System;

namespace Lists.Test
{
    [TestClass()]
    public class MySortTest
    {
        [TestMethod()]
        public void Sort_withInt_ShouldBeSorted()
        {
            //Arrange
            MyList<int> list = new MyList<int>();
            list.Add(4);
            list.Add(7);
            list.Add(5);
            list.Add(9);
            list.Add(1);
            //Act
            object[] expected = { 1, 4, 5, 7, 9 };

            list.Sort();

            int[] sortedList = new int[list.Count];
            list.CopyTo(sortedList, 0);
            //Assert
            CollectionAssert.AreEqual(expected, sortedList);
        }

        [TestMethod()]
        public void Sort_withIntAndPerson_PersonOnTheSamePos()
        {
            //Arrange
            MyList<object> list = new MyList<object>();
            Person person = new Person { LastName = "Muster", FirstName = "Max" };
            list.Add(4);
            list.Add(7);
            list.Add(person);
            list.Add(9);
            list.Add(1);
            //Act
            object[] expected = { 4, 7, person, 1, 9 };

            list.Sort();

            object[] sortedList = new object[list.Count];
            list.CopyTo(sortedList, 0);
            //Assert
            CollectionAssert.AreEqual(expected, sortedList);
        }

        [TestMethod()]
        public void SortComparer_withInt_ShouldBeSortedAsc()
        {
            //Arrange
            MyList<int> list = new MyList<int>();
            list.Add(4);
            list.Add(7);
            list.Add(5);
            list.Add(9);
            list.Add(1);
            //Act
            int[] expected = { 1, 4, 5, 7, 9 };

            list.Sort(new AscComp());

            int[] sortedList = new int[list.Count];
            list.CopyTo(sortedList, 0);
            //Assert
            CollectionAssert.AreEqual(expected, sortedList);
        }

        [TestMethod()]
        public void SortComparer_withIntandPerson_PersonOnTheSamePos()
        {
            //Arrange
            MyList<object> list = new MyList<object>();
            Person person = new Person { LastName = "Muster", FirstName = "Max" };
            list.Add(4);
            list.Add(7);
            list.Add(person);
            list.Add(9);
            list.Add(1);
            //Act
            object[] expected = { 4, 7, person, 1, 9 };

            list.Sort(new AscComp());

            object[] sortedList = new object[list.Count];
            list.CopyTo(sortedList, 0);
            //Assert
            CollectionAssert.AreEqual(expected, sortedList);
        }

        [TestMethod()]
        public void SortComparer_withInt_ShouldBeSortedDesc()
        {
            //Arrange
            MyList<int> list = new MyList<int>();
            list.Add(4);
            list.Add(7);
            list.Add(5);
            list.Add(9);
            list.Add(1);
            //Act
            object[] expected = { 9, 7, 5, 4, 1 };

            list.Sort(new DescComp());

            int[] sortedList = new int[list.Count];
            list.CopyTo(sortedList, 0);
            //Assert
            CollectionAssert.AreEqual(expected, sortedList);
        }

        private class AscComp : IComparer
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

        private class DescComp : IComparer
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
    }
}