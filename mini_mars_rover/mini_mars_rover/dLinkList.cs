using System;
using System.Collections.Generic;
using System.Text;

namespace mini_mars_rover
{
    class dLinkList
    {




        private int size = 0;
        public Node current;
        bool currentset = false;
        public int Size
        {
            get
            {
                return size;
            }

            set
            {

            }
        }


        private Node head = null;
        private Node tail = null;

        public class Node
        {
            public string data;
            public Node next, prev;
            


            public Node(string data, Node prev, Node next)
            {
                this.data = data;
                this.prev = prev;
                this.next = next;
            }

        }

        public bool isEmpty()
        {
            return size == 0;
        }
        public void Clear()
        {
            Node current = head;
            while (current != null)
            {
                Node next = current.next;
                current.prev = current.next = null;
                current.data = null;
                current = next;

            }
            size = 0;
        }



        public void addB(string item)
        {
            if (isEmpty())
            {
                head = tail = new Node(item, null, null);
            }

            else
            {
                tail.next = new Node(item, tail, null);
                tail = tail.next;
                tail.next = head;
                head.prev = tail;
            }
            size++;

        }

            

        public void addF(string item) //Adds an item to the front of the deque
        {
            if (isEmpty())
            {
                head = tail = new Node(item, null, null);

            }

            else
            {
                head.prev = new Node(item, null, head);
                head = head.prev;
                tail.next = head;
                head.prev = tail;
            }
            size++;

        }




        public void moveCurr2Next()
        {
            if (currentset == true)
            {
                current = current.next;
            }
            else
            {
                return;
            }
        }


        public void moveCurr2Prev()
        {
            if (currentset == true)
            {
                current = current.prev;
            }
            else
            {
                return;
            }

        }
        public void setCurrent(string data)
        {
            current = head;
            int i = 0;
            while (current.data != data )
            {
                current = current.next;
                i++;
                if (i == size)
                {
                    Console.WriteLine("There are no current node");
                    current = null;
                    return;
                }

            }
            currentset = true;
            
        }

    }


}


