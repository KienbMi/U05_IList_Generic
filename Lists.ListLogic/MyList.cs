using System;
using System.Collections;

namespace Lists.ListLogic
{
    /// <summary>
    /// Die Liste verwaltet beliebige Elemente und implementiert
    /// das IList-Interface und damit auch ICollection und IEnumerable
    /// </summary>
    public class MyList : IList
    {
        Node _head;

        #region IList Members

        /// <summary>
        /// Ein neues Objekt wird in die Liste am Ende
        /// eingefügt. Etwaige Typinkompatiblitäten beim Vergleich werden
        /// nicht behandelt und lösen eine Exception aus.
        /// </summary>
        /// <param name="value">Einzufügender Datensatz</param>
        /// <returns>Index des Werts in der Liste</returns>
        public int Add(object value)
        {
            if (value == null)
                throw new ArgumentNullException(nameof(value));

            Node newNode = new Node(value);
            int idx;

            if (_head == null)
            {
                idx = 0;
                _head = newNode;
            }
            else
            {
                idx = 1;
                Node run = _head;
                while (run.Next != null)
                {
                    run = run.Next;
                    idx++;
                }
                run.Next = newNode;
            }
            return idx;
        }

        /// <summary>
        /// Die Liste wird geleert. Die Elemente werden einfach ausgekettet.
        /// Der GC räumt dann schon auf.
        /// </summary>
        public void Clear()
        {
            _head = null;
        }

        /// <summary>
        /// Gibt es den gesuchten DataObject zumindest ein mal?
        /// </summary>
        /// <param name="value">gesuchter DataObject</param>
        /// <returns></returns>
        public bool Contains(object value)
        {
            int idx = IndexOf(value);
            return (idx >= 0);
        }

        /// <summary>
        /// Der DataObject wird gesucht und dessen Index wird zurückgegeben.
        /// </summary>
        /// <param name="value">gesuchter DataObject</param>
        /// <returns>Index oder -1, falls der DataObject nicht in der Liste ist</returns>
        public int IndexOf(object value)
        {
            int idx = -1;
            int count = 0;

            if (value != null)
            {
                Node run = _head;
                while (run != null && idx == -1)
                {
                    if (value.Equals(run.DataObject))
                    {
                        idx = count;
                    }
                    run = run.Next;
                    count++;
                }
            }
            return idx;
        }

        /// <summary>
        /// DataObject an bestimmter Position in Liste einfügen.
        /// Es ist auch erlaubt, einen DataObject hinter dem letzten Element
        /// (index == count) einzufügen.
        /// </summary>
        /// <param name="index">Einfügeposition</param>
        /// <param name="value">Einzufügender DataObject</param>
        public void Insert(int index, object value)
        {
            if (value == null)
                throw new ArgumentNullException(nameof(value));

            if (index >= 0 && index <= Count)
            {
                Node newNode = new Node(value);

                if (index == 0)
                {
                    newNode.Next = _head;
                    _head = newNode;
                }
                else
                {
                    Node run = _head;
                    Node prev = _head;
                    int count = 0;

                    while (count < index)
                    {
                        count++;
                        prev = run;
                        run = run.Next;
                    }

                    newNode.Next = run;
                    prev.Next = newNode;
                }
            }
        }

        /// <summary>
        /// Wird nicht verwendet ==> Immer false
        /// </summary>
        public bool IsFixedSize
        {
            get { return false; }
        }

        /// <summary>
        /// Wird nicht verwendet ==> Immer false
        /// </summary>
        public bool IsReadOnly
        {
            get { return false; }
        }

        /// <summary>
        /// Ein DataObject wird aus der Liste entfernt, wenn es ihn 
        /// zumindest ein mal gibt.
        /// </summary>
        /// <param name="value">zu entfernender DataObject</param>
        public void Remove(object value)
        {
            int idx = IndexOf(value);

            if (idx >= 0)
            {
                RemoveAt(idx);
            }
        }

