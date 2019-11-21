using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Day9
{
    internal class Deque<T>
    {
        private class Node
        {
            internal Node Left;
            internal Node Right;
            internal T Value;

            public override string ToString()
            {
                var left = "HEAD";
                if (Left != null)
                {
                    left = Left.Value.ToString();
                }
                var right = "TAIL";
                if (Right != null)
                {
                    right = Right.Value.ToString();
                }
                return $"({left}) *{Value}* ({right})";
            }
        }

        private Node head;
        private Node tail;

        internal T Pop()
        {
            var item = head.Value;
            head.Right.Left = null;
            head = head.Right;
            return item;
        }

        internal void Push(T item)
        {
            var n = new Node { Value = item };
            if (head == null)
            {
                Debug.Assert(tail == null);
                head = n;
                tail = n;
            }
            else
            {
                n.Right = head;
                head.Left = n;
                head = n;
            }
        }

        internal void Enqueue(T item)
        {
            var n = new Node { Value = item };
            if (head == null)
            {
                Debug.Assert(tail == null);
                head = n;
                tail = n;
            }
            else
            {
                n.Left = tail;
                tail.Right = n;
                tail = n;
            }
        }

        internal T Dequeue()
        {
            var item = tail.Value;
            tail.Left.Right = null;
            tail = tail.Left;
            return item;
        }

        internal void Rotate(int count)
        {
            if (object.ReferenceEquals(head, tail))
            {
                return;
            }
            if (count > 0)
            {
                while (count-- > 0)
                {
                    var newHead = head.Right;
                    tail.Right = head;
                    head.Left = tail;
                    head.Right = null;
                    newHead.Left = null;
                    tail = head;
                    head = newHead;
                }
            }
            else
            {
                while (count++ < 0)
                {
                    var newTail = tail.Left;
                    head.Left = tail;
                    tail.Right = head;
                    tail.Left = null;
                    newTail.Right = null;
                    head = tail;
                    tail = newTail;
                }
            }
        }

        public override string ToString()
        {
            var cur = head;
            var sb = new StringBuilder();
            sb.Append("HEAD,");
            while (cur != null)
            {
                sb.Append($"{cur.Value},");
                cur = cur.Right;
            }
            sb.Append("TAIL");
            return sb.ToString();
        }
    }
}
