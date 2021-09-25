using System;
using System.Collections;
using System.Collections.Generic;

namespace HomeTaskGenerics.UserCollection
{
    #region Вузол однозв'язного списку
    public class Node<T>
    {
        public Node(T value)
        {
            Value = value;
        }

        public T Value 
        {
            get;
            internal set;
        }
        public Node<T> Next
        {
            get;
            internal set;
        }

        //public Node<T> Previous
        //{
        //    get;
        //    internal set;
        //}
    }
    #endregion

    public class UserCollection<T> : IEnumerable<T>, IEnumerator<T>
    {
        public Node<T> _head;
        public Node<T> _tail;
        public int Count
        {
            get;
            private set;
        }

        #region Метод Add добавляє елемент в кінець зв`язного списку
        public void Add(T value)
        {
            Node<T> node = new Node<T>(value);

            if (_head == null)
            {
                _head = node;
                _tail = node;
            }

            else
            {
                _tail.Next = node;
                _tail = node;
            }
            Count++;
        }
        #endregion

        #region Метод Remove видаляє із списку вказаний елемент.
        public bool Remove(T item)
        {
            Node<T> previous = null;
            Node<T> current = _head;

            while (current != null)
            {
                if (current.Value.Equals(item)) 
                {

                    if (previous != null)
                    {
                        previous.Next = current.Next;
                        if (current.Next == null)
                        {
                            _tail = previous;
                        }
                    }
                    else
                    {
                        _head = _head.Next;
                        if (_head == null)
                        {
                            _tail = null;
                        }
                    }
                    Count--;
                    return true;
                }
                previous = current;
                current = current.Next;
            }
            return false;
        }
        #endregion

        #region Метод Clear очищає список

        public void Clear()
        {
            _head = null;
            _tail = null;
            Count = 0;
        }


        #endregion

        #region Метод Contains повертає значення true, якщо елемент належить списку
        public bool Contains(T item)
        {
            Node<T> current = _head;

            while (current != null)
            {
                if (current.Value.Equals(item))
                {
                    return true;
                }

                current = current.Next;
            }
            return false;
        }
        #endregion

        #region Метод CopyTo копіює вміст списку в массив
        public void CopyTo(T[] array, int arrayIndex)
        {
            Node<T> current = _head;

            while (current != null)
            {
                array[arrayIndex++] = current.Value;
                current = current.Next;
            }
        }
        #endregion

        T IEnumerator<T>.Current
        {
            get { return _tail.Value; }
        }

        public object Current => throw new NotImplementedException();

        public IEnumerator<T> GetEnumerator()
        {
            Node<T> current = _head;

            while (current != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<T>)this).GetEnumerator();
        }

        public bool MoveNext()
        {
            if (_tail.Next!=null)
            {
                return true;
            }
            return false;
        }

        public void Reset()
        {
            Dispose();
        }

        public void Dispose()
        {
            _head=_tail;
        }
    }
}
