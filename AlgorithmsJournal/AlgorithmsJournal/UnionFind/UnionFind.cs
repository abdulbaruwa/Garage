using System;

namespace AlgorithmsJournal.UnionFind
{

    public class WeightedQuickUnionFind
    {
        private int[] _ids;
        private int[] _Sizeids; //Array to count the number objects in the tree rooted at i
        public WeightedQuickUnionFind(int N)
        {
            _ids = new int[N];
            for (int i = 0; i < N; i++)
            {
                _ids[i] = i;
            }
        }

        public void Union(int p, int q)
        {
            int i = Root(p);
            int j = Root(q);

            if (_Sizeids[i] < _Sizeids[j])
            {
                _ids[i] = j; //i points to root of j
                _Sizeids[j] += _Sizeids[i]; //Size J increase by size of I
            }
            else
            {
                _ids[j] = i;
                _Sizeids[i] += _Sizeids[j]; 
            }
        }

        public bool IsConnected(int p, int q)
        {
            return Root(p) == Root(q);
        }

        private int Root(int p)
        {
            while (p != _ids[p])
            {
                p = _ids[p];
            }
            return p;
        }
    }
    public class QuickUnionFind
    {
        private int[] _ids;
        public QuickUnionFind(int N)
        {
            _ids = new int[N];
            for (int i = 0; i < N; i++)
            {
                _ids[i] = i;
            }
        }

        public void Union(int p, int q)
        {
            int i = Root(p);
            int j = Root(q);
            _ids[i] = j;
        }

        public bool IsConnected(int p, int q)
        {
            return Root(p) == Root(q);
        }

        private int Root(int p)
        {
            while (p != _ids[p])
            {
                p = _ids[p];
            }
            return p;
        }
    }
    public class UnionFind
    {
        public UnionFind(int N)
        {
            //initialize with N objects
        }

        /// <summary>
        /// Add connection between p and q
        /// </summary>
        /// <param name="p"></param>
        /// <param name="q"></param>
        public void Union(int p, int q)
        {
            
        }

        /// <summary>
        /// Are p and q connected?
        /// </summary>
        /// <param name="p"></param>
        /// <param name="q"></param>
        /// <returns></returns>
        public bool IsConnected(int p, int q)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public int Find(int p)
        {
            throw new NotImplementedException();
        }
    }
}