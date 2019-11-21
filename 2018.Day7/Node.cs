using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Day7
{
    internal class Node
    {
        private static Dictionary<string, Node> nodes;

        internal HashSet<Node> Enables { get; set; }
        internal HashSet<Node> Requires { get; set; }
        internal string Name { get; set; }
        internal int TimeRemaining { get; set; }

        internal static IReadOnlyDictionary<string, Node> NodeList { get { return nodes; } }

        static Node()
        {
            nodes = new Dictionary<string, Node>();
        }

        private Node(string s)
        {
            Debug.Assert(s.Length == 1);
            this.Name = s;
            Enables = new HashSet<Node>();
            Requires = new HashSet<Node>();
            this.TimeRemaining = 60 + (s[0] - 'A' + 1);
        }

        internal static Node GetNode(string s)
        {
            lock (nodes)
            {
                if (!nodes.ContainsKey(s))
                {
                    nodes[s] = new Node(s);
                }
            }
            return nodes[s];
        }

        internal static void AddDependency(string required, string enabled)
        {
            var req = GetNode(required);
            var en = GetNode(enabled);
            req.Enables.Add(en);
            en.Requires.Add(req);
        }

        public override bool Equals(object obj)
        {
            var other = obj as Node;
            if (other == null)
            {
                return false;
            }
            return this.Name == other.Name;
        }

        public override int GetHashCode()
        {
            return this.Name.GetHashCode();
        }

        public override string ToString()
        {
            return $"Node {this.Name} ({this.TimeRemaining} seconds) requires {string.Join(',', this.Requires.Select(n => n.Name))}";
        }
    }
}
