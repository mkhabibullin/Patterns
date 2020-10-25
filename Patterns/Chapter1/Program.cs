using DataStructuresUtils;
using System;

namespace Chapter1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = new int[10000];
            BuildArray(nums);

            //var sw = Stopwatch.StartNew();
            //DisplayNums(nums);
            //sw.Stop();
            //Console.WriteLine("Stopwatch elapsed time: " + sw.ElapsedMilliseconds);

            //using (Timing.Create("Displaying"))
            //{
            //    DisplayNums(nums);
            //}

            Random rnd = new Random(1000);
            int numItems = 5000;
            CArray theArray = new CArray(numItems);
            for (int i = 0; i < numItems; i++)
                theArray.Insert((int)(rnd.NextDouble() * 1000));


            //using (Timing.Create("Bubble sort"))
            //{
            //    theArray.BubbleSort();
            //}

            using (Timing.Create("Selection sort"))
            {
                theArray.SelectionSort();
            }

            //using (Timing.Create("Insertion sort"))
            //{
            //    theArray.InsertionSort();
            //}

            Console.WriteLine("Hello World!");
        }
        static void BuildArray(int[] arr)
        {
            for (int i = 0; i < 10000; i++)
                arr[i] = i;
        }
        static void DisplayNums(int[] arr)
        {
            for (int i = 0; i <= arr.GetUpperBound(0); i++)
                Console.Write(arr[i] + " ");
        }

    }

    class CArray
    {
        private int[] arr;
        private int upper;
        private int numElements;
        public CArray(int size)
        {
            arr = new int[size];
            upper = size - 1;
            numElements = 0;
        }
        public void Insert(int item)
        {
            arr[numElements] = item;
            numElements++;
        }
        public void DisplayElements()
        {
            for (int i = 0; i <= upper; i++)
                Console.Write(arr[i] + " ");
        }
        public void Clear()
        {
            for (int i = 0; i <= upper; i++)
                arr[i] = 0;
            numElements = 0;
        }

        public void BubbleSort()
        {
            int temp;
            for (int outer = upper; outer >= 1; outer--)
            {
                for (int inner = 0; inner <= outer - 1; inner++)
                {
                    if ((int)arr[inner] > arr[inner + 1])
                    {
                        temp = arr[inner];
                        arr[inner] = arr[inner + 1];
                        arr[inner + 1] = temp;
                    }
                }
                //this.DisplayElements();
            }
        }

        public void SelectionSort()
        {
            int min, temp;
            for (int outer = 0; outer <= upper; outer++)
            {
                min = outer;
                for (int inner = outer + 1; inner <= upper; inner++)
                    if (arr[inner] < arr[min])
                        min = inner;
                temp = arr[outer];
                arr[outer] = arr[min];
                arr[min] = temp;
            }
        }

        public void InsertionSort()
        {
            int inner, temp;
            for (int outer = 1; outer <= upper; outer++)
            {
                temp = arr[outer];
                inner = outer;
                while (inner > 0 && arr[inner - 1] >= temp)
                {
                    arr[inner] = arr[inner - 1];
                    inner -= 1;
                }
                arr[inner] = temp;
            }
        }
    }
}
