using System.Collections;
using System.Text;
using Lists.ListLogic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lists.Entity;
using System;

namespace Lists.Test
{
    [TestClass()]
    public class MyListTests
    {
        [TestMethod()]
        public void Add_First_ShouldReturnIndexZero()
        {
            //Arrange
            MyList<string> list = new MyList<string>();
            //Act
            list.Add("Müller");
            int index = list.IndexOf("Müller");
            //Assert
            Assert.AreEqual(0, index);
        }

        [TestMethod()]
        public void Add_Third_ShouldReturnIndexTwo()
        {
            //Arrange
            MyList<string> list = new MyList<string>();
            //Act
            list.Add("Müller");
            list.Add("Maier");
            list.Add("Huber");
            int index = list.IndexOf("Huber");

            //Assert
            Assert.AreEqual(2, index);
        }

        [TestMethod()]
        public void IndexOf_OneOfOne_ShouldReturnIndexZero()
        {
            //Arrange
            MyList<string> list = new MyList<string>();
            list.Add("Maier");
            //Act
            int index = list.IndexOf("Maier");
            //Assert
            Assert.AreEqual(0, index);
        }

        [TestMethod()]
        public void IndexOf_Middle_ShouldReturnIndexOne()
        {
            //Arrange
            MyList<string> list = new MyList<string>();
            list.Add("Maier");
            list.Add("Müller");
            list.Add("Huber");
            //Act
            int index = list.IndexOf("Müller");
            //Assert
            Assert.AreEqual(1, index);
        }

        [TestMethod()]
        public void IndexOf_MiddleIntObject_ShouldReturnIndexOne()
        {
            //Arrange
            MyList<int> list = new MyList<int>();
            list.Add(3);
            list.Add(4);
            list.Add(5);
            //Act
            int index = list.IndexOf(4);
            //Assert
            Assert.AreEqual(1, index);
        }

        [TestMethod()]
        public void IndexOf_NotInList_ShouldReturnMinusOne()
        {
            //Arrange
            MyList<int> list = new MyList<int>();
            list.Add(3);
            list.Add(4);
            list.Add(5);
            //Act
            int index = list.IndexOf(6);
            //Assert
            Assert.AreEqual(-1, index);
        }

        [TestMethod()]
        public void GetEnumerator_ThreeElements_ShouldReturnValidData()
        {
            //Arrange
            MyList<int> list = new MyList<int>();
            list.Add(3);
            list.Add(4);
            list.Add(5);
            //IEnumerator enumerator = list.GetEnumerator();
            //Act
            StringBuilder text = new StringBuilder();
            //while (enumerator.MoveNext())
            //{
            //    text.Append(enumerator.Current.ToString());
            //}
            foreach (var item in list)
            {
                text.Append(item);
            }
            //Assert
            Assert.AreEqual("345", text.ToString());
        }

        [TestMethod()]
        public void Clear_EmptyList_ShouldBeEmpty()
        {
            //Arrange
            MyList<int> list = new MyList<int>();
            //Act
            list.Clear();
            //Assert
            Assert.AreEqual(0, list.Count);
        }

        [TestMethod()]
        public void Clear_ListWithSomeEntries_ShouldBeEmpty()
        {
            //Arrange
            MyList<int> list = new MyList<int>();
            list.Add(3);
            list.Add(4);
            list.Add(5);
            //Act
            list.Clear();
            //Assert
            Assert.AreEqual(0, list.Count);
        }

        [TestMethod()]
        public void TContains_EmptyList_ShouldReturnFalse()
        {
            //Arrange
            MyList<int> list = new MyList<int>();
            //Act
            bool found = list.Contains(5);
            //Assert
            Assert.IsFalse(found);
        }

        [TestMethod()]
        public void Contains_ItemIsNotInList_ShouldReturnFalse()
        {
            //Arrange
            MyList<int> list = new MyList<int>();
            list.Add(3);
            list.Add(4);
            list.Add(5);
            //Act
            bool found = list.Contains(6);
            //Assert
            Assert.IsFalse(found);
        }

        [TestMethod()]
        public void Contains_ItemInList_ShouldReturnTrue()
        {
            //Arrange
            MyList<int> list = new MyList<int>();
            list.Add(3);
            list.Add(4);
            list.Add(5);
            //Act
            bool found = list.Contains(5);
            //Assert
            Assert.IsTrue(found);
        }

