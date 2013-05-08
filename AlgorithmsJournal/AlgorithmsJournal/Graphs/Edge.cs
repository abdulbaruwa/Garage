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



    public class FlowEdge : IComparable
    {
        private readonly double _capacity;

        public FlowEdge(int fromVertex, int toVertex, double capacity)
        {
            From = fromVertex;
            To = toVertex;
            Capacity = capacity;
        }

        public int CompareTo(object item)
        {
            var obj = (FlowEdge)item;
            if (_capacity < obj._capacity)
                return -1;
            if (_capacity > obj._capacity)
                return +1;
            return 0;
        }

        public int From { get; private set; }
        public int To { get; private set; }
        public double Capacity { get; private set; }
        public int Other(int vertex)
        {
            throw new NotImplementedException();
        }
        public double Flow()
        {
            throw new NotImplementedException();
        }

        public double ResidualCapacityTo(int vertex)
        {
            throw new NotImplementedException();
        }

        public void AddResidualFlowTo(int vertex, double delta)
        {
            throw new NotImplementedException();
        }


        //v--------7/9-------->w
        //7 = flow fe
        //9 = capacitye ce

        //v--------2 -------->w
        // <--------7 -------
        //residual capacity = 2, on forward edge
        //residual capacity = 7, on backward edge
        

    }
}