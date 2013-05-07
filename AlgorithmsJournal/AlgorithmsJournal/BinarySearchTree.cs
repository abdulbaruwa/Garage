using System;
using System.Collections.Generic;

namespace AlgorithmsJournal
{
    public class BinarySearchTree<TNodeKey, TNodeValue> where TNodeKey : IComparable
    {
        private class Node
        {
            private TNodeKey _nodeKey;
            private TNodeValue _nodeValue;
            private Node _leftNode;
            private Node _rightNode;
            public Node(TNodeKey nodeKey, TNodeValue nodeValue)
            {
                _nodeKey = nodeKey;
                _nodeValue = nodeValue;
            }

            public TNodeValue NodeValue { get; set; }

            public TNodeKey NodeKey
            {
                get { return _nodeKey; }
            }
            public Node RightNode { get; set; }
            public Node LeftNode { get;  set; }
        }

        public void Put(TNodeKey key, TNodeValue value)
        {
            root = Put(root, key, value);
        }

        private Node Put(Node node, TNodeKey key, TNodeValue value)
        {
            if(node == null) return new Node(key,value);
            int cmp = key.CompareTo(node.NodeKey);
            
            if (cmp > 0)
            {
                node.RightNode  = Put(node.RightNode, key, value);
            }
            else if (cmp < 0)
            {
                node.LeftNode = Put(node.RightNode, key, value);
            }
            else if (cmp == 0)
            {
                node.NodeValue = value;
            }
            return node;
        }

        public TNodeValue Get(TNodeKey key)
        {
            Node rootNode = root;
            while (rootNode != null)
            {
                int cmp = key.CompareTo(rootNode.NodeKey);
                if (cmp > 0)
                {
                    rootNode = rootNode.RightNode;
                }
                else if (cmp < 0)
                {
                    rootNode = rootNode.LeftNode;
                }
                else if (cmp == 0) return rootNode.NodeValue;
            }
            return null;
        }


        public IEnumerator<TNodeKey> Enumerator()
        {
            throw new NotImplementedException();
        }
    }
}