        /// <summary>
        /// Der DataObject an der Position Index wird entfernt.
        /// Gibt es die Position nicht, geschieht nichts.
        /// </summary>
        /// <param name="index"></param>
        public void RemoveAt(int index)
        {
            if (index >= 0 && index < Count)
            {
                if (index == 0)
                {
                    _head = _head.Next;
                }
                else
                {
                    Node run = _head;
                    Node prev = _head;
                    int count = 0;

                    while (count < index)
                    {
                        count++;
                        prev = run;
                        run = run.Next;
                    }
                    prev.Next = run.Next;
                }
            }
        }

        /// <summary>
        /// Indexer zum Einfügen und Lesen von Werten an
        /// gesuchten Positionen.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public object this[int index]
        {
            get
            {
                if (index < 0 || index >= Count)
                    throw new IndexOutOfRangeException();

                int count = 0;
                Node run = _head;

                while (count < index)
                {
                    count++;
                    run = run.Next;
                }

                return run.DataObject;
            }
            set
            {
                if (value == null)
                    throw new ArgumentNullException(nameof(value));

                if (index < 0 || index >= Count)
                    throw new IndexOutOfRangeException();

                int count = 0;
                Node run = _head;

                while (count < index)
                {
                    count++;
                    run = run.Next;
                }

                run.DataObject = value;
            }
        }

        #endregion

        #region ICollection Members

        /// <summary>
        /// Werte in ein bereits angelegtes Array kopieren.
        /// Ist das übergebene Array zu klein, oder stimmt der
        /// Startindex nicht, geschieht nichts.
        /// </summary>
        /// <param name="array">Zielarray, existiert bereits</param>
        /// <param name="index">Startindex</param>
        public void CopyTo(Array array, int index)
        {

            if (array != null &&
                array.Length >= Count - index &&
                index >= 0)
            {
                int count = 0;
                int i = 0;

                foreach (var listItem in this)
                {
                    if (count >= index)
                    {
                        array.SetValue(listItem, i++);
                    }
                    count++;
                }
            }
        }

        /// <summary>
        /// Die Anzahl von Elementen in der Liste wird immer 
        /// explizit gezählt und ist nicht redundant gespeichert.
        /// </summary>
        public int Count
        {
            get
            {
                int count = 0;

                Node run = _head;
                while (run != null)
                {
                    count++;
                    run = run.Next;
                }
                return count;
            }
        }

        /// <summary>
        /// Multithreading wird nicht verwendet
        /// </summary>
        public bool IsSynchronized
        {
            get { return false; }
        }

        /// <summary>
        /// Multithreading wird nicht verwendet
        /// </summary>
        public object SyncRoot
        {
            get { return null; }
        }

        #endregion

        public IEnumerator GetEnumerator()
        {
            return new MyListEnumerator(_head);
        }

        public void Sort()
        {
            bool changed;

            do
            {
                changed = false;

                for (int i = 0; i < Count - 1; i++)
                {
                    IComparable firstObject = this[i] as IComparable;
                    IComparable secondObject = this[i + 1] as IComparable;

                    if (firstObject != null &&
                        secondObject != null &&
                        firstObject.CompareTo(secondObject) > 0)
                    {
                        changed = true;
                        this[i+1] = firstObject;
                        this[i] = secondObject;
                    }
                }
            } while (changed);
        }

        public void Sort(IComparer comparer)
        {
            bool changed;

            do
            {
                changed = false;

                for (int i = 0; i < Count - 1; i++)
                {
                    IComparable firstObject = this[i] as IComparable;
                    IComparable secondObject = this[i + 1] as IComparable;

                    if (firstObject != null &&
                        secondObject != null &&
                        comparer.Compare(firstObject, secondObject) > 0)
                    {
                        changed = true;
                        this[i + 1] = firstObject;
                        this[i] = secondObject;
                    }
                }
            } while (changed);
        }
    }
}
