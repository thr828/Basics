using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {

            #region 一、内存上连续存储，节约空间，可以索引访问，读取快，增删慢
            {
                //Array：在内存上连续分配的，而且元素类型是一样的
                //可以坐标访问  读取快--增删慢，长度不变
                Console.WriteLine("***************Array******************");
                int[] intArray = new int[3];
                intArray[0] = 123;
                string[] strArray = new string[] { "123", "234" };//Array        
            }

            {
                //ArrayList  不定长的，连续分配的；
                //元素没有类型限制，任何元素都是当成object处理，如果是值类型，会有装箱操作
                //读取快--增删慢
                Console.WriteLine("***************ArrayList******************");
                ArrayList arrayList = new ArrayList();
                arrayList.Add(true);
                arrayList.Add("Is");
                arrayList.Add(32);//add增加长度
                //arrayList[4] = 26;//索引复制，不会增加长度
                //删除数据
                //arrayList.RemoveAt(4);
                var value = arrayList[2];
                arrayList.RemoveAt(0);
                arrayList.Remove(true);
            }
            {
                //List:也是Array，内存上都是连续摆放;不定长；泛型，保证类型安全，避免装箱拆箱
                //读取快--增删慢
                Console.WriteLine("***************List<T>******************");
                List<int> intList = new List<int>() { 1, 2, 3, 4 };
                intList.Add(123);
                intList.Add(123);
                //intList.Add("123");
                //intList[0] = 123;
                List<string> stringList = new List<string>();
                //stringList[0] = "123";//异常的
            }

            #endregion

            #region 二、非连续摆放，存储数据+地址，找数据的话就只能顺序查找，读取慢；增删快
            {
                //LinkedList：泛型的特点;链表，元素不连续分配，每个元素都有记录前后节点
                //节点值可以重复
                //能不能下标访问？不能，找元素就只能遍历  查找不方便
                //增删 就比较方便
                Console.WriteLine("***************LinkedList<T>******************");
                LinkedList<int> linkedList = new LinkedList<int>();
                //linkedList[3]
                linkedList.AddFirst(123);//添加为第一个节点元素
                linkedList.AddLast(456);//添加为最后一个节点元素

                bool isContain = linkedList.Contains(123);
                LinkedListNode<int> node123 = linkedList.Find(123);  //元素123的位置  从头查找
                linkedList.AddBefore(node123, 123);//节点不存在，会报错
                linkedList.AddBefore(node123, 123);//在指定节点前新增元素
                linkedList.AddAfter(node123, 9);//在指定节点后新增元素

                linkedList.Remove(456);//删除指定值，不存在会报错
                linkedList.Remove(node123);//删除指定节点
                linkedList.RemoveFirst();//删除第一个元素
                linkedList.RemoveLast();//删除最后一个元素
                linkedList.Clear();

            }

            {
                //Queue 就是链表  先进先出  放任务延迟执行，A不断写入日志任务  B不断获取任务去执行
                Console.WriteLine("***************Queue<T>******************");
                Queue<string> numbers = new Queue<string>();
                numbers.Enqueue("one");//添加对象到队列末尾
                numbers.Enqueue("two");
                numbers.Enqueue("three");
                numbers.Enqueue("four");
                numbers.Enqueue("four");
                numbers.Enqueue("five");

                foreach (string number in numbers)
                {
                    Console.WriteLine(number);
                }

                Console.WriteLine($"Dequeuing '{numbers.Dequeue()}'");//Dequeue方法 移除并返回队列的第一个元素
                Console.WriteLine($"Peek at next item to dequeue: {numbers.Peek()}");//Peek方法 返回队列的第一个元素 但不移除元素
                Console.WriteLine($"Dequeuing '{numbers.Dequeue()}'");

                Queue<string> queueCopy = new Queue<string>(numbers.ToArray());
                foreach (string number in queueCopy)
                {
                    Console.WriteLine(number);
                }

                Console.WriteLine($"queueCopy.Contains(\"four\") = {queueCopy.Contains("four")}");
                queueCopy.Clear();
                Console.WriteLine($"queueCopy.Count = {queueCopy.Count}");

            }
            //队列是没瓶底的瓶子,栈是有瓶底的瓶子
            {
                //Stack 就是链表  先进后出  解析表达式目录树的时候，先产生的数据后使用
                //操作记录为命令，撤销的时候是倒序的
                Console.WriteLine("***************Stack<T>******************");
                Stack<string> numbers = new Stack<string>();
                numbers.Push("one");
                numbers.Push("two");
                numbers.Push("three");
                numbers.Push("four");
                numbers.Push("five");//放进去

                foreach (string number in numbers)
                {
                    Console.WriteLine(number);
                }

                Console.WriteLine($"Pop '{numbers.Pop()}'");//获取并移除
                Console.WriteLine($"Peek at next item to dequeue: {numbers.Peek()}");//获取不移除
                Console.WriteLine($"Pop '{numbers.Pop()}'");

                Stack<string> stackCopy = new Stack<string>(numbers.ToArray());
                foreach (string number in stackCopy)
                {
                    Console.WriteLine(number);
                }

                Console.WriteLine($"stackCopy.Contains(\"four\") = {stackCopy.Contains("four")}");
                stackCopy.Clear();
                Console.WriteLine($"stackCopy.Count = {stackCopy.Count}");
            }

            #endregion

            #region 三、Set 纯粹的集合，容器，唯一性
            {
                //集合：hash分布，元素间没关系,动态增加容量  去重
                //统计用户IP；IP投票   交叉并补--二次好友/间接关注/粉丝合集
                Console.WriteLine("***************HashSet<string>******************");
                HashSet<string> hashSet = new HashSet<string>();
                hashSet.Add("123");
                hashSet.Add("689");
                hashSet.Add("456");
                hashSet.Add("12435");
                hashSet.Add("12435");
                hashSet.Add("12435");
                //hashSet[0];
                foreach (var item in hashSet)
                {
                    Console.WriteLine(item);
                }
                Console.WriteLine(hashSet.Count);
                Console.WriteLine(hashSet.Contains("12345"));

                {
                    HashSet<string> hashSet1 = new HashSet<string>();
                    hashSet1.Add("123");
                    hashSet1.Add("689");
                    hashSet1.Add("789");
                    hashSet1.Add("12435");
                    hashSet1.Add("12435");
                    hashSet1.Add("12435");
                    hashSet1.SymmetricExceptWith(hashSet);//补

                    hashSet1.UnionWith(hashSet);//并

                    hashSet1.ExceptWith(hashSet);//差

                    hashSet1.IntersectWith(hashSet);//交

                    foreach (var item in hashSet1)
                    {
                        Console.WriteLine(item);
                    }
                    // 找出共同的好友
                }
                hashSet.ToList();

           
                hashSet.Clear();
            }

            {
                //sortedSet排序的集合：去重  而且排序  
                //统计排名--每统计一个就丢进去集合
                Console.WriteLine("***************SortedSet<string>******************");
                SortedSet<string> sortedSet = new SortedSet<string>();
                //IComparer<T> comparer  自定义对象要排序，就用这个指定
                sortedSet.Add("123");
                sortedSet.Add("689");
                sortedSet.Add("456");
                sortedSet.Add("12435");
                sortedSet.Add("12435");
                sortedSet.Add("12435");

                foreach (var item in sortedSet)
                {
                    Console.WriteLine(item);
                }
                Console.WriteLine(sortedSet.Count);
                Console.WriteLine(sortedSet.Contains("12345"));
                {
                    SortedSet<string> sortedSet1 = new SortedSet<string>();
                    sortedSet1.Add("123");
                    sortedSet1.Add("689");
                    sortedSet1.Add("456");
                    sortedSet1.Add("12435");
                    sortedSet1.Add("12435");
                    sortedSet1.Add("12435");
                    sortedSet1.SymmetricExceptWith(sortedSet);//补                
                    sortedSet1.UnionWith(sortedSet);//并              
                    sortedSet1.ExceptWith(sortedSet);//差
                    sortedSet1.IntersectWith(sortedSet);//交
                }

                sortedSet.ToList();
                sortedSet.Clear();
            }
            #endregion

            #region 四、读取&增删都快？ 有 hash散列 字典

            {
                //Hashtable key-value  体积可以动态增加 拿着key计算一个地址，然后放入key - value
                //object-装箱拆箱  如果不同的key得到相同的地址，第二个在前面地址上 + 1
                //查找的时候，如果地址对应数据的key不对，那就 + 1查找。。
                //浪费了空间，Hashtable是基于数组实现
                //查找个数据  一次定位； 增删 一次定位；  增删查改 都很快
                //浪费空间，数据太多，重复定位定位，效率就下去了
                Console.WriteLine("***************Hashtable******************");
                Hashtable table = new Hashtable();
                table.Add("123", "456");
                table[234] = 456;
                table[234] = 567;
                table[32] = 4562;
                table[1] = 456;
                table["eleven"] = 456;
                foreach (DictionaryEntry objDE in table)
                {
                    Console.WriteLine(objDE.Key.ToString());
                    Console.WriteLine(objDE.Value.ToString());
                }
                //线程安全
                Hashtable.Synchronized(table);//只有一个线程写  多个线程读
            }
            {
                //Dictionary 字典：泛型；key - value，增删查改 都很快；有序的
                //  字典不是线程安全 ConcurrentDictionary
                Console.WriteLine("***************Dictionary******************");
                Dictionary<int, string> dic = new Dictionary<int, string>();
                dic.Add(1, "HaHa");
                dic.Add(5, "HoHo");
                dic.Add(3, "HeHe");
                dic.Add(2, "HiHi");
                dic.Add(4, "HuHu1");
                dic[4] = "HuHu";//相同key替换原值
              //dic.Add(4, "HuHu");//相同key,会报错
                foreach (var item in dic)
                {
                    Console.WriteLine($"Key:{item.Key}, Value:{item.Value}");
                }
            }


            {
                //SortedDictionary 排序字典
                Console.WriteLine("***************SortedDictionary******************");
                SortedDictionary<int, string> dic = new SortedDictionary<int, string>();
                dic.Add(1, "HaHa");
                dic.Add(5, "HoHo");
                dic.Add(3, "HeHe");
                dic.Add(2, "HiHi");
                dic.Add(4, "HuHu1");
                dic[4] = "HuHu";//相同key替换原值
               // dic.Add(4, "HuHu");//相同key,会报错
                foreach (var item in dic)
                {
                    Console.WriteLine($"Key:{item.Key}, Value:{item.Value}");
                }
            }


            {
                //SortedList 排序集合
                Console.WriteLine("***************SortedList******************");
                SortedList sortedList = new SortedList();//IComparer
                sortedList.Add("First", "Hello");
                sortedList.Add("Second", "World");
                sortedList.Add("Third", "!");

                sortedList["Third"] = "~~";//相同key替换原值
                sortedList.Add("Fourth", "!");
                sortedList.Add("Fourth", "!");//重复的Key Add会错
                sortedList["Fourth"] = "!!!";
                var keyList = sortedList.GetKeyList();
                var valueList = sortedList.GetValueList();

                sortedList.TrimToSize();//用于最小化集合的内存开销

                sortedList.Remove("Third");
                sortedList.RemoveAt(0);
                sortedList.Clear();
            }
            //ConcurrentQueue 线程安全版本的Queue
            //ConcurrentStack线程安全版本的Stack
            //ConcurrentBag线程安全的对象集合
            //ConcurrentDictionary线程安全的Dictionary
            //BlockingCollection
            #endregion

            Console.ReadKey();
        }
    }
}
