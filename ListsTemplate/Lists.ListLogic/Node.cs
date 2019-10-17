using System;
using System.Collections.Generic;
using System.Text;

namespace Lists.ListLogic
{
    public class Node
    {
        public Node(object dataObject)
        {
            DataObject = dataObject;
        }

        public Node Next { get; set; }

        public Object DataObject { get; private set; }
    }
}
