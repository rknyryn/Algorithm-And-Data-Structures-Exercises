using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.SortingAlgorithms
{
    public class Sorting
    {
        private static void Swap<T>(T[] array, int first, int second)
        {
            var temp = array[first];
            array[first] = array[second];
            array[second] = temp;
        }

        public static void SelectionSort<T>(T[] array) where T : IComparable
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                int minIndex = i;
                T minValue = array[i];
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[j].CompareTo(minValue) < 0)
                    {
                        minIndex = j;
                        minValue = array[j];
                    }
                }
                Swap(array, i, minIndex);
            }
        }
        public static void SelectionSort<T>(T[] array,
            Shared.SortDirection sortDirection = Shared.SortDirection.Ascending)
            where T : IComparable
        {
            var comparer = new Shared.CustomComparer<T>(sortDirection, Comparer<T>.Default);
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (comparer.Compare(array[j], array[i]) >= 0)
                        continue;
                    Swap(array, i, j);
                }
            }
        }

        public static void BubbleSort<T>(T[] array) where T : IComparable
        {
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array.Length - 1 - i; j++)
                {
                    if (array[j].CompareTo(array[j + 1]) > 0)
                    {
                        Swap(array, j, j + 1);
                    }
                }
            }
        }

        public static T[] InsertionSort<T>(T[] array,
            Shared.SortDirection sortDirection = Shared.SortDirection.Ascending)
            where T : IComparable
        {
            var comparer = new Shared.CustomComparer<T>(sortDirection, Comparer<T>.Default);
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = i + 1; j > 0; j--)
                {
                    if (array[j].CompareTo(array[j - 1]) < 0)
                        Swap(array, j - 1, j);
                    else
                        break;
                }
            }
            return array;
        }

        private static int Partition<T>(T[] array, int lower, int upper)
            where T : IComparable
        {
            int i = lower;
            int j = upper;

            T pivot = array[i];
            do
            {
                while (array[i].CompareTo(pivot) < 0)
                    i++;
                while (array[j].CompareTo(pivot) > 0)
                    j--;
                if (i >= j)
                    break;
                Swap(array, i, j);
            } while (i <= j);
            return j;
        }
        private static void QuickSort<T>(T[] array, int lower, int upper)
            where T : IComparable
        {
            if (lower < upper)
            {
                int pi = Partition(array, lower, upper);
                QuickSort(array, lower, pi);
                QuickSort(array, pi + 1, upper);
            }
        }
        public static void QuickSort<T>(T[] array)
            where T : IComparable
        {
            QuickSort(array, 0, array.Length - 1);
        }

        public static void MergeSort<T>(T[] array) where T : IComparable
        {
            MergeSort(array, 0, array.Length - 1);
        }
        private static void MergeSort<T>(T[] array, int left, int right)
            where T : IComparable
        {
            if (left < right)
            {
                int middle = (left + right) / 2;
                MergeSort(array, left, middle);
                MergeSort(array, middle + 1, right);
                Merge(array, left, middle, right);
            }
        }
        private static void Merge<T>(T[] array, int left, int middle, int right)
            where T : IComparable
        {
            T[] leftArray = new T[middle - left + 1];
            T[] rightArray = new T[right - middle];

            System.Array.Copy(array, left, leftArray, 0, middle - left + 1);
            System.Array.Copy(array, middle + 1, rightArray, 0, right - middle);

            int i = 0;
            int j = 0;
            for (int k = left; k < right; k++)
            {
                if (i == leftArray.Length)
                {
                    array[k] = rightArray[j];
                    j++;
                }
                else if (j == rightArray.Length)
                {
                    array[k] = leftArray[i];
                    i++;
                }
                else if (leftArray[i].CompareTo(rightArray[j]) < 0)
                {
                    array[k] = leftArray[i];
                    i++;
                }
                else
                {
                    array[k] = rightArray[j];
                    j++;
                }
            }
        }
    }
}
