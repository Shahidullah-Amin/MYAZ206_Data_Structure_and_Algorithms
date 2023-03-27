using LinkedList;

namespace LinkedListTests
{
    public class LinkedList_Tests
    {
        [Fact]
        public void AddFirst_Test()
        {
            var list = new LinkedList.LinkedList<string>();

            list.AddFirst("Shahidullah Amin");
            list.AddFirst("Mustafa");
            list.AddFirst("Emre");
            list.AddFirst("Omar");


            Assert.Equal(list.Head.Value, "Omar");
            Assert.Equal(list.Head.Next.Value, "Emre");
            Assert.Equal(list.Head.Next.Next.Value, "Mustafa");
            Assert.Equal(list.Head.Next.Next.Next.Value, "Shahidullah Amin");

        }

        
        [Fact]
        public void AddLast_Test()
        {
            var list = new LinkedList.LinkedList<string>();

            list.AddLast("Shahidullah Amin");
            list.AddLast("Hemad");
            list.AddLast("Maher");
            list.AddLast("Bashir");

            Assert.Equal(list.Head.Value, "Shahidullah Amin");
            Assert.Equal(list.Head.Next.Value, "Hemad");
            Assert.Equal(list.Head.Next.Next.Value, "Maher");
            Assert.Equal(list.Head.Next.Next.Next.Value, "Bashir");
        }
        [Fact]
        public void AddBefore_Test()
        {
            var list = new LinkedList.LinkedList<string>();

            list.AddLast("Shahidullah Amin");
            list.AddLast("Hemad");
            list.AddLast("Maher");

            list.AddBefore("Hemad", "Abdullah");
            list.AddBefore("Abdullah", "Rabiullah");

            Assert.Equal(list.Head.Value, "Shahidullah Amin");
            Assert.Equal(list.Head.Next.Value, "Rabiullah");
            Assert.Equal(list.Head.Next.Next.Value, "Abdullah");
            Assert.Equal(list.Head.Next.Next.Next.Value, "Hemad");
            Assert.Equal(list.Head.Next.Next.Next.Next.Value, "Maher");
        }
    }
}