        [TestMethod()]
        public void Insert_OnIndexOne_ShouldReturnIndexOne()
        {
            //Arrange
            MyList<int> list = new MyList<int>();
            list.Add(3);
            list.Add(4);
            list.Add(5);
            //Act
            list.Insert(1, 99);
            //Assert
            Assert.AreEqual(1, list.IndexOf(99));
        }

        [TestMethod()]
        public void Insert_Zero_ShouldReturnIndexZero()
        {
            //Arrange
            MyList<int> list = new MyList<int>();
            list.Add(3);
            list.Add(4);
            list.Add(5);
            //Act
            list.Insert(0, 99);
            //Assert
            Assert.AreEqual(0, list.IndexOf(99));
        }

        [TestMethod()]
        public void Insert_End_ShouldReturnIndexThree()
        {
            //Arrange
            MyList<int> list = new MyList<int>();
            list.Add(3);
            list.Add(4);
            list.Add(5);
            //Act
            list.Insert(3, 99);
            //Assert
            Assert.AreEqual(3, list.IndexOf(99));
        }

        [TestMethod()]
        public void Insert_IndexTooLarge_ShouldReturnMinusOne()
        {
            //Arrange
            MyList<int> list = new MyList<int>();
            list.Add(3);
            list.Add(4);
            list.Add(5);
            //Act
            list.Insert(4, 99);
            //Assert
            Assert.AreEqual(-1, list.IndexOf(99));
        }

        [TestMethod()]
        public void T19_Insert_IndexNegative_ShouldReturnMinusOne()
        {
            //Arrange
            MyList<int> list = new MyList<int>();
            list.Add(3);
            list.Add(4);
            list.Add(5);
            //Act
            list.Insert(-1, 99);
            //Assert
            Assert.AreEqual(-1, list.IndexOf(99));
        }

        [TestMethod()]
        public void Insert_EmptyList_ShouldReturnIndexZero()
        {
            //Arrange
            MyList<int> list = new MyList<int>();
            //Act
            list.Insert(0, 99);
            //Assert
            Assert.AreEqual(0, list.IndexOf(99));
        }

        [TestMethod()]
        public void Remove_MiddleElement_ShouldReturnCountTwo()
        {
            //Arrange
            MyList<int> list = new MyList<int>();
            list.Add(3);
            list.Add(4);
            list.Add(5);
            //Act
            list.Remove(4);
            //Assert
            Assert.AreEqual(2, list.Count);
            Assert.AreEqual(-1, list.IndexOf(4));
        }

        [TestMethod()]
        public void Remove_FirstElement_ShouldSetNewFirstElement()
        {
            //Arrange
            MyList<int> list = new MyList<int>();
            list.Add(3);
            list.Add(4);
            list.Add(5);
            //Act
            list.Remove(3);
            //Assert
            Assert.AreEqual(2, list.Count);
            Assert.AreEqual(-1, list.IndexOf(3));
            Assert.AreEqual(0, list.IndexOf(4));
        }

        [TestMethod()]
        public void Remove_LastElement_ShouldReturnCountTwo()
        {
            //Arrange
            MyList<int> list = new MyList<int>();
            list.Add(3);
            list.Add(4);
            list.Add(5);
            //Act
            list.Remove(5);
            //Assert
            Assert.AreEqual(2, list.Count);
            Assert.AreEqual(-1, list.IndexOf(5));
            Assert.AreEqual(1, list.IndexOf(4));
        }

        [TestMethod()]
        public void Remove_ElementNotInList_ShouldChangeNothing()
        {
            //Arrange
            MyList<int> list = new MyList<int>();
            list.Add(3);
            list.Add(4);
            list.Add(5);
            //Act
            list.Remove(6);
            //Assert
            Assert.AreEqual(3, list.Count);
        }

        [TestMethod()]
        public void Remove_EmptyList_ShouldChangeNothing()
        {
            //Arrange
            MyList<int> list = new MyList<int>();
            //Act
            list.Remove(6);
            //Assert
            Assert.AreEqual(0, list.Count);
        }


        [TestMethod()]
        public void RemoveAt_MiddleElement_ShouldReturnCountTwo()
        {
            //Arrange
            MyList<int> list = new MyList<int>();
            list.Add(3);
            list.Add(4);
            list.Add(5);
            //Act
            list.RemoveAt(1);
            //Assert
            Assert.AreEqual(2, list.Count);
            Assert.AreEqual(-1, list.IndexOf(4));
        }

