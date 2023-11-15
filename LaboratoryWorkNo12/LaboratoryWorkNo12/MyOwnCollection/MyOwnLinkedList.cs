using System;
using System.Collections;
using System.Collections.Generic;


namespace LaboratoryWorkNo12
{
    public class MyOwnLinkedList<T> : IEnumerable<T>, ICollection<T>, ICloneable
    {
        private Node<T> _firstNode;
        private Node<T> _lastNode;
        private int _count = 0;

        public Node<T> First => _firstNode;
        public Node<T> Last => _lastNode;

        public int Count => _count;
        public bool IsReadOnly => false;

        public virtual T this[int index]
        {
            get => GetByIndex(index).Value;
            set => GetByIndex(index).Value = value;
        }

        public Node<T> GetByIndex(int index)
        {
            if (index < 0 || index >= _count)
            {
                throw new IndexOutOfRangeException();
            }

            var pointer = _firstNode;
            while (--index != -1)
            {
                pointer = pointer.Next;
            }

            return pointer;
        }

        public virtual void Add(T item)
        {
            _count += 1;

            if (_firstNode == null)
            {
                _firstNode = new Node<T>(item);
                _lastNode = _firstNode;
                return;
            }

            _lastNode.Next = new Node<T>(item);
            _lastNode = _lastNode.Next;
        }

        public void Clear()
        {
            _firstNode = null;
            _lastNode = null;

            _count = 0;
        }

        public bool Contains(T item)
        {
            var pointer = _firstNode;
            while (pointer != null)
            {
                
                if (pointer.Value.Equals(item))
                {
                    return true;
                }

                pointer = pointer.Next;
            }

            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            int i = arrayIndex;

            foreach (T element in this)
            {
                if (i == array.Length)
                {
                    break;
                }

                array[i++] = element;
            }
        }


        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        public IEnumerator<T> GetEnumerator()
        {
            var pointer = _firstNode;
            while (pointer != null)
            {
                yield return pointer.Value;
                pointer = pointer.Next;
            }
        }

        public virtual bool Remove(T item)
        {
            var pointer = _firstNode;
            var previous = pointer;
            pointer = pointer.Next;

            if (previous.Value.Equals(item))
            {
                _firstNode = pointer;

                _count -= 1;
                return true;
            }

            while (pointer != null)
            {
                if (pointer.Value.Equals(item))
                {
                    previous.Next = pointer.Next;

                    _count -= 1;
                    return true;
                }

                pointer = pointer.Next;
            }

            return false;
        }

        public object Clone()
        {
            var clonedList = new MyOwnLinkedList<T>();
            foreach (var element in this)
            {
                var clonableElement = (ICloneable) element;
                var clonedElement = (T) clonableElement.Clone();

                clonedList.Add(clonedElement);
            }

            return clonedList;
        }

        public object ShallowCopy()
        {
            var copiedList = new MyOwnLinkedList<T>();
            foreach (var element in this)
            {
                copiedList.Add(element);
            }

            return copiedList;
        }
    }
}
