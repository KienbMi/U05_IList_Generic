using System;
using System.Collections.Generic;
using System.Text;

namespace Lists.ListLogic
{
    public class Node<T>
    {
        public Node(T dataObject)
        {
            DataObject = dataObject;
        }

        public Node<T> Next { get; set; }

        public T DataObject { get; set; }
    }
}
