using System.Diagnostics;
using Lab_Alg_1;
using static Alg_Lab3.ImportData;

namespace Alg_Lab3.QueueFolder;

public class TimerForQueue
    {

        private static List<int> _vectorOfCommands = new List<int>();
        private static int _countOfEnqueue = 0;
        private static int _countOfDequeue = 0;
        private static MyStack myStack = new MyStack();


        public static void WorkingQueue()
        {
            double[] results = new double[maxN];
            CreateVector(maxN);
            var watсh = new Stopwatch();
            for (int n = 1; n <= maxN; n++)
            {
                myStack.Clear();
                watсh.Reset();
                double sumWorks = 0;
                int[] vector = SetVector(n);
                for (int count = 0; count < 5; count++)
                {
                    watсh.Start();
                    DoQueue(vector);
                    watсh.Stop();
                    double s = (double)watсh.Elapsed.TotalSeconds;
                    Console.WriteLine($"n = {n} : {s.ToString("F8")}");
                    sumWorks += s;
                }
                results[n - 1] = (double)sumWorks / 5.0;
            }
            FileProcessing fileProcessing = new FileProcessing();
            File.WriteAllLines(path + "\\QueueData" + ".csv", fileProcessing.GetValues(results, step));
        }

        private static void DoQueue(int[] vector)
        {
            foreach (int num in vector)
            {
                switch (num)
                {
                    case 1:
                        myStack.Push(num);
                        break;
                    case 2:
                        myStack.Pop();
                        break;
                    case 3:
                        int j = Convert.ToInt32(myStack.Top());
                        break;
                    case 4:
                        bool fl = myStack.IsEmpty;
                        break;
                    case 5:
                        myStack.Print();
                        break;
                }
            }
        }

        private static int[] SetVector(int n)
        {
            int[] newVector = new int[n];
            for (int i = 0; i < n; i++)
            {
                newVector[i] = _vectorOfCommands[i];
            }
            return newVector;
        }

        private static void CreateVector(int n)
        {
            Random random = new Random();
            for (int i = 0; i < n; i++)
            {
                if (i == 0)
                {
                    _vectorOfCommands.Add(1);
                    _countOfEnqueue = 1;
                    continue;
                }
                int command = random.Next(1, 6);
                if (command == 2 && _countOfEnqueue <= _countOfDequeue)
                {
                    _vectorOfCommands.Add(4);
                }
                else if (command == 1)
                {
                    _vectorOfCommands.Add(1);
                    _countOfEnqueue += 1;
                }
                else if (command == 2)
                {
                    _vectorOfCommands.Add(2);
                    _countOfDequeue += 1;
                }
                else if (_countOfDequeue == _countOfEnqueue && command == 3)
                {
                    _vectorOfCommands.Add(4);
                }
                else
                {
                    _vectorOfCommands.Add(command);
                }
            }
        }
    }