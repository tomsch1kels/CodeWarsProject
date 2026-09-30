// https://www.codewars.com/kata/55cacc3039607536c6000081
// 6 kyu

using NUnit.Framework;
using System;
using System.Linq;
using System.Collections.Generic;

internal partial class Node(int data)
{
    public int Data = data;
    public Node Next;

    public static Node InsertNth(Node head, int index, int data)
    {
        if (head == null) return new Node(data);
        ArgumentOutOfRangeException.ThrowIfNegative(index);
        Node current = head;
        Node previous = null;
        for (int i = 0; i < index; i++)
        {
            previous = current ?? throw new ArgumentOutOfRangeException();
            current = current.Next;
        }
        Node newNode = new Node(data)
        {
            Next = current
        };
        if (previous != null)
        {
            previous.Next = newNode;
            return head;
        }
        else
        {
            return newNode;
        }
    }

    internal static Node BuildOneTwoThree()
    {
        Node head = new Node(1);
        Node n2 = new Node(2);
        head.Next = n2;
        Node n3 = new Node(3);
        n2.Next = n3;
        return head;
    }
}