using System;

namespace AlgorithmsJournal.PriorityQueue
{



    public class BinaryHeap<TKey> where TKey : IComparable
    {

        private TKey[] _priorityQueue;
        private int _N;

        public BinaryHeap(int capacity)
        {
            _priorityQueue = new TKey[capacity+1];
        }

        public BinaryHeap()
        {
            //Use this contructor if implementing with a resizing array as datastore
        }

        public bool IsEmpty()
        {
            return _N == 0;
        }

        public void Insert(TKey value)
        {
            _priorityQueue[++_N] = value;
            Swim(_N);
        }

        private void Swim(int i)
        {
            while (i > 1 && Less(i/2, i))  //parent node of i is i/2
            {
                ExchangeNodes(i,i/2);
                i = i/2; //Set current node to parent
            }
        }

        private void Sink(int k)
        {
            //Exchange key in parent with key in larger child.
            //Repeat until heap order is restored
            while ((2 * k ) <= _N)
            {
                int j = 2*k;
                if (j < _N && Less(j, j+1)) j++;
                if (! Less(k, j)) break;
                ExchangeNodes(k, j);
                k = j;
            }
        }

        public TKey DelMax()
        {
            var max = _priorityQueue[1];
            ExchangeNodes(1, _N - 1);
            Sink(1);
            _priorityQueue[_N + 1] = default(TKey);// default<TKey>; //Now delete by setting no null to prevent loitering
            return max; //Return deleted node
        }

        public TKey DelMin()
        {
            var min = _priorityQueue[_N + 1];
            _priorityQueue[_N + 1] = default(TKey);
            return min;
        }

        private void ExchangeNodes(int node, int withThis)
        {
            var node1 = _priorityQueue[node];
            _priorityQueue[node] = _priorityQueue[withThis];
            _priorityQueue[withThis] = node1;
        }

        private bool Less(int p0, int p1)
        {
            return _priorityQueue[p0].CompareTo(_priorityQueue[p1]) < 0;
        }
    }
}