using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;

namespace AlgorithmsJournal.Graphs
{
    public class GraphSearcher
    {
        private int[] _edgeTo;
        private bool[] _visited;
        private int root;

        public void Paths(Graph graph, int source)
        {
            DepthFirstSearch(graph, source);
        }

        private void BreadthFirstSearch(Graph graph, int soureVertex)
        {
            var queue = new Queue<int>();
            queue.Enqueue(soureVertex);
            _visited[soureVertex] = true;
            while (queue.Count > 0)
            {
                var vertex = queue.Dequeue();
                foreach (var i in graph.Adj(vertex))
                {
                    if (! _visited[i])
                    {
                        queue.Enqueue(i);
                        _visited[i] = true;
                        _edgeTo[i] = vertex;
                    }
                }
            }

        }

        private void DepthFirstSearch(Graph graph, int sourceVertex)
        {
            _visited[sourceVertex] = true;

            foreach (int w in graph.Adj(sourceVertex))
            {
                if (!_visited[w])
                {
                    DepthFirstSearch(graph, w);
                    _edgeTo[w] = sourceVertex;
                }
            }
        }

        public bool HasPathTo(int vertex)
        {
            return _visited[vertex];
        }

        public IEnumerable<int> PathTo(int vertex)
        {
            if (!HasPathTo(vertex)) return null;
            var path = new Stack<int>();  //Use a stack as we need the read the related edges in reverse of how visited
            for (int i = vertex; i != root; i = _edgeTo[i])
            {
                path.Push(i);
            }
            path.Push(root);
            return path;
        }
    }

    public class Graph
    {
        private Collection<int>[] adj;

        public Graph(int vertex)
        {
            Vertices = vertex;
            for (int v = 0; v < vertex; v++)
            {
                adj[v] = new Collection<int>();
            }
        }

        public Graph(Stream inputStream)
        {
        }

        public int Vertices { get; set; }

        public void AddEdge(int vertex, int w)
        {
            adj[vertex].Add(w);
            adj[w].Add(vertex);
        }

        public IEnumerable<int> Adj(int vertex)
        {
            return adj[vertex];
        }

        public int Edges()
        {
            throw new NotImplementedException();
        }
    }
}