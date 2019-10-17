using System.Collections;
using System;
using System.Collections.Generic;

namespace Lists.ListLogic
{
    internal class MyListEnumerator<T> : IEnumerator<T>
    {
        private Node<T> _head;
        private Node<T> _run;

        public MyListEnumerator(Node<T> head)
        {
            _head = head;
        }

        public T Current
        {
            get
            {
                if (_run == null)
                {
                    throw new InvalidOperationException();
                }
                else
                {
                    return _run.DataObject;
                }
            }
        }

        object IEnumerator.Current => Current;

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public bool MoveNext()
        {
            if (_run == null)
            {
                _run = _head;
            }
            else
            {
                _run = _run.Next;
            }

            return (_run != null);
        }

        public void Reset()
        {
            _run = null;
        }
    }
}