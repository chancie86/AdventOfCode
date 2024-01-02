namespace Day8
{
    public class Node
    {
        public Node(string id)
        {
            Id = id;
        }

        public string Id { get; }

        public Node Left { get; set; }
        public Node Right { get; set; }
    }
}
