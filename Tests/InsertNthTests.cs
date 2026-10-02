// https://www.codewars.com/kata/55cacc3039607536c6000081
// 6 kyu

[TestFixture]
internal sealed class InsertNthTests()
{
    [Test]
    public void DummyTest()
    {
        int a = 1;
        _ = 2 * a;
    }

    // [Test]
    // [Description("should be able to handle an empty list.")]
    // [Order(1)]
    // public void EmptyTest()
    // {
    //   Assert.That(Node.InsertNth(null, 0, 12).Data, Is.EqualTo(12), "should be able to insert a node on an empty/null list.");
    //   Assert.That(Node.InsertNth(null, 0, 12).Next, Is.Null, "value at index 1 should be null.");
    // }

    // [Test]
    // [Description("should be able to insert a new node at the head of a list.")]
    // [Order(2)]
    // public void TestIndex0()
    // {
    //   var expectedData = 23;
    //   Assert.That(Node.InsertNth(Node.BuildOneTwoThree(), 0, 23).Data, Is.EqualTo(expectedData), "should be able to insert new node at head of list.");
    //   Assert.That(Node.InsertNth(Node.BuildOneTwoThree(), 0, 23).Next.Data, Is.EqualTo(1), "value for node at index 1 should be 1.");
    //   Assert.That(Node.InsertNth(Node.BuildOneTwoThree(), 0, 23).Next.Next.Data, Is.EqualTo(2), "value for node at index 2 should be 2.");
    //   Assert.That(Node.InsertNth(Node.BuildOneTwoThree(), 0, 23).Next.Next.Next.Data, Is.EqualTo(3), "value for node at index 3 should be 3.");
    //   Assert.That(Node.InsertNth(Node.BuildOneTwoThree(), 0, 23).Next.Next.Next.Next, Is.Null, "value at index 4 should be null.");
    // }

    // [Test]
    // [Description("should be able to insert a new node at index 1 of a list.")]
    // [Order(3)]
    // public void TestIndex1()
    // {
    //   Assert.That(Node.InsertNth(Node.BuildOneTwoThree(), 1, 23).Data, Is.EqualTo(1), "value for node at index 0 should remain unchanged.");
    //   Assert.That(Node.InsertNth(Node.BuildOneTwoThree(), 1, 23).Next.Data, Is.EqualTo(23), "value for node at index 1 should be 23.");
    //   Assert.That(Node.InsertNth(Node.BuildOneTwoThree(), 1, 23).Next.Next.Data, Is.EqualTo(2), "value for node at index 2 should be 2.");
    //   Assert.That(Node.InsertNth(Node.BuildOneTwoThree(), 1, 23).Next.Next.Next.Data, Is.EqualTo(3), "value for node at index 3 should be 3.");
    //   Assert.That(Node.InsertNth(Node.BuildOneTwoThree(), 1, 23).Next.Next.Next.Next, Is.Null, "value at index 4 should be null.");
    // }

    // [Test]
    // [Description("should be able to insert a new node at index 2 of a list.")]
    // [Order(4)]
    // public void TestIndex2()
    // {
    //   Assert.That(Node.InsertNth(Node.BuildOneTwoThree(), 2, 23).Data, Is.EqualTo(1), "value for node at index 0 should remain unchanged.");
    //   Assert.That(Node.InsertNth(Node.BuildOneTwoThree(), 2, 23).Next.Data, Is.EqualTo(2), "value for node at index 1 should remain unchanged.");
    //   Assert.That(Node.InsertNth(Node.BuildOneTwoThree(), 2, 23).Next.Next.Data, Is.EqualTo(23), "value for node at index 2 should be 23.");
    //   Assert.That(Node.InsertNth(Node.BuildOneTwoThree(), 2, 23).Next.Next.Next.Data, Is.EqualTo(3), "value for node at index 3 should be 3.");
    //   Assert.That(Node.InsertNth(Node.BuildOneTwoThree(), 2, 23).Next.Next.Next.Next, Is.Null, "value at index 4 should be null.");
    // }

    // [Test]
    // [Description("should be able to insert a new node at the tail of a list.")]
    // [Order(5)]
    // public void TestIndex3()
    // {
    //   Assert.That(Node.InsertNth(Node.BuildOneTwoThree(), 3, 23).Data, Is.EqualTo(1), "head should remain unchanged after inserting new node at tail");
    //   Assert.That(Node.InsertNth(Node.BuildOneTwoThree(), 3, 23).Next.Data, Is.EqualTo(2), "value at index 1 should remain unchanged after inserting new node at tail");
    //   Assert.That(Node.InsertNth(Node.BuildOneTwoThree(), 3, 23).Next.Next.Data, Is.EqualTo(3), "value at index 2 should remain unchanged after inserting new node at tail");
    //   Assert.That(Node.InsertNth(Node.BuildOneTwoThree(), 3, 23).Next.Next.Next.Data, Is.EqualTo(23), "value for node at index 3 should be 23.");
    //   Assert.That(Node.InsertNth(Node.BuildOneTwoThree(), 3, 23).Next.Next.Next.Next, Is.Null, "value at index 4 should be null.");
    // }

    // [Test]
    // [Description("should throw ArgumentOutOfRangeException if index is out of range")]
    // [Order(6)]
    // public void ExceptionTest()
    // {
    //   Assert.Throws<ArgumentOutOfRangeException>(() => Node.InsertNth(Node.BuildOneTwoThree(), 4, 23), "Invalid index value should throw ArugmentException");
    //   Assert.Throws<ArgumentOutOfRangeException>(() => Node.InsertNth(Node.BuildOneTwoThree(), -4, 23), "Invalid index value should throw ArugmentException");
    // }
}