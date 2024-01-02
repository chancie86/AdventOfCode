using System.Collections;

namespace Day8
{
    public class Network
        : IEnumerable<Node>
    {
        private readonly Dictionary<string, Node> _nodes;

        public Network()
        {
            _nodes = new Dictionary<string, Node>();
        }

        public void AddLink(string nodeId, string leftId, string rightId)
        {
            if (!_nodes.TryGetValue(nodeId, out var node))
            {
                node = new Node(nodeId);
                _nodes[nodeId] = node;
            }

            if (!_nodes.TryGetValue(leftId, out var leftNode))
            {
                leftNode = new Node(leftId);
                _nodes[leftId] = leftNode;
            }
            
            node.Left = leftNode;

            if (!_nodes.TryGetValue(rightId, out var rightNode))
            {
                rightNode = new Node(rightId);
                _nodes[rightId] = rightNode;
            }

            node.Right = rightNode;
        }

        public Node GetNode(string nodeId)
        {
            return _nodes[nodeId];
        }

        public IEnumerator<Node> GetEnumerator()
        {
            return _nodes.Values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
