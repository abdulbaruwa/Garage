using System;

namespace AlgorithmsJournal
{
    //public struct SymbolTables
    //{
    //    //Think dictionaries
 

    //}



    public class BinarySearchTree<TKey, TValue> where TKey : System.IComparable<TKey>
    {

        private static Node root;

        private class Node
        {
            private readonly TKey _key;
            private TValue _val;
            private Node _leftNode;
            private Node _rightNode;

            public Node(TKey nodeKey, TValue nodeValue)
            {
                _key = nodeKey;
                _val = nodeValue;
            }


            public Node Put(Node rootNode, TKey key, TValue value)
            {
                if (rootNode == null) return new Node(key, value);
                int cmp = key.CompareTo(rootNode._key);

                if (cmp < 0)
                {
                    rootNode._leftNode = Put(rootNode._leftNode, key, value);
                }
                else if (cmp > 0)
                {
                    rootNode._rightNode = Put(rootNode._rightNode, key, value);
                }
                else
                {
                    rootNode._val = value;
                }
                return rootNode;
            }

            public TValue Get(TKey key)
            {
                Node x = root;
                while (x != null)
                {
                    int cmp = key.CompareTo(x._key);
                    if (cmp < 0) x = x._leftNode;
                    else if (cmp > 0) x = x._rightNode;
                    else if (cmp == 0) return x._val;
                }
                return null;
            }

            public void Delete(TKey key)
            {
                
            }
        }
    }

}