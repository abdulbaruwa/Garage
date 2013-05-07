using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace AlgorithmsJournal.Graphs
{
    public class EdgeWeightedGraph
    {
        private readonly Collection<Edge>[] _adj;
        private Collection<Edge> _edges;

        public EdgeWeightedGraph(int vertices)
        {
            _adj = new Collection<Edge>[vertices];
            Vertices = vertices;
            for (int i = 0; i < vertices; i++)
            {
                _adj[i] = new Collection<Edge>();
            }
        }

        public int Vertices { get; private set; }

        public void AddEdge(Edge edge)
        {
            int v = edge.Either();
            int w = edge.Other(v);

            _adj[v].Add(edge);
            _adj[w].Add(edge);
        }

        public IEnumerable<Edge> Edges()
        {
            return _edges;
        }

        public IEnumerable<Edge> Adjacent(int vertex)
        {
            return _adj[vertex];
        }
    }
}