using Alg_Lab3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alg_Lab3.InterfaceFolder
{
    public class Interface
    {
        //int[] values = new int[] { ImportantData.MinValue, ImportantData.MaxValue, ImportantData.MaxN, ImportantData.Step };
        public void Work()
        {
            //WriteSetting();
            //ChooseChangeSetting();

            WriteStartAlgorithm();
            ChooseNext();
        }
        //private void WriteSetting()
        //{
        //    Console.WriteLine(TextInterface.Heaps["setting"]);  
        //    for(int i = 0; i < TextInterface.TextSetting.Length; i++)
        //    {
        //        Console.ForegroundColor = ConsoleColor.Cyan;
        //        Console.Write(TextInterface.TextSetting[i]);
        //        Console.ForegroundColor = ConsoleColor.Green;
        //        //Console.WriteLine(values[i]);
        //    }
        //    WritePath();
        //    Console.ForegroundColor = ConsoleColor.White;
        //}

        private void WritePath()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("Путь сохранения результата : ");
            Console.ForegroundColor = ConsoleColor.Green;
            //Console.WriteLine(ImportantData.Path);
        }

        //private void ChooseChangeSetting()
        //{
        //    Console.ForegroundColor = ConsoleColor.Gray;
        //    Console.WriteLine("Изменить настройки алгоритма - 1\nИзменить путь сохранения результата - 2\nПродолжить с текущими настройками - 0");
        //    Console.ForegroundColor = ConsoleColor.White;
        //    string? answer = Console.ReadLine();
        //    switch (answer)
        //    {
        //        case ("1"):
        //            ChangeSetting();
        //            break;
        //        case ("2"):
        //            ChangePath(); 
        //            break;
        //        case ("0"):
        //            return;
        //        default:
        //            Console.WriteLine("Необходим ваш точный ответ.");
        //            ChooseChangeSetting();
        //            break;
        //    }
        //}

        //private void ChangeSetting()
        //{
        //    Console.Clear();
        //    Console.WriteLine(TextInterface.Heaps["setting"]);
        //    int i = 0;
        //    while(i < TextInterface.TextSetting.Length)
        //    {
        //        Console.ForegroundColor = ConsoleColor.Cyan;
        //        Console.Write(TextInterface.TextSetting[i]);
        //        Console.ForegroundColor = ConsoleColor.Green;
        //        string? answer = Console.ReadLine();
        //        CheckError.IsInt(answer);
        //        if (CheckError.Check)
        //        {
        //            values[i] = CheckError.IntResult;
        //            i++;
        //        }
        //    }
        //    RewriteImportantData();
        //    CheckError.IsMinMax(ImportantData.MinValue, ImportantData.MaxValue);
        //    if(!CheckError.Check)
        //    {
        //        ChangeSetting();
        //    }
        //    ChooseChangeSetting();
        //}

        //private void ChangePath()
        //{
        //    Console.Clear();
        //    Console.WriteLine(TextInterface.Heaps["path"]);
        //    Console.ForegroundColor = ConsoleColor.Cyan;
        //    Console.Write("Путь сохранения результата :");
        //    Console.ForegroundColor = ConsoleColor.Green;
        //    string? answer = Console.ReadLine();
        //    CheckError.IsRightPath(answer);
        //    if (CheckError.Check)
        //        ImportantData.Path = answer;
        //    else
        //    {
        //        Thread.Sleep(500);
        //        ChangePath();
        //    }
        //    ChooseChangeSetting();
        //}

        //private void RewriteImportantData()
        //{
        //    ImportantData.MinValue = values[0];
        //    ImportantData.MaxValue = values[1];
        //    ImportantData.MaxN = values[2];
        //    ImportantData.Step = values[3];
        //}

        private void WriteStartAlgorithm()
        {
            Console.Clear();
            //WriteSetting();
            // Console.WriteLine(TextInterface.Heaps["algorithm"]);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(TextInterface.ListAlgorithms);
            Console.ForegroundColor = ConsoleColor.White;
        }

        private void ChooseNext(string? answer = null)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(TextInterface.EndListAlgo);
            Console.ForegroundColor = ConsoleColor.White;
            if (answer == null) answer = Console.ReadLine();
            switch (answer)
            {
                case "1.1":
                    Console.WriteLine(TextInterface.StackWithFile);
                    string? answer1 = Console.ReadLine();
                    if (answer1 == "0") Work();
                    CheckErrors.IsRightPath(answer1);
                    if (CheckErrors.Check)
                    {
                        StackController stackController = new StackController();
                        stackController.StartWorkWithFile(answer1);
                    }
                    ChooseNext();
                    break;
                case "1.2":
                    Console.WriteLine(TextInterface.CommandsForStack);
                    string? answer2 = Console.ReadLine();
                    if (answer2 == "0") Work();
                    CheckErrors.IsRightCommandsForStack(answer2);
                    if (CheckErrors.Check)
                    {
                        string[] commands = answer2.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                        StackController stackController = new StackController();
                        stackController.StartWorkWithList(commands);
                        ChooseNext("1.2");
                    }
                    else ChooseNext("1.2");
                    ChooseNext();
                    break;
                case "0":
                    Work();
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Неверная команда, попробуйте еще раз");
                    Console.ForegroundColor = ConsoleColor.White;
                    ChooseNext();
                    break;
            }
        }
    }
}
