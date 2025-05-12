using System;
using System.Collections;
using System.Collections.Generic;

namespace BST_WinForms
{
    public class CustomLinkedListNode<T>
    {
        public T Value;
        public CustomLinkedListNode<T> Next;
        public CustomLinkedListNode(T value) { Value = value; Next = null; }
    }

    public class CustomLinkedList<T> : IEnumerable<T>
    {
        public CustomLinkedListNode<T> Head;

        public void AddLast(T value)
        {
            var newNode = new CustomLinkedListNode<T>(value);
            if (Head == null)
                Head = newNode;
            else
            {
                var cur = Head;
                while (cur.Next != null) cur = cur.Next;
                cur.Next = newNode;
            }
        }

        public bool Remove(T value)
        {
            if (Head == null) return false;
            if (Head.Value.Equals(value))
            {
                Head = Head.Next;
                return true;
            }
            var cur = Head;
            while (cur.Next != null && !cur.Next.Value.Equals(value))
                cur = cur.Next;
            if (cur.Next == null) return false;
            cur.Next = cur.Next.Next;
            return true;
        }

        public bool RemoveLast(out T removedValue)
        {
            removedValue = default;
            if (Head == null) return false;
            if (Head.Next == null)
            {
                removedValue = Head.Value;
                Head = null;
                return true;
            }
            var cur = Head;
            while (cur.Next.Next != null) cur = cur.Next;
            removedValue = cur.Next.Value;
            cur.Next = null;
            return true;
        }

        // --- Burayı ekliyoruz ---
        public bool Contains(T value)
        {
            var cur = Head;
            while (cur != null)
            {
                if (cur.Value.Equals(value)) return true;
                cur = cur.Next;
            }
            return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var cur = Head;
            while (cur != null)
            {
                yield return cur.Value;
                cur = cur.Next;
            }
        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
