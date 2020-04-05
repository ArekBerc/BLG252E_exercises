using System;

namespace assignment1
{
    // Create a class that inherits from Deque and uses a doubly linked list

    //unshift: Adds an item to the front of the deque
    //shift: Removes an item from the front of the deque
    //push: Adds an item to the end of the deque
    //pop: Removes an item from the end of the deque
    //clear: Removes all elements from the deque
    //size: Returns the number of elements


    class dLinkList : Deque
    {

        private int size = 0;
        public override int Size {
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
            public int? data;
            public Node next, prev;

            public Node(int? data,Node prev,Node next)
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
        public override void Clear()
        {
            Node current = head;
            while(current != null)
            {
                Node next = current.next;
                current.prev = current.next = null;
                current.data = null;

            }
            size = 0;
        }

       

        public override int Pop()//remove from the end
        {
            if(tail == null)
            {
                throw new Exception("An end node is required.");
            }
            
            
            int data = tail.data ?? default(int);
            tail = tail.prev;
            size--;

            if (isEmpty()) head = null;

            else
            {
                tail.next = null; //memory collection
            }

            return data;



            
        }

        public override void Push(int item)
        {
            if(isEmpty())
            {
                head = tail = new Node(item, null, null);

            }

            else
            {
                tail.next = new Node(item, tail, null);
                tail = tail.next;
            }
            size++;

        }

        public override int Shift()
        {
            if (head == null)
            {
                
                throw new Exception("A head node is required.");
            }


            int data = head.data ?? default(int);
            head = head.next;
            size--;

            if (isEmpty()) tail = null;

            else
            {
                head.prev = null; //memory collection
            }

            return data;
        }

        public override void Unshift(int item) //Adds an item to the front of the deque
        {
            if (isEmpty())
            {
                head = tail = new Node(item, null, null);
            }

            else
            {
                head.prev = new Node(item, null, head);
                head = head.prev;
            }
            size++;

        }


  

        public override DequeEnumerator GetEnumerator()
        {
            return new DLinkEnumerator(head);
        }

       

    }

    class DLinkEnumerator : DequeEnumerator
    {

        Node current;
        Node head; 

        public DLinkEnumerator(Node head)
        {
            this.current = new Node(null, null, head);
            this.head = current;
        }

        public override int Current
        {
            get   
            {
                return current.data ?? default(int);

            }
        }

        public override bool MoveNext()
        {
            current = current.next;
            return (current != null);
        }

        public override void Reset()
        {
            current = head;
        }
    }
}
