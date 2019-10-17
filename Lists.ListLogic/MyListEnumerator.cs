using System.Collections;
using System;

namespace Lists.ListLogic
{
    internal class MyListEnumerator : IEnumerator
    {
        private Node _head;
        private Node _run;

        public MyListEnumerator(Node head)
        {
            _head = head;
        }

        public object Current
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