        [TestMethod()]
        public void RemoveAt_FirstElement_ShouldSetNewFirstElement()
        {
            //Arrange
            MyList<int> list = new MyList<int>();
            list.Add(3);
            list.Add(4);
            list.Add(5);
            //Act
            list.RemoveAt(0);
            //Assert
            Assert.AreEqual(2, list.Count);
            Assert.AreEqual(-1, list.IndexOf(3));
            Assert.AreEqual(0, list.IndexOf(4));
        }

        [TestMethod()]
        public void RemoveAt_LastElement_ShouldReturnCountTwo()
        {
            //Arrange
            MyList<int> list = new MyList<int>();
            list.Add(3);
            list.Add(4);
            list.Add(5);
            //Act
            list.RemoveAt(2);
            //Assert
            Assert.AreEqual(2, list.Count);
            Assert.AreEqual(-1, list.IndexOf(5));
            Assert.AreEqual(1, list.IndexOf(4));
        }

        [TestMethod()]
        public void RemoveAt_ElementNotInList_ShouldChangeNothing()
        {
            //Arrange
            MyList<int> list = new MyList<int>();
            list.Add(3);
            list.Add(4);
            list.Add(5);
            //Act
            list.RemoveAt(3);
            //Assert
            Assert.AreEqual(3, list.Count);
        }

        [TestMethod()]
        public void RemoveAt_EmptyList_ShouldChangeNothing()
        {
            //Arrange
            MyList<int> list = new MyList<int>();
            //Act
            list.RemoveAt(0);
            //Assert
            Assert.AreEqual(0, list.Count);
        }


        [TestMethod()]
        public void CopyTo_FullList_ShouldReturnFilledArray()
        {
            //Arrange
            MyList<int> list = new MyList<int>();
            list.Add(3);
            list.Add(4);
            list.Add(5);
            int[] expected = { 3, 4, 5 };
            int[] targetArray = new int[3];
            //Act
            list.CopyTo(targetArray, 0);
            //Assert
            CollectionAssert.AreEqual(expected, targetArray);
        }

        [TestMethod()]
        public void CopyTo_PartList_ShouldReturnArrayWithNullAtEnd()
        {
            //Arrange
            MyList<object> list = new MyList<object>();
            list.Add(3);
            list.Add(4);
            list.Add(5);
            int?[] expected = { 4, 5, null };
            object[] targetArray = new object[3];
            //Act
            list.CopyTo(targetArray, 1);
            //Assert
            CollectionAssert.AreEqual(expected, targetArray);
        }

        [TestMethod()]
        public void CopyTo_LastElement_ShouldReturnArrayWithOneElement()
        {
            //Arrange
            MyList<int> list = new MyList<int>();
            list.Add(3);
            list.Add(4);
            list.Add(5);
            int?[] expected = { 5 };
            int[] targetArray = new int[1];
            //Act
            list.CopyTo(targetArray, 2);
            //Assert
            CollectionAssert.AreEqual(expected, targetArray);
        }
        [TestMethod()]
        public void CopyTo_TargetTooSmall_ShouldLeftArrayEmpty()
        {
            //Arrange
            MyList<int> list = new MyList<int>();
            list.Add(3);
            list.Add(4);
            list.Add(5);
            int[] expected = { default, default };
            int[] targetArray = new int[2];
            //Act
            list.CopyTo(targetArray, 0);
            //Assert
            CollectionAssert.AreEqual(expected, targetArray);
        }



        [TestMethod()]
        public void Indexer_InsertMiddle_ShouldIncreaseList()
        {
            //Arrange
            MyList<int> list = new MyList<int>();
            list.Add(3);
            list.Add(4);
            list.Add(5);
            //Act
            list[1] = 99;
            //Assert
            Assert.AreEqual(1, list.IndexOf(99));
        }

        [TestMethod()]
        public void Indexer_InsertFirst_ShouldReturnCorrectIndex()
        {
            //Arrange
            MyList<int> list = new MyList<int>();
            list.Add(3);
            list.Add(4);
            list.Add(5);
            //Act
            list[0] = 99;
            //Assert
            Assert.AreEqual(0, list.IndexOf(99));
        }

        [TestMethod()]
        public void Indexer_ReadMiddle_ShouldReturnCorrectValue()
        {
            //Arrange
            MyList<int> list = new MyList<int>();
            list.Add(3);
            list.Add(4);
            list.Add(5);
            //Act
            var value = list[0];
            //Assert
            Assert.AreEqual(3, value);
        }
    }
}