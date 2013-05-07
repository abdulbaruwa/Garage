using System.Collections.Generic;
using AlgorithmsJournal.PriorityQueue;

namespace AlgorithmsJournal.Graphs
{
    /// <summary>
    ///     Lazy implementation of Prim's algorithm for determing the Mininum Spaning Tree.
    /// </summary>
    public class PrimsMinimumSpanningTree
    {
        //Start with Vertex 0 and greedily groo tree T.
        //Add to T the min weighted edge with exactly one endpoint
        //repeat until v -1 edges.

        private readonly bool[] _marked; //for each vertex will tell us it is in the mst
        private readonly Queue<Edge> _mst = new Queue<Edge>();
        private readonly BinaryHeap<Edge> _priorityQueue = new BinaryHeap<Edge>();

        public PrimsMinimumSpanningTree(EdgeWeightedGraph graph)
        {
            _marked = new bool[graph.Vertices];
            visit(graph, 0);
            while (! _priorityQueue.IsEmpty())
            {
                Edge edge = _priorityQueue.DelMin();
                int verticeA = edge.Either();
                int verticeB = edge.Other(verticeA);

                if (_marked[verticeA] == false && _marked[verticeB] == false)
                {
                    _mst.Enqueue(edge);
                    //Which ever vertex that is not on the tree we put on the tree.
                    if (_marked[verticeA] == false) visit(graph, verticeA);
                    if (_marked[verticeB] == false) visit(graph, verticeB);
                }
            }
        }

        private void visit(EdgeWeightedGraph graph, int vertex)
        {
            //Puts a vertex on the tree and also puts the vertex's incident edges on the priority queue.
            _marked[vertex] = true;

            foreach (Edge edge in graph.Adjacent(vertex))
            {
                if (_marked[edge.Other(vertex)] == false)
                {
                    _priorityQueue.Insert(edge);
                }
            }
        }

        public IEnumerable<Edge> MinimumSpaningTree()
        {
            return _mst;
        }
    }
}