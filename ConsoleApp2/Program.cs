using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        static  int k = 0;
        static void Main(string[] args)
        {

            int[] arr = new int[] {100,90,80,70,60, 50,40,30,20,10,10,10 };
            int[] sortArr;
            {
                sortArr = OpTest(arr);
                Console.WriteLine("-----冒泡排序--------");
                Print(sortArr);
            }
            {
                sortArr = test2(arr);
                Console.WriteLine("-----选择排序--------");
                Print(sortArr);
            }
            {
                sortArr = test3(arr);
                Console.WriteLine("-----插入排序--------");
                Print(sortArr);
            }
            {
                QukSort(arr, 0, arr.Length - 1);
                Console.WriteLine("-----快速排序--------");
                Print(arr);
            }
        
        //    Console.WriteLine("total:"+k);
            Console.ReadKey() ;
        }

        public static int[] Test(int[] arr)
        {
            int j = 0;
            while (j< arr.Length)
            {
                bool flag = false;
                for (int i = 0; i < arr.Length - 1-j; i++)
                {
                    int temp;
                    if (arr[i] > arr[i + 1])
                    {
                        temp = arr[i];
                        arr[i] = arr[i + 1];
                        arr[i + 1] = temp;
                        flag = true;
                    }
                 
                }
              
                if (!flag)
                {
                    break;
                }
                k++;
                j++;
            }

            return arr;
        }
        /// <summary>
        /// maopao
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public static int[] OpTest(int[] arr)
        {
            int length = arr.Length-1;
            bool flag = false;
            do
            {
               
                for (int i = 0; i < length; i++)
                {
                    int temp;
                    if (arr[i] > arr[i + 1])
                    {
                        temp = arr[i];
                        arr[i] = arr[i + 1];
                        arr[i + 1] = temp;
                        flag = true;
                    }
                }
                length--;
                k++;
            }
            while (length >= 1&& flag);


            return arr;
        }
        /// <summary>
        /// xuanze
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public static int[] test2(int[] arr)
        { 
            int length=arr.Length;
            bool flag = false;

            do
            {
                flag = false;
                int maxindex = 0;
                int max = 0;
                for (int j = 0; j < length; j++)
                {
                    if (max < arr[j])
                    {
                        max = arr[j];
                        maxindex = j;
                        flag = true;
                    }
                }
                if (flag && maxindex != length - 1)
                {
                    swap(arr, maxindex, length - 1);
                }
                length--;
                k++;
            } while (length >= 1 && flag);
            return arr;
        }
        /// <summary>
        /// charu
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public static int[] test3(int[] arr)
        {
            int length = arr.Length;
            int startindex = 1;
            for (int i = startindex; i < length; i++)
            {
                int crrentValue = arr[i];

                for (int  j = startindex-1; j >=0; j--)
                {
                    if (arr[j] > crrentValue)
                    {
                        swap(arr, j, j + 1);
                    }
                 
                }

                startindex++;
            }
            return arr;
        }
        /// <summary>
        /// kuaisu
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="left"></param>
        /// <param name="right"></param>
        public static void QukSort(int[] arr, int left, int right)
        {
            if (left < right)
            { 
               int currentIndex= GetIndex(arr, left,right);
                QukSort(arr, left, currentIndex - 1);
                QukSort(arr, currentIndex+1, right);
            }
        }

        public static int GetIndex(int[] arr,int left,int right)
        {
            int currentValue = arr[right];
            int leftLastIndex = left - 1;
            for (int j = left; j < right; j++)
            {
                if (arr[left] < currentValue)
                {
                    swap(arr, ++leftLastIndex, j);    
                }
            }
            swap(arr, leftLastIndex+1, right);
            return leftLastIndex + 1;
        }

        public static void swap(int[] arr, int i, int j)
        {
            int temp = 0;
            temp = arr[i];
            arr[i] = arr[j];
            arr[j]=temp;
        }

        public static void Print(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i]+" ");
            }
            Console.WriteLine();
        }

    }
}
