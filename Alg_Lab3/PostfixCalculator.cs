using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Alg_Lab3.QueueFolder;

namespace Alg_Lab3
{
    public class PostfixCalculator
    {
        MyStack stack = new MyStack();
        MyQueue queue = new MyQueue();
        static Dictionary<string, int> operations = new Dictionary<string, int> { { "ln" , 1 },
            { "sin" , 1}, { "cos" , 1 }, { "sqrt" , 1 }, { "^" , 2 }, { "*" , 3 }, { "/" , 3}, { "+" , 5}, { "-" , 4 } };
        List<string> elements = new List<string>();
        bool state = true;
        string message = "Кажется не хватает скобок.";
        private StringBuilder postfixStr = new StringBuilder();
        public static Dictionary<string, int> Operations { get { return operations; } }

        public PostfixCalculator(string expression) 
        {
            elements = expression.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList<string>();
        }

        public string GetPostfixStr()
        {
            return postfixStr.ToString();
        }

        private void AnalyzeParenthesisExpressions()
        {
            foreach (string element in elements)
            {
                if(element.Equals("("))
                {
                    stack.Push("(");
                }
                else if(element.Equals(")"))
                {
                    if(stack.Top().ToString().Equals("("))
                    {
                        stack.Pop();
                    }
                    else
                    {
                        state = false;
                    }
                }
            }
            state = stack.IsEmpty;
        }

        private void ConvertInPostfix()
        {
            foreach (string element in elements) 
            {
                if(double.TryParse(element, out double number))
                    queue.Enqueue(number);
                else if (operations.ContainsKey(element))
                    CheckOperation(element);
                else if (element.Equals("("))
                    stack.Push("(");
                else if (element.Equals(")"))
                {
                    while (true)
                    {
                        if (stack.Top().ToString().Equals("(")) break;
                        queue.Enqueue(stack.Pop());
                    }
                    stack.Pop();
                }
            }
            Unload();
        }

        private void CheckOperation(string element)
        {
            if (stack.IsEmpty)
                stack.Push(element);
            else
            {
                if (stack.Top().ToString().Equals("(") || operations[element] < operations[stack.Top().ToString()])
                    stack.Push(element);
                else
                {
                    if (operations[element] >= operations[stack.Top().ToString()])
                    {
                        while(true)
                        {
                            if (stack.IsEmpty) break;
                            if (stack.Top().ToString().Equals("(") || operations[element] < operations[stack.Top().ToString()]) break;
                            queue.Enqueue(stack.Pop());
                        }
                        stack.Push(element);
                    }
                }
            }
        }

        private void Unload()
        {
            while(!stack.IsEmpty)
            {
                queue.Enqueue(stack.Pop());
            }
        }

        public void Calculate(bool isPostfixExp)
        {
            if (!isPostfixExp)
            {
                AnalyzeParenthesisExpressions();
                if (!state) return;
                ConvertInPostfix();
            }
            double op1;
            double op2;
            while (!queue.IsEmpty)
            {
                string element = queue.Dequeue().ToString();
                AddPostfixStr(element);
                switch (element)
                {
                    case "+":
                        op1 = Convert.ToDouble(stack.Pop());
                        op2 = Convert.ToDouble(stack.Pop());
                        stack.Push(op1 + op2);
                        break;
                    case "-":
                        op1 = Convert.ToDouble(stack.Pop());
                        op2 = Convert.ToDouble(stack.Pop());
                        stack.Push(op2 - op1);
                        break;
                    case "*":
                        op1 = Convert.ToDouble(stack.Pop());
                        op2 = Convert.ToDouble(stack.Pop());
                        stack.Push(op1 * op2);
                        break;
                    case "/":
                        op1 = Convert.ToDouble(stack.Pop());
                        op2 = Convert.ToDouble(stack.Pop());
                        stack.Push(op2 / op1);
                        break;
                    case "^":
                        op1 = Convert.ToDouble(stack.Pop());
                        op2 = Convert.ToDouble(stack.Pop());
                        stack.Push(Math.Pow(op2, op1));
                        break;
                    case "ln":
                        op1 = Convert.ToDouble(stack.Pop());
                        stack.Push(Math.Log(op1));
                        break;
                    case "sin":
                        op1 = Convert.ToDouble(stack.Pop());
                        stack.Push(Math.Sin(op1));
                        break;
                    case "cos":
                        op1 = Convert.ToDouble(stack.Pop());
                        stack.Push(Math.Cos(op1));
                        break;
                    case "sqrt":
                        op1 = Convert.ToDouble(stack.Pop());
                        stack.Push(Math.Sqrt(op1));
                        break;
                    default:
                        stack.Push(element);
                        break;
                }
            }
        }

        private void AddPostfixStr(string element)
        {
            if (postfixStr.Length == 0)
                postfixStr.Append(element + " ");
            else
                postfixStr.Append(element + " ");
        }

        public string GetResult()
        {
            if(state)
                return stack.Pop().ToString();
            return message;
        }
    }
}
