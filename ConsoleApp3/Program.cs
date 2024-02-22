using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    internal class Program
    {
        public static void Main(string[] args)
        {
           // int[] arr = new int[] { 5, 2, 8, 3, 1 }; // 要进行排序的数组
           int[] arr = new int[] { 50, 45, 25, 3, 15, 4, 100, 3 ,25, 30, 7 ,9, 8, 40 };

            //int[] arr = new int[] { 3 ,15 ,4 ,3, 25, 30 ,7 ,9 ,8, 40 };

            //int[] arr = new int[] { 100, 90, 80, 70, 60, 50, 40, 30, 20, 10, 10, 10 };
            //Console.WriteLine("原始数组：");
            PrintArray(arr);

            QuickSort(arr, 0, arr.Length - 1); // 调用快速排序函数对数组进行排序

          //Console.WriteLine("\n排序后的数组：");
            PrintArray(arr);
            Console.ReadKey();
        }

        private static void QuickSort(int[] arr, int left, int right)
        {
            if (left < right)
            {
                int pivotIndex = Partition(arr, left, right); // 获取基准元素的索引位置

                QuickSort(arr, left, pivotIndex - 1); // 对左侧子数组进行排序
                QuickSort(arr, pivotIndex + 1, right); // 对右侧子数组进行排序
            }
        }

        private static int Partition(int[] arr, int left, int right)
        {
            int pivot = arr[right]; // 选择最右边的元素作为基准值
            int i = left - 1;

            for (int j = left; j <= right - 1; j++)
            {
                if (arr[j] < pivot)
                {
                    Swap(ref arr[++i], ref arr[j]); // 将小于基准值的元素交换到左侧
                }
            }

            Swap(ref arr[i + 1], ref arr[right]); // 将基准值放在正确的位置上

            return i + 1; // 返回基准值所在的索引位置
        }

        private static void Swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }

        private static void PrintArray(int[] arr)
        {
            foreach (var num in arr)
            {
                Console.Write($"{num} ");
            }
            Console.WriteLine();
        }
    }
}
