using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting_Searching
{
    internal class Program
    {
        public static int mergeSortCounter = 0;
        public static int quickSortCounter = 0;
        static void Main(string[] args)
        {
            // constants required for array setup
            const int MIN = 1;
            const int MAX = 100;
            const int ARRAY_SIZE = 20;

            // arrays
            int[] arrayToBubbleSort = GetRandomIntArray(MIN, MAX, ARRAY_SIZE);
            int[] arrayToSelectionSort = GetRandomIntArray(MIN, MAX, ARRAY_SIZE);
            int[] arrayToInsetionSort = GetRandomIntArray(MIN, MAX, ARRAY_SIZE);
            int[] arrayToMergeSort = GetRandomIntArray(MIN, MAX, ARRAY_SIZE);
            int[] arrayToQuickSort = GetRandomIntArray(MIN, MAX, ARRAY_SIZE);

            // Bubble Sort
            Console.WriteLine("Array BEFORE buuble sort: ");
            DisplayArray(arrayToBubbleSort);
            Console.WriteLine("Array AFTER bubble sort: ");
            BubbleSort(arrayToBubbleSort, "asc");
            DisplayArray(arrayToBubbleSort);



            // Selection Sort
            Console.WriteLine("---------------------------------------------------------------");
            Console.WriteLine("Array BEFORE selection sort: ");
            DisplayArray(arrayToSelectionSort);
            Console.WriteLine("Array AFTER selection sort: ");
            SelectionSort(arrayToSelectionSort, "asc");
            DisplayArray(arrayToSelectionSort);

            // Insertion Sort
            Console.WriteLine("---------------------------------------------------------------");
            Console.WriteLine("Array BEFORE insertion sort: ");
            DisplayArray(arrayToInsetionSort);
            Console.WriteLine("Array AFTER insertion sort: ");
            InsertionSort(arrayToInsetionSort, "asc");
            DisplayArray(arrayToInsetionSort);

            // Merge Sort
            Console.WriteLine("---------------------------------------------------------------");
            int mergeSortCounter = 0;
            Console.WriteLine("Array BEFORE merge sort: ");
            DisplayArray(arrayToMergeSort);
            Console.WriteLine("Array AFTER merge sort: ");
            arrayToMergeSort = MergeSort(arrayToMergeSort);
            Console.WriteLine("Number of swaps (Merge Sort): {0}", mergeSortCounter);
            DisplayArray(arrayToMergeSort);

            // Quick Sort
            Console.WriteLine("---------------------------------------------------------------");
            int quickSortCounter = 0;
            Console.WriteLine("Array BEFORE quick sort: ");
            DisplayArray(arrayToQuickSort);
            Console.WriteLine("Array AFTER quick sort: ");
            QuickSort(arrayToQuickSort, 0, arrayToQuickSort.Length - 1);
            Console.WriteLine("Number of swaps (Quick Sort): {0}", quickSortCounter);
            DisplayArray(arrayToQuickSort);
            Console.WriteLine("---------------------------------------------------------------");

            // Linear search 
            // unsorted array to search
            int[] arrayToSearch = GetDistinctRandomIntArray(MIN, MAX, ARRAY_SIZE * 2);
            Console.WriteLine("Unsorted array to search using LINEAR SEARCH method ...");
            DisplayArray(arrayToSearch);
            Console.Write("Enter numeric value for linear search ==> ");
            int numberToSearch = Int32.Parse(Console.ReadLine());
            int posFound = LinearSearch(arrayToSearch, numberToSearch);
            if (posFound >= 0)
            {
                Console.WriteLine(numberToSearch + " was found at index [" + posFound + "]");
                
            }
            else
            {
                Console.WriteLine(numberToSearch + " was NOT found");
            }
            Console.WriteLine("---------------------------------------------------------------");

            // Binary search
            // sorted array to search using Array.Sort()
            Array.Sort(arrayToSearch);
            Console.WriteLine("Sorted array to search using BINARY SEARCH method ...");
            DisplayArray(arrayToSearch);
            Console.Write("Enter numeric value for binary search ==> ");
            numberToSearch = Int32.Parse(Console.ReadLine());
            posFound = BinarySearch(arrayToSearch, numberToSearch);
            if (posFound >= 0)
            {
                Console.WriteLine(numberToSearch + " was found at index [" + posFound + "]");

            }
            else
            {
                Console.WriteLine(numberToSearch + " was NOT found");
            }
            Console.WriteLine("---------------------------------------------------------------");


            // Press any key to exit
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();

        } // end of Main method


        /******************************************************************************
         * Method:  GetRandomIntArray()
         * Purpose: Returns an integer array containing random values
         *          consisting of random numbers between min and max 
         *          with an array size set to array_size
         * Input:   int min, int max, int array_size
         * Output:  int[] randomIntArray
         * ****************************************************************************/
        static int[] GetRandomIntArray(int min, int max, int array_size)
        {
            if (max <= min)
            {
                Console.WriteLine("ERROR: Maximum value should not be less than or equal to minimum value");
                return null;
            }
            int[] randomIntArray = new int[array_size];
            // get random number using hash code of a globally unique identifier
            Random rand = new Random(Guid.NewGuid().GetHashCode());
            // loop to get the required number of random values for the array
            for (int i = 0; i < array_size; i++)
            {
                // get next (random value)
                randomIntArray[i] = rand.Next(min, max + 1);

            }
            return randomIntArray;
        }



        /*******************************************************************************
         * Method:  DisplayArray()
         * Purpose: Displays all elements values in an integer array
         * Input:   int[] arrayToDisplay
         * Output:  void
         * ****************************************************************************/

        static void DisplayArray(int[] array)
        {
            if (array == null)
            {
                return;
            }
            foreach (var item in array)
            {
                Console.Write(item.ToString() + " ");

            }
            Console.Write("\n");
        }



        /*******************************************************************************/
        /*******************************************************************************/
        /*************************** BUBBLE SORT ALGORITHM *****************************/
        /*******************************************************************************/
        /*******************************************************************************/
        static void BubbleSort(int[] array, String order)
        {
            int swapCounter = 0;
            int comparisonCounter = 0;

            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array.Length - 1; j++)
                {
                    comparisonCounter++;
                    if (order == "asc")
                    {
                        if (array[i] < array[j])
                        {
                            // swap values
                            int temp = array[i];
                            array[i] = array[j];
                            array[j] = temp;
                            swapCounter++;
                        }
                        else if (order == "desc")
                        {
                            if (array[i] > array[j])
                            {
                                // swap values
                                int temp = array[i];
                                array[i] = array[j];
                                array[j] = temp;
                                swapCounter++;
                            }
                        }
                    }
                }
                Console.WriteLine("Number of swaps (Bubble Sort): {0}", swapCounter);
                Console.WriteLine("Number of comparisons (Bubble Sort): {0}", comparisonCounter);
            }

        }

        /*******************************************************************************/
        /*******************************************************************************/
        /************************ SELECTION SORT ALGORITHM *****************************/
        /*******************************************************************************/
        /*******************************************************************************/
        public static void SelectionSort(int[] array, String order)
        {
            int swapCounter = 0;
            int comparisonCounter = 0;

            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    comparisonCounter++;
                    if (order == "asc")
                    {
                        if (array[j] < array[i])
                        {
                            int temp = array[j];
                            array[j] = array[i];
                            array[i] = temp;
                            swapCounter++;
                        }
                    }
                    else if (order == "desc")
                    {
                        if (array[j] > array[i])
                        {
                            int temp = array[j];
                            array[j] = array[i];
                            array[i] = temp;
                            swapCounter++;
                        }
                    }
                }
            }
            Console.WriteLine("Number of swaps (Selection Sort): {0}", swapCounter);
            Console.WriteLine("Number of comparisons (Selection Sort): {0}", comparisonCounter);
        }

        /*******************************************************************************/
        /*******************************************************************************/
        /******************** INSERTION SORT ALGORITHM *********************************/
        /*******************************************************************************/
        /*******************************************************************************/
        public static void InsertionSort(int[] array, String order)
        {
            int swapCounter = 0;
            int comparisonCounter = 0;
            for (int i = 1; i < array.Length; i++)
            {
                for (int j = i; j > 0; j--)
                {
                    comparisonCounter++;
                    if (order == "asc")
                    {
                        if (array[j] < array[j - 1])
                        {
                            int temp = array[j];
                            array[j] = array[j - 1];
                            array[j - 1] = temp;
                            swapCounter++;
                        }
                    }
                    else if (order == "desc")
                    {
                        if (array[j] > array[j - 1])
                        {
                            int temp = array[j];
                            array[j] = array[j - 1];
                            array[j - 1] = temp;
                            swapCounter++;
                        }
                    }



                }










            }
            Console.WriteLine("Number of swaps (Insertion Sort): {0}", swapCounter);
            Console.WriteLine("Number of comparisons (Insertion Sort): {0}", comparisonCounter);




        }
        /*******************************************************************************/
        /*******************************************************************************/
        /************************* MERGE SORT ALGORITHM ********************************/
        /*******************************************************************************/
        /*******************************************************************************/
        public static int[] MergeSort(int[] array)
        {
            int[] left;
            int[] right;
            int[] result = new int[array.Length];

            // base case to avoid an infinite recursion
            // and therefore a stackoverflow exception
            if ((array.Length <= 1))
            {
                return array;
            }

            // the exact midpoint of our array
            int midPoint = array.Length / 2;
            // left half of the array
            left = new int[midPoint];
            // if array has an even number of elements, the left and right array
            // will have the same number of elements
            if (array.Length % 2 == 0)
            {
                right = new int[midPoint];
            }
            // if array has an odd number of elements, the right array
            // will have one more element than the left 
            else
            {

                right = new int[midPoint + 1];
            }
            // populate left array
            for (int i = 0; i < midPoint; i++)
            {
                left[i] = array[i];
            }
            // populate right array
            int x = 0;
            // Start with index from the midpoint for the right array
            // the left array already started from 0 to midPoint
            for (int i = midPoint; i < array.Length; i++)
            {
                right[x] = array[i];
                x++;
            }
            // Recuslively sort the left array
            left = MergeSort(left);
            // Recursively sort the right array
            right = MergeSort(right);
            // Merge the two sorted arrays
            result = MergeArrays(left, right);
            return result;






        }

        public static int[] MergeArrays(int[] left, int[] right)
        {
            // count how many times MergeArrays() is called
            mergeSortCounter++;
            // Length of both input arrays (total number of elements)
            int resultLength = right.Length + left.Length;
            // new array
            int[] result = new int[resultLength];
            // start index values for each of the 3 arrays with zero
            int indexLeft = 0, indexRight = 0, indexResult = 0;
            // while either array still has an element
            while (indexLeft < left.Length || indexRight < right.Length)
            {
                // if both arrays have elements
                if (indexLeft < left.Length && indexRight < right.Length)
                {
                    // if item on left array is less than item on right array,
                    // add that item to the result array
                    if (left[indexLeft] <= right[indexRight])
                    {
                        result[indexResult] = left[indexLeft];
                        indexLeft++;
                        indexResult++;
                    }
                    // else the item in the right array will be added
                    // to the results array
                    else
                    {
                        result[indexResult] = right[indexRight];
                        indexRight++;
                        indexResult++;
                    }
                }
                // if only the left array stii has elements,
                // add all its items to the results array
                else if (indexLeft < left.Length)
                {
                    result[indexResult] = left[indexLeft];
                    indexLeft++;
                    indexResult++;
                }
                // if only the right array still has elements,
                // add all its items to the results array
                else if (indexRight < right.Length)
                {
                    result[indexResult] = right[indexRight];
                    indexRight++;
                    indexResult++;
                }
            }

            return result;

















        }
        /*******************************************************************************/
        /*******************************************************************************/
        /************************* QUICK SORT ALGORITHM ********************************/
        /*******************************************************************************/
        /*******************************************************************************/
        public static void QuickSort(int[] array, int start, int end)
        {
            // start index
            int i = start;
            // end index
            int j = end;
            int middleValue = array[(i + j) / 2]; // pivot is half-way

            while (true)
            {
                while (array[i] < middleValue)
                {
                    i++;
                }
                while (array[j] > middleValue)
                {
                    j--;

                }
                if (i <= j)
                {
                    int temp = array[i];
                    array[i] = array[j];
                    array[j] = temp;
                    i++;
                    j--;
                    quickSortCounter++;
                }
                if (i > j)
                {
                    break;
                }




            }
            if (start < j)
            {
                QuickSort(array, start, j);
            }
            if (i < end)
            {
                QuickSort(array, i, end);
            }


        }



        /*******************************************************************************/
        // method:  LinearSearch()
        // purpose: returns an index value respective to the found value
        //          in the array of intergers.
        // input:   int[] arrayToSearch, (array of values to search through),
        //          int numberToSearch (value to search for)
        // output:  int (index position of the array where the value was found
        //          if not found, returned value is -1; if found,
        //          returned value is >= 0
        /*******************************************************************************/
        static int LinearSearch(int[] arrayToSearch, int numberToSearch)
        {
            int posFound = -1;
            for (int i = 0; i < arrayToSearch.Length; i++)
            {
                Console.Write("[" + i + "] element value is: " + arrayToSearch[i]);
                if (numberToSearch == arrayToSearch[i])
                {
                    Console.Write(" <-- Found!");
                    posFound = i; 
                }
                Console.Write("\n\r");
                if (posFound >= 0)
                {
                    break;
                }
            }
            return posFound;
        }


        /*******************************************************************************/
        // method:  GetDistinctRandomIntArray()
        // purpose: returns an integer array containing random values (all unique and no 
        //          duplicates) consisting of random numbers between min and max
        //          with an array size set to array_size
        // input:   int min, int max, int array_size
        // output:  int[] randomIntArray
        /*******************************************************************************/
        static int[] GetDistinctRandomIntArray(int min, int max, int array_size)
        {
            // declare min and max
            if (max <= min || array_size >= (max - min + 1) / 2)
            {
                Console.WriteLine("ERROR: Number of possible random values should NOT  be " +
                    "greater than the desired array size / 2 \n--- e.g. min = 1 and max = 100" +
                    "therefore array size should be no more than 50");
                return null;
            }
            // declare random integer array (used to store the unique random values)
            int[] randomIntArray = new int[array_size];
            // declare List of integers - easy wasy to check for duplicate values
            List<int> uniqueIntList = new List<int>();
            // get random number using hash code of a globally unique identifier
            Random rand = new Random(Guid.NewGuid().GetHashCode());

            for (int i = 0; i < array_size; i++)
            {
                int randNumber = rand.Next(min, max + 1);
                // add to List
                if (i == 0)
                {
                    uniqueIntList.Add(randNumber);
                    randomIntArray[i] = randNumber;
                }
                else
                {
                    // check if not a duplicate
                    if (!uniqueIntList.Contains(randNumber))
                    {
                        uniqueIntList.Add(randNumber);
                        randomIntArray[i] = randNumber;
                    }
                    else
                    {
                        // duplicate detected
                        i--;
                    }
                }
            }
            return randomIntArray;



        }

        /*******************************************************************************/
        // method:  BinarySearch()
        // purpose: returns an index value respective to the found value
        //          in the sorted array of integers
        // input:   int[] arrayToSearch, (sorted array of values to search through),
        //          int numberToSearch (value to search for)
        //output:   int (index position of the array where the value was found
        //          if not found, returned value is -1; if found,
        //          returned value is >= 0
        /*******************************************************************************/
        static int BinarySearch(int[] arrayToSearch, int numberToSearch)
        {
            bool foundStatus = false;
            int first = 0;
            int last = arrayToSearch.Length - 1;
            int mid;

            int posFound = -1;

            // loop while foundStatus is false AND first is less than
            // or equal to last
            while (!foundStatus && first <= last)
            {
                // get mide index value
                mid = (first + last) / 2;

                // check if number to search is less than the value
                // positioned in the middle of the sorted array
                // if it is, then change the last position to mid less 1
                // this way, last becomes the last value
                // in the sorted upper half of the array
                if (numberToSearch < arrayToSearch[mid])
                {
                    last = mid - 1;
                    Console.WriteLine("[" + mid + "] element value is: " + arrayToSearch[mid]);
                }
                // check if number to search is greater then the value
                // positioned in the middle of the sorted array
                // if it is, then change the first position to mid plus 1
                // this way, first becomes the first value
                // in the sorted lower half of the array
                else if (numberToSearch > arrayToSearch[mid])
                {
                    first = mid + 1;
                    Console.WriteLine("[" + mid + "] element value is: " + arrayToSearch[mid]);
                }
                // otherwise, the value has been found
                else
                {
                    foundStatus = true;
                    posFound = mid;
                    Console.WriteLine("[" + mid + "] element value is: " + arrayToSearch[mid] + " <-- Found!");
                }
            }
            return posFound;
        }













































    }


}
