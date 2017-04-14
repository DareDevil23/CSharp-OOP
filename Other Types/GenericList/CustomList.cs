using System;
using System.Linq;

namespace GenericList
{
    public class CustomList<T> where T : IComparable<T>
    {
        private const int DefaultCapacity = 16;
        private T[] elements;
        private int currentIndex;

        public CustomList(int capacity = DefaultCapacity)
        {
            this.elements = new T[capacity];
            this.currentIndex = 0;
        }

        public int Count
        {
            get
            {
                return this.currentIndex;
            }
            private set { }
        }

        public T Min()
        {
            EnsureElements();

            T min = this.elements[0];
            for (int i = 0; i < this.currentIndex; i++)
            {
                T currentElement = this.elements[i];
                if (min.CompareTo(currentElement) > 0)
                {
                    min = currentElement;
                }
            }
            return min;
        }
       

        public T Max()
        {
            EnsureElements();

            T max = this.elements[0];
            for (int i = 0; i < this.currentIndex; i++)
            {
                T currentElement = this.elements[i];
                if (max.CompareTo(currentElement) < 0)
                {
                    max = currentElement;
                }
            }
            return max;
        }

        public void Add(T element)
        {
            if (this.currentIndex >= DefaultCapacity)
            {
                this.Resize();
            }

            this.elements[currentIndex] = element;
            this.currentIndex++;
        }

        public T GetElementAt(int index)
        {
            EnsureIndex(index);

            return this.elements[index];
        }


        public void RemoveElementAt(int index)
        {
            EnsureIndex(index);

            T[] newElements = new T[this.elements.Length - 1];
            for (int i = 0, j = 0; i < this.currentIndex; i++)
            {
                if (i != index)
                {
                    newElements[j] = this.elements[i];
                    j++;
                }
            }
            this.elements = newElements;
            this.currentIndex--;
        }

        public void InsertAt(int index, T element)
        {
            if (index < 0 || index > this.currentIndex)
            {
                throw new InvalidOperationException("List is empty. You can insert only on index 0.");
            }
            T[] newElements = new T[this.elements.Length + 1];
            for (int i = 0; i < index; i++)
            {
                newElements[i] = this.elements[i];
            }
            newElements[index] = element;
            int newIndex = index + 1;
            for (int i = index; i < this.currentIndex; i++)
            {
                newElements[newIndex] = this.elements[i];
                newIndex++;
            }

            this.elements = newElements;
            this.currentIndex++;
        }

        public void Clear()
        {
            this.elements = new T[DefaultCapacity];
            this.currentIndex = 0;
        }

        public int FindElementIndex(T element)
        {
            for (int i = 0; i < this.currentIndex; i++)
            {
                T currentElement = this.elements[i];
                if (currentElement.Equals(element))
                {
                    return i;
                }
            }

            return -1;
        }

        public bool HasElement(T element)
        {
            for (int i = 0; i < this.currentIndex; i++)
            {
                if (this.elements[i].Equals(element))
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
                T currentElement = this.elements[i];
                newElements[i] = currentElement;
            }

            this.elements = newElements;
        }

        private void EnsureElements()
        {
            if (this.currentIndex == 0)
            {
                throw new InvalidOperationException("List is empty.");
            }
        }

        private void EnsureIndex(int index)
        {
            if (index < 0 || index >= this.elements.Length)
            {
                throw new IndexOutOfRangeException("Given index is out of list length.");
            }
        }
    }
}
