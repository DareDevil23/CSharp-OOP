using System;
using System.Linq;

namespace CustomStack
{
    public class CustomStack<T> where T : IComparable<T> 
    {
        private const int DefaultCapacity = 16;
        private T[] elements;
        private int currentIndex;

        public CustomStack(int capacity = DefaultCapacity) 
        {
            this.elements = new T[capacity];
            this.currentIndex = 0;
        }

        public int Count
        {
            get{ return this.currentIndex; }
        }

        public bool IsEmpty
        {
            get
            {
                return this.currentIndex == 0;
            }
        }

        public void Push(T element)
        {
            if (this.currentIndex >= this.elements.Length)
            {
                this.Resize();
            }
            this.elements[this.currentIndex] = element;
            this.currentIndex++;
        }

        public T Pop()
        {
            if (this.currentIndex == 0)
            {
                throw new InvalidOperationException("Stack is empty");
            }
            T topElement = this.elements[this.currentIndex - 1]; 
            this.elements[this.currentIndex - 1] = default(T);            
            this.currentIndex--;

            return topElement;
        }
        public T Min()
        {
            T minElement = this.elements[0];
            for (int i = 0; i < this.currentIndex; i++)
            {
                if (this.elements[i].CompareTo(minElement) < 0)
                {
                    minElement = this.elements[i];
                }
            }

            return minElement;
        }

        public T Max()
        {
            T maxElement = this.elements[0];
            for (int i = 0; i < this.currentIndex; i++)
            {
                if (maxElement.CompareTo(this.elements[i]) < 0)
                {
                    maxElement = this.elements[i];
                }
            }

            return maxElement;
        }

        public void Clear()
        {
            for (int i = 0; i < this.currentIndex; i++)
            {
                this.elements[i] = default(T);
            }
            this.currentIndex = 0; 
        }

        public bool Contains(T element)
        {
            for (int i = 0; i < this.currentIndex; i++)
            {
                T currentElement = this.elements[i];
                if (currentElement.Equals(element))
                {
                    return true;
                }
            }

            return false;
        }

        public override string ToString()
        {
            return string.Join(", ", this.elements.Take(this.currentIndex)); 
        }

        private void Resize()
        {
            T[] newElements = new T[this.elements.Length * 2]; 
            for (int i = 0; i < this.currentIndex; i++)
            {
                newElements[i] = this.elements[i];
            }

            this.elements = newElements;
        }
    }
}
