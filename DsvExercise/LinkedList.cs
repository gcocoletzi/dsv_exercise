namespace DsvExercise
{
    public interface ISinglyNode<T>
    {
        T Value { get; set; }
        Node<T>? Next { get; set; }
    }

    public interface IDoublyNode<T>
    {
        T Value { get; set; }
        Node<T>? Next { get; set; }
        Node<T>? Prev { get; set; }
    }

    public class Node<T> : ISinglyNode<T>, IDoublyNode<T>
    {
        public Node(T _value)
        {
            this.Value = _value;
            this.Next = null;
        }

        public T Value { get; set; }
        public Node<T>? Next { get; set; }
        public Node<T>? Prev { get; set; }
    }


    /*
     * Problem 2: Linked List Operations
     * Implement a basic linked list in C# and write functions to perform common operations like adding a node, deleting a node, and finding a node.
     */

    public class LinkedList<T>
    {
        public Node<T> Head { get; private set; }
        public Node<T> Tail { get; private set; }
        public int Length { get; private set; }

        public LinkedList(Node<T> _node)
        {
            Head = _node;
            Tail = _node;
            Length = 1; 
        }

        public LinkedList(T value)
        {
            Head = new Node<T>(value);
            Tail = Head;
            Length = 1;
        }

        public void PrintList()
        {
            var listToPrint = new List<T>();
            var currentNode = Head;

            while (currentNode != null)
            {
                listToPrint.Add(currentNode.Value);
                currentNode = currentNode.Next;
            }
            foreach (var item in listToPrint)
            {
                Console.WriteLine(item);
            }
        }

        public LinkedList<T> Append(T _value)
        {
            ISinglyNode<T> newNode = new Node<T>(_value);
            Tail.Next = (Node<T>?)newNode;
            Length++;
            return this;
        }

        public LinkedList<T> Prepend(T _value)
        {
            ISinglyNode<T> newNode = new Node<T>(_value);
            newNode.Next = Head;
            Head = (Node<T>)newNode;
            Length++;
            return this;
        }

        public LinkedList<T> Insert(int index, T _value)
        {
            if (index >= Length)
            {
                return this.Append(_value);
            }

            ISinglyNode<T> newNode = new Node<T>(_value);
            var leader = traverseToIndex(index - 1);
            var holdingPointer = leader.Next;
            leader.Next = (Node<T>?)newNode;
            newNode.Next = holdingPointer;
            Length++;

            return this;
        }

        public LinkedList<T> Delete(int index)
        {
            if (index < 0 || index >= Length)
            {
                return this;
            }

            if(index == 0)
            {
                Head = Head.Next;
                Length--;
                return this;
            }

            var leader = traverseToIndex(index - 1);
            var nodeToDelete = leader?.Next;

            if (nodeToDelete != null)
            {
                leader.Next = nodeToDelete.Next;

                if(nodeToDelete == Tail)
                {
                    Tail = leader;
                }

                Length--;
            }

            return this;
        }

        public Node<T>? Find(T value)
        {
            var currentNode = Head;

            while (currentNode != null)
            {
                if(currentNode.Value.Equals(value))
                {
                    return currentNode;
                }

                currentNode = currentNode.Next;
            }

            return null;
        }

        private Node<T>? traverseToIndex(int index)
        {
            var counter = 0;
            var currentNode = Head;
            while (counter != index)
            {
                currentNode = currentNode?.Next;
                counter++;
            }

            return currentNode;
        }
    }
}
