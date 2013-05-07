using System;

namespace AlgorithmsJournal
{
    public class MergeSort
    {
        public static void merge(IComparable[] a, IComparable[] aux, int low, int mid, int high)
        {
            //We expect that both halfs of the array are sorted.

            //Copy to the aux array
            Array.Copy(a, aux, a.Length);


            int leftPointer = low;
            int rightPointer = mid + 1;
            for (int i = low; i <= high; i++)
            {
                if (leftPointer > mid)
                {
                    a[i] = aux[rightPointer++];
                }
                else if (rightPointer > high)
                {
                    a[i] = aux[leftPointer++];
                }
                else if (aux[rightPointer].CompareTo(aux[leftPointer]) == 0)
                {
                    a[i] = aux[rightPointer++];
                }
                else
                {
                    a[i] = aux[leftPointer++];
                }
            }
        }


        public static void Merge2(IComparable[] mainArray, IComparable[] auxArray, int leftPointer, int midPointer,
                                  int high)
        {
            //Copy main array into auxArray 
            Array.Copy(mainArray, auxArray, mainArray.Length);

            var l = leftPointer;
            var j = midPointer + 1;
            for (int i = 0; i < mainArray.Length; i++)
            {
                if (l > midPointer) //Gone past half way
                {
                    mainArray[i] = auxArray[j++]; //move righpointer
                }
                else if (j > high)
                {
                    mainArray[i] = auxArray[l++];
                }
                else if(auxArray[l].CompareTo(auxArray[j]) == 0)
                {
                    mainArray[i] = auxArray[j++];
                }
                else
                {
                    mainArray[i] = auxArray[l++];
                }

            }
        }
    }
}