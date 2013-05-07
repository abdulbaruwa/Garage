﻿namespace AlgorithmsJournal
{
    public class QuickUnionUf
    {
        private int[] id;

        public QuickUnionUf(int N)
        {
            this.id = new int[N];
            for (int i = 0; i < N; i++)
            {
                id[i] = i;
            }
        }

        private int root(int i)
        {
            while (i != id[i])
            {
                id[i] = id[id[i]]; //for perf we flaten the tree in one pass.
                i = id[i];
            }
            return i;
        }

        public bool connected(int p, int q)
        {
            return root(p) == root(q);
        }

        public void union(int p, int q)
        {
            int i = root(p);
            int j = root(q);

            id[i] = j;
        }
    }
}