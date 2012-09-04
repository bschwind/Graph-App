using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GraphApp.src
{
    public class Heap<T> where T : IComparable<T>
    {
        private int count;
        private int capacity;
        private bool minHeap;

        private T[] array;

        private Dictionary<T, int> indices;

        public Heap(bool minHeap)
        {
            this.minHeap = minHeap;
            capacity = 10;
            array = new T[capacity];
            indices = new Dictionary<T, int>();
        }

        public void Add(T item)
        {
            if (count >= capacity)
            {
                ExpandArray();
            }

            //Count is the index of the item we are adding
            array[count] = item;
            indices.Add(item, count);
            HeapifyUp(count);

            count++;
        }

        public bool Contains(T item)
        {
            return indices.ContainsKey(item);
        }

        public void Update(T item)
        {
            int index = indices[item];
            if (!NodeInHeap(index))
            {
                return;
            }

            int parent = Parent(index);
            //If we're less than our parent, heapify up
            if (array[index].CompareTo(array[parent]) < 0)
            {
                HeapifyUp(index);
            }
            else
            {
                HeapifyDown(index);
            }
        }

        public int GetCount()
        {
            return count;
        }

        public bool HasNext()
        {
            return count > 0;
        }

        public T Next()
        {
            if (count <= 0)
            {
                throw new Exception("Can't remove from an empty queue");
            }
            
            //Simplified case where there's only 1 element
            if (count == 1)
            {
                count--;
                indices.Remove(array[0]);
                T temp = array[0];
                array[0] = default(T);
                return temp;
            }

            T retVal = array[0];
            indices.Remove(retVal);

            //Find the last item in the queue, place it at the root, then heapify down
            Swap(0, count - 1);
            indices.Remove(array[count - 1]);
            array[count - 1] = default(T);
            count--;
            HeapifyDown(0);

            return retVal;
        }

        private void ExpandArray()
        {
            capacity *= 2;
            T[] newArray = new T[capacity];
            Array.Copy(array, newArray, array.Length);
            array = newArray;
        }

        private int LeftChild(int x)
        {
            return 2 * x + 1;
        }

        private int RightChild(int x)
        {
            return 2 * x + 2;
        }

        private int Parent(int x)
        {
            return (x-1) / 2;
        }

        private void HeapifyUp(int x)
        {
            if (x == 0)
            {
                //Don't heapify root
                return;
            }

            int currentIndex = x;
            int comp = Compare(currentIndex, Parent(currentIndex));
            //Loop while less than our parent, and while we're not at the root position
            while (comp < 0 && currentIndex != 0)
            {
                int parent = Parent(currentIndex);
                //Swap with our parent
                Swap(currentIndex, parent);
                currentIndex = parent;
                comp = Compare(currentIndex, Parent(currentIndex));
            }
        }

        private void HeapifyDown(int x)
        {
            bool leftIsValid = NodeInHeap(LeftChild(x));
            bool rightIsValid = NodeInHeap(RightChild(x));

            while (true)
            {
                //If neither of our children are in the heap's bounds, return
                if (!leftIsValid && !rightIsValid)
                {
                    return;
                }

                int s;
                if (leftIsValid && !rightIsValid)
                {
                    s = LeftChild(x);
                }
                else
                {
                    //s = the child of x with the smaller key
                    s = Compare(LeftChild(x), RightChild(x)) < 0 ? LeftChild(x) : RightChild(x);
                }

                //If we are greater than our child, swap
                if (Compare(x, s) > 0)
                {
                    Swap(x, s);
                    x = s;

                    leftIsValid = NodeInHeap(LeftChild(x));
                    rightIsValid = NodeInHeap(RightChild(x));
                }
                else
                {
                    return;
                }
            }
        }

        //Tells whether the item at index x is part of the heap
        private bool NodeInHeap(int x)
        {
            return (x >= 0 && x < count);
        }

        private void Swap(int x, int y)
        {
            T temp = array[x];
            array[x] = array[y];
            array[y] = temp;

            indices[array[x]] = x;
            indices[array[y]] = y;
        }

        private int Compare(int x, int y)
        {
            //Return the result of the comparison, depending on ordering
            if (minHeap)
            {
                return array[x].CompareTo(array[y]);
            }

            return array[y].CompareTo(array[x]);
        }
    }
}
