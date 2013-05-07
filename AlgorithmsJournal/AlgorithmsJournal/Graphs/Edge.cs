using System;

namespace AlgorithmsJournal.Graphs
{
    public class Edge : IComparable
    {
        private readonly int _vertex;
        private readonly int _vertexRelative;
        private readonly double _weight;

        public Edge(int vertex, int relativeVertex, double weight)
        {
            _vertex = vertex;
            _vertexRelative = relativeVertex;
            _weight = weight;
        }

        public int CompareTo(object item)
        {
            var obj = (Edge) item;
            if (_weight < obj._weight)
                return -1;
            if (_weight > obj._weight)
                return +1;
            return 0;
        }

        public int Either()
        {
            return _vertex;
        }

        public int Other(int v)
        {
            return _vertex == v ? _vertexRelative : _vertex;
        }


    }
}