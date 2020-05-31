using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Merge_sort
{
    class Program
    {
        static void Main(string[] args)
        {
            //var table = new Hashtable();
            //table.Add(1, 2);


            //var table = new HashTableasdf<int, int>();
            Algorithms.DoBfs();

        }

        






        public static bool StringComparer(string str1, string str2)
        {
            var strlen1 = str1.Length;
            var strlen2 = str2.Length;

            //strlen the same, just check to see if there is one char diff
            if (strlen1 == strlen2)
                IsOneCarAdded(str1, str2);
                //return isOneCharacterDiff(str1, str2);


            //compare to find which character is removed in strlen2
            if ( strlen1 == (strlen2 + 1) )
                return IsOneCarAdded(str1, str2);


            //compare to find which character was added in strlen 1 
            if ((strlen1 + 1) == strlen2)
                return IsOneCarAdded(str2, str1);


            //more than two differences no matter what.
            return false;
        }

        private static bool IsOneCarAdded(string strLonger, string strShorter)
        {
            //bool diffFound = false;
            var strlength = strLonger.Length;
            int i = 0;
            int j = 0;

            while (j < strShorter.Length)
            {
                if (strLonger[i] != strShorter[j])
                {
                    //set flag to jump out
                    if (i != j)
                        return false;
                    
                    i++;
                }
                else
                    i++;
                    j++;
            }

            return true;
        }

        private static bool isOneCharacterDiff(string str1, string str2)
        {
            bool diffFound = false;
            var strlength = str1.Length;
            for (int i = 0; i < strlength; i++)
            {
                if (str1[i] != str2[i])
                {
                    //set flag to jump out
                    if (diffFound)
                    {
                        return false;
                    }
                    diffFound = true;
                }
            }
            //it didn't find more than 2 issues.
            return true;
        }



        public static void quicksort(int[] array)
        {
            quicksort(array, 0, array.Length-1);
        }

        public static void quicksort(int[] array, int left, int right)
        {
            if (left >= right)
            {
                return; //nothing to do
            }

            int pivot = array[(left + right) / 2];
            int index = Partition(array, left, right, pivot);
            quicksort(array, left, index-1);
            quicksort(array, index, right);
        }

        public static int Partition(int[] array, int left, int right, int pivot)
        {
            while (left <= right)
            {
                while (array[left] < pivot)
                {
                    left++;
                }

                while (array[right] > pivot)
                {
                    right--;
                }

                if (left <= right)
                {
                    var temp = array[left];
                    array[left] = array[right];
                    array[right] = temp;


                    left++;
                    right--;
                }
            }

            return left;
        }




        private static List<int> MergeSort(List<int> unsorted)
        {
            if (unsorted.Count <= 1)
                return unsorted;

            List<int> left = new List<int>();
            List<int> right = new List<int>();

            int middle = unsorted.Count / 2;
            for (int i = 0; i < middle; i++)  //Dividing the unsorted list
            {
                left.Add(unsorted[i]);
            }
            for (int i = middle; i < unsorted.Count; i++)
            {
                right.Add(unsorted[i]);
            }

            left = MergeSort(left);
            right = MergeSort(right);
            return Merge(left, right);
        }

        private static List<int> Merge(List<int> left, List<int> right)
        {
            List<int> result = new List<int>();

            while (left.Count > 0 || right.Count > 0)
            {
                if (left.Count > 0 && right.Count > 0)
                {
                    if (left.First() <= right.First())  //Comparing First two elements to see which is smaller
                    {
                        result.Add(left.First());
                        left.Remove(left.First());      //Rest of the list minus the first element
                    }
                    else
                    {
                        result.Add(right.First());
                        right.Remove(right.First());
                    }
                }
                else if (left.Count > 0)
                {
                    result.Add(left.First());
                    left.Remove(left.First());
                }
                else if (right.Count > 0)
                {
                    result.Add(right.First());

                    right.Remove(right.First());
                }
            }
            return result;
        }
    }
}