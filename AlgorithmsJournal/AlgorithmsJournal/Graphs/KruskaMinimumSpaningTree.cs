using System.Collections.Generic;
using AlgorithmsJournal.PriorityQueue;
using AlgorithmsJournal.UnionFind;

namespace AlgorithmsJournal.Graphs
{
    public class KruskaMinimumSpaningTree
    {
        private readonly BinaryHeap<Edge> _priorityQueue = new BinaryHeap<Edge>();
        private readonly Queue<Edge> mst = new Queue<Edge>();

        public KruskaMinimumSpaningTree(EdgeWeightedGraph graph)
        {
            foreach (Edge edge in graph.Edges())
            {
                _priorityQueue.Insert(edge);
            }

            var weightedQuickUnion = new WeightedQuickUnionFind(graph.Vertices); //Initialize with size of graph
            //loop while priority queue is not empty and mst less than vertices.
            while (! _priorityQueue.IsEmpty() && mst.Count < graph.Vertices - 1)
            {
                Edge edge = _priorityQueue.DelMin();
                int verticeA = edge.Either();
                int verticeB = edge.Other(verticeA);
                if (! weightedQuickUnion.IsConnected(verticeA, verticeB))
                {
                    weightedQuickUnion.Union(verticeA, verticeB); //Mege the sets
                    //add edge to mst
                    mst.Enqueue(edge);
                }
            }
        }

        public IEnumerable<Edge> EdgesOfMst()
        {
            return mst;
        }
    }
}