using System;
using System.Collections;
using System.Collections.Generic;

namespace Lists.ListLogic
{
    /// <summary>
    /// Die Liste verwaltet beliebige Elemente und implementiert
    /// das IList-Interface und damit auch ICollection und IEnumerable
    /// </summary>
    public class MyList<T> : IList<T>
    {
        Node<T> _head;

        #region IList Members

        /// <summary>
        /// Ein neues Objekt wird in die Liste am Ende
        /// eingefügt. Etwaige Typinkompatiblitäten beim Vergleich werden
        /// nicht behandelt und lösen eine Exception aus.
        /// </summary>
        /// <param name="value">Einzufügender Datensatz</param>
        public void Add(T value)
        {
            if (value == null)
                throw new ArgumentNullException(nameof(value));

            Node<T> newNode = new Node<T>(value);
            int idx;

            if (_head == null)
            {
                idx = 0;
                _head = newNode;
            }
            else
            {
                idx = 1;
                Node<T> run = _head;
                while (run.Next != null)
                {
                    run = run.Next;
                    idx++;
                }
                run.Next = newNode;
            }
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
        public bool Contains(T value)
        {
            int idx = IndexOf(value);
            return (idx >= 0);
        }

        /// <summary>
        /// Der DataObject wird gesucht und dessen Index wird zurückgegeben.
        /// </summary>
        /// <param name="value">gesuchter DataObject</param>
        /// <returns>Index oder -1, falls der DataObject nicht in der Liste ist</returns>
        public int IndexOf(T value)
        {
            int idx = -1;
            int count = 0;

            if (value != null)
            {
                Node<T> run = _head;
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
        public void Insert(int index, T value)
        {
            if (value == null)
                throw new ArgumentNullException(nameof(value));

            if (index >= 0 && index <= Count)
            {
                Node<T> newNode = new Node<T>(value);

                if (index == 0)
                {
                    newNode.Next = _head;
                    _head = newNode;
                }
                else
                {
                    Node<T> run = _head;
                    Node<T> prev = _head;
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
        /// <returns>True wenn gefunden und gelöscht</returns>
        public bool Remove(T value)
        {
            int idx = IndexOf(value);

            if (idx >= 0)
            {
                RemoveAt(idx);
            }

            return (idx >= 0); 
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
                    Node<T> run = _head;
                    Node<T> prev = _head;
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
        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= Count)
                    throw new IndexOutOfRangeException();

                int count = 0;
                Node<T> run = _head;

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
                Node<T> run = _head;

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
        public void CopyTo(T[] array, int index)
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

                Node<T> run = _head;
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

        public IEnumerator<T> GetEnumerator()
        {
            return new MyListEnumerator<T>(_head);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
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
                        T tmp = this[i + 1];
                        this[i+1] = this[i];
                        this[i] = tmp;
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
                        T tmp = this[i + 1];
                        this[i + 1] = this[i];
                        this[i] = tmp;
                    }
                }
            } while (changed);
        }




    }
}
