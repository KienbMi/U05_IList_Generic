using System.Collections;
using System.Text;
using Lists.ListLogic;
using Lists.Comparer;
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

            list.Sort(new ComparerAsc());

            int[] sortedList = new int[list.Count];
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

            list.Sort(new ComparerDesc());

            int[] sortedList = new int[list.Count];
            list.CopyTo(sortedList, 0);
            //Assert
            CollectionAssert.AreEqual(expected, sortedList);
        }

        [TestMethod()]
        public void Sort_withPerson_ShouldBeSortedByFullname()
        {
            //Arrange
            MyList<Person> list = new MyList<Person>();
            Person person1 = new Person { LastName = "Muster", FirstName = "Max", Birthdate = Convert.ToDateTime("10.10.1988") };
            Person person2 = new Person { LastName = "Maier", FirstName = "Fritz", Birthdate = Convert.ToDateTime("3.4.1992") };
            Person person3 = new Person { LastName = "Huber", FirstName = "Sepp", Birthdate = Convert.ToDateTime("15.12.1982") };

            list.Add(person1);
            list.Add(person2);
            list.Add(person3);
            //Act
            Person[] expected = { person3, person2, person1 };

            list.Sort();

            Person[] sortedList = new Person[list.Count];
            list.CopyTo(sortedList, 0);
            //Assert
            CollectionAssert.AreEqual(expected, sortedList);
        }

        [TestMethod()]
        public void SortComperer_withPerson_ShouldBeSortedByFirstnameAsc()
        {
            //Arrange
            MyList<Person> list = new MyList<Person>();
            Person person1 = new Person { LastName = "Muster", FirstName = "Max", Birthdate = Convert.ToDateTime("10.10.1988") };
            Person person2 = new Person { LastName = "Maier", FirstName = "Fritz", Birthdate = Convert.ToDateTime("3.4.1992") };
            Person person3 = new Person { LastName = "Huber", FirstName = "Sepp", Birthdate = Convert.ToDateTime("15.12.1982") };

            list.Add(person1);
            list.Add(person2);
            list.Add(person3);
            //Act
            Person[] expected = { person2, person1, person3 };

            list.Sort(new ComparerFirstname());

            Person[] sortedList = new Person[list.Count];
            list.CopyTo(sortedList, 0);
            //Assert
            CollectionAssert.AreEqual(expected, sortedList);
        }


        [TestMethod()]
        public void SortComperer_withPerson_ShouldBeSortedByAgeDesc()
        {
            //Arrange
            MyList<Person> list = new MyList<Person>();
            Person person1 = new Person { LastName = "Muster", FirstName = "Max", Birthdate = Convert.ToDateTime("10.10.1988") };
            Person person2 = new Person { LastName = "Maier", FirstName = "Fritz", Birthdate = Convert.ToDateTime("3.4.1992") };
            Person person3 = new Person { LastName = "Huber", FirstName = "Sepp", Birthdate = Convert.ToDateTime("15.12.1982") };

            list.Add(person1);
            list.Add(person2);
            list.Add(person3);
            //Act
            Person[] expected = { person3, person1, person2 };

            list.Sort(new ComparerAge());

            Person[] sortedList = new Person[list.Count];
            list.CopyTo(sortedList, 0);
            //Assert
            CollectionAssert.AreEqual(expected, sortedList);
        }


    }
}