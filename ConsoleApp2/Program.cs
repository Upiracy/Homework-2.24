using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    interface IProblem
    {
        void Execute(string str);
    }

    class PrimeProblem : IProblem
    {
        List<int> primes;
        int max { get => primes[primes.Count - 1]; }

        public PrimeProblem()
        {
            primes = new List<int>();
            primes.Add(2);
        }

        void GetNext()
        {
            for(int i = max + 1; ; i++)
            {
                if(IsPrime(i))
                {
                    primes.Add(i);
                    return;
                }
            }
        }

        bool IsPrime(int n)
        {
            foreach(int i in primes)
            {
                if (n % i == 0) return false;
            }
            return true;
        }

        public void Execute(string str)
        {
            int n = int.Parse(str);
            for(;max * max <= n; )
            {
                GetNext();
            }
            foreach (int i in primes)
            {
                if (n % i == 0) Console.Write(i + ";");
            }
            Console.Write("\n");
        }

        public void Debug()
        {
            Console.Write("Debug: ");
            foreach (int i in primes)
            {
                Console.Write(i + ";");
            }
        }
    }
    class ArrayProblem : IProblem
    {
        public void Execute(string str)
        {
            string[] inputs = str.Split(' ');
            int[] array = new int[inputs.Length];
            int max = int.MinValue, min = int.MaxValue, sum = 0;
            foreach(string input in inputs)
            {
                if (input == "") continue;
                int n = int.Parse(input);
                if (max < n) max = n;
                if (min > n) min = n;
                sum += n;
            }
            Console.WriteLine("最大值: " + max + "; 最小值: " + min + "; 平均数: " + (float)sum / inputs.Length + "; 总和: " + sum);
        }
    }
    class ErichsenProblem : IProblem
    {
        int[] primes = new int[] { 2, 3, 5, 7 };
        public void Execute(string str)
        {
            bool[] all = new bool[101];
            foreach(int i in primes)
            {
                for(int j = i + i; j <= 100; j += i)
                {
                    all[j] = true;
                }
            }
            for(int i = 2; i <= 100; i++)
            {
                if (!all[i]) Console.Write(i + ",");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("输入P进入任务1; 输入A进入任务2; 输入D进入任务3; 输入H查看帮助; 输入E退出");
            int task = 0;
            PrimeProblem pp = new PrimeProblem();
            ArrayProblem ap = new ArrayProblem();
            ErichsenProblem ep = new ErichsenProblem();
            for (; ; )
            {
                string str = Console.ReadLine();
                if (str == "P")
                {
                    Console.WriteLine("任务:输出一个整数的所有质因子");
                    task = 0;
                }
                else if(str == "A")
                {
                    Console.WriteLine("任务:输出整数数组的最大值、最小值、平均数以及和");
                    task = 1;
                }
                else if(str == "D")
                {
                    Console.WriteLine("任务:求2至100的素数(此任务不需要输入)");
                    task = 2;
                }
                else if(str == "H")
                {
                    Console.WriteLine("输入P进入任务1; 输入A进入任务2; 输入D进入任务3; 输入H查看帮助; 输入E退出");
                }
                else if(str == "E")
                {
                    break;
                }
                else switch(task)
                {
                    case 0:
                        pp.Execute(str);
                        break;
                    case 1:
                        ap.Execute(str);
                        break;
                    case 2:
                        ep.Execute(str);
                        break;
                }
            }
        }
    }
}
