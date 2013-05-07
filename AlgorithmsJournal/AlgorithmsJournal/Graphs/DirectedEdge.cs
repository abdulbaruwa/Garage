using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using AlgorithmsJournal.PriorityQueue;

namespace AlgorithmsJournal.Graphs
{

    public class DijkstraShortestPath
    {
        private DirectedEdge[] _edgeTo;
        private double[] _distTo;
        private BinaryHeap<double> _priorityQueue;

        public DijkstraShortestPath(EdgeWeightedDigraph graph, int sourceVertex)
        {
            _edgeTo = new DirectedEdge[graph.Vertices];
            _distTo = new double[graph.Vertices];
            _priorityQueue = new BinaryHeap<double>(graph.Vertices);

            for (int i = 0; i < graph.Vertices; i++)
            {
                _distTo[i] = double.PositiveInfinity;
            }
            _distTo[sourceVertex] = 0.0;


           _priorityQueue.Insert(sourceVertex,0.0);
            while (_priorityQueue.IsEmpty() == false)
            {
                var vertex = _priorityQueue.DelMin();
                foreach (var edge in graph.AdjacentEdgesFrom(vertex))
                {
                    RelaxEdge(edge);
                }
            }

        }

        private void RelaxEdge(DirectedEdge edge)
        {
            int sourceVertex = edge.FromVertex;
            int toVertex = edge.ToVertex;

            //If this new distance to the to vertex is less than the existing distance to same vertex then:
            if (_distTo[toVertex] > _distTo[sourceVertex] + edge.Weight)
            {
                _distTo[toVertex] = _distTo[sourceVertex] + edge.Weight;
                _edgeTo[toVertex] = edge;
                if (_priorityQueue.Contains(toVertex))
                {
                    _priorityQueue.DecreaseKey(toVertex, _distTo[toVertex]);
                }
                else
                {
                    _priorityQueue.Insert(toVertex, _distTo[toVertex]);
                }
            }
        }

    }

    public class ShortestPath
    {
        private EdgeWeightedDigraph _edgeWeightedDigraph;

        public ShortestPath(EdgeWeightedDigraph graph, int pathFromVertex)
        {
        }

        public double DistantTo(int vertex)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DirectedEdge> PathTo(int vertex)
        {
            var path = new Stack<DirectedEdge>();
            for (DirectedEdge edge = _edgeTo[vertex]; edge != null; _edgeTo[edge.FromVertex])
            {
                path.Push(edge);
            }
            return path;
        }
    }

    public class DirectedEdge
    {
        public DirectedEdge(int vertexA, int vertexB, double weight)
        {
            FromVertex = vertexA;
            ToVertex = vertexB;
            Weight = weight;
        }

        public int FromVertex { private set; get; }
        public int ToVertex { get; private set; }
        public double Weight { get; private set; }
    }

    public class EdgeWeightedDigraph
    {
        private readonly Collection<DirectedEdge>[] _adjacent;

        public EdgeWeightedDigraph(int vertex)
        {
            Vertices = vertex;
            _adjacent = new Collection<DirectedEdge>[vertex];

            //create a bag to hold edges for each vertex
            for (int i = 0; i < vertex; i++)
            {
                _adjacent[i] = new Collection<DirectedEdge>();
            }
        }

        public EdgeWeightedDigraph(Stream inputStream)
        {
        }

        public int Vertices { get; private set; }
        public int EdgeCount { get; private set; }
        public IEnumerable<DirectedEdge> Edges { get; private set; }

        public void AddEdge(DirectedEdge edge)
        {
            int vertexFrom = edge.FromVertex;
            _adjacent[vertexFrom].Add(edge);
        }

        /// <summary>
        ///     Return all list of a Edges from a give vertex
        /// </summary>
        /// <param name="vertex"></param>
        /// <returns></returns>
        public IEnumerable<DirectedEdge> AdjacentEdgesFrom(int vertex)
        {
            return _adjacent[vertex];
        }
    }
}