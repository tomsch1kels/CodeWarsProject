// https://www.codewars.com/kata/55cacc3039607536c6000081
// 6 kyu

internal sealed partial class Node()
{
    private Node? next;

    public static Node InsertNth(Node head, int index, int data)
    {
        if (head == null)
        {
            return new Node();
        }

        ArgumentOutOfRangeException.ThrowIfNegative(index);
        Node? current = head;
        Node? previous = null;
        for (int i = 0; i < index; i++)
        {
            previous = current ?? throw new InvalidOperationException("The object is in an invalid state.");
            current = current.next;
        }

        Node newNode = new Node()
        {
            next = current,
        };
        if (previous != null)
        {
            previous.next = newNode;
            return head;
        }
        else
        {
            return newNode;
        }
    }

    internal static Node BuildOneTwoThree()
    {
        Node head = new Node();
        Node n2 = new Node();
        head.next = n2;
        Node n3 = new Node();
        n2.next = n3;
        return head;
    }
}