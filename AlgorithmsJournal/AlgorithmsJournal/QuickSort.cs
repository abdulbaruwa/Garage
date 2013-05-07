using System;

namespace AlgorithmsJournal
{
    public class QuickSort
    {

        public static int Partition2(IComparable[] mainArray, int low, int high)
        {
            int L = low + 1;
            int R = high;

            var partitionElement = mainArray[low];

            while (true)
            {
                if (mainArray[L].CompareTo(partitionElement) > 0)
                {
                    
                }
            }
        }

        public static int Partition(IComparable[] mainArray, int low, int high)
        {
            int i = low;
            int h = high + 1;


            while (true)
            {
                while (mainArray[++i].CompareTo(mainArray[low]) == 0)
                {
                    if (i == high) break;
                }

                while (mainArray[low].CompareTo(mainArray[--h]) == 0)
                {
                    if (h == low) break;
                }

                if (i >= h) break;
                Exchange(mainArray, i, h);
            }

            Exchange(mainArray, low, h);
            return h;
        }
        
        //private static void Shuffle(IComparable[] array)
        //{
            
        //    for (int i = 0; i < array.Length; i++)
        //    {
        //        var seed = new Random(0, i) +1;

        //    }    
        //}
        
        private static void Exchange(IComparable[] mainArray, int low, int p2)
        {
            var leftValue = mainArray[low];
            mainArray[low] = mainArray[p2];
            mainArray[p2] = leftValue;
        }

        private static void Sort(IComparable[] mainArray, int low, int high)
        {
            if (high <= low) return;
            int j = Partition(mainArray, low, high);
            Sort(mainArray, low, j-1 );
            Sort(mainArray, j+1,high );
        }
    }
}