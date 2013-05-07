using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;

namespace AlgorithmsJournal.Graphs
{
    public class DigraphClass
    {
        public void PrintDigraph(Digraph graph)
        {
            for (int i = 0; i < graph.Vertices; i++)
            {
                foreach (int w in graph.Adjacent(i))
                {
                    Console.WriteLine(i + " -> " + w);
                }
            }
        }
    }

    public class DirectedDepthFirstOrder
    {
        private bool[] _marked;
        private Stack<int> _reversePost;
        public DirectedDepthFirstOrder(Digraph graph, int vertex)
        {
            _marked = new bool[vertex];
            _reversePost = new Stack<int>();

            for (int i = 0; i < graph.Vertices; i++)
            {
                if (! _marked[i])
                {
                    DepthFirstSearch(graph, vertex);
                }
            }

        }

        private void DepthFirstSearch(Digraph graph, int vertex)
        {
            _marked[vertex] = true;
            foreach (var i in graph.Adjacent(vertex))
            {

                if (_marked[i])
                {
                    DepthFirstSearch(graph,i);
                }
            }
            _reversePost.Push(vertex);
        }

        public IEnumerable<int> ReversePost()
        {
            return _reversePost;
        }
    }

    public class DirectedBreadthFirstSearch
    {
        private readonly bool[] _marked;
        private readonly Queue<int> _queue;

        public DirectedBreadthFirstSearch(Digraph graph, int startVertex)
        {
            _marked = new bool[graph.Vertices];
            _queue = new Queue<int>();
        }

        private void BreadthFirstSearch(Digraph graph, int startVertex)
        {
            _queue.Enqueue(startVertex);
            _marked[startVertex] = true;

            while (_queue.Count > 0)
            {
                int lastVertexAdded = _queue.Dequeue();
                foreach (int i in graph.Adjacent(lastVertexAdded))
                {
                    _queue.Enqueue(i);
                    _marked[i] = true;
                }
            }
        }
    }

    public class DirectedDepthFirstSearch
    {
        private readonly bool[] _marked; //Set to true if from path startVertex

        public DirectedDepthFirstSearch(Digraph graph, int startVertex)
        {
            _marked = new bool[graph.Vertices];
            DepthFirstSearch(graph, startVertex);
        }

        private void DepthFirstSearch(Digraph graph, int startVertex)
        {
            _marked[startVertex] = true;
            foreach (int w in graph.Adjacent(startVertex))
            {
                if (! _marked[w])
                {
                    DepthFirstSearch(graph, w);
                }
            }
        }

        public bool Visited(int vertex)
        {
            return _marked[vertex];
        }
    }

    public class Digraph
    {
        private readonly Collection<int>[] _adj;

        public Digraph(int vertices)
        {
            vertices = vertices;
            _adj = new Collection<int>[vertices];
            for (int i = 0; i < vertices; i++)
            {
                _adj[i] = new Collection<int>();
            }
            //Create an empth digraph with a number of vertices
        }

        public Digraph(Stream instream)
        {
        }


        public int Vertices { get; set; }

        public int Edges { get; set; }

        public void AddEdge(int fromVertex, int toVertex)
        {
            _adj[fromVertex].Add(toVertex);
        }

        public IEnumerable<int> Adjacent(int vertex)
        {
            return _adj[vertex];
        }

        public Digraph Reverse()
        {
            throw new NotImplementedException();
        }
    }
}