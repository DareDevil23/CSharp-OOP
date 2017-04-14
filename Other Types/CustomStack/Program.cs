using System;

namespace CustomStack
{
    class Program
    {
        static void Main(string[] args)
        {
            var stack = new CustomStack<int>();
            stack.Push(5);
            stack.Push(255);
            Console.WriteLine(stack.IsEmpty); // false
            stack.Pop();
            Console.WriteLine(stack.Count); //1
            Console.WriteLine(stack); //5
            stack.Clear();
            Console.WriteLine(stack); //empty
            stack.Push(345666667);
            stack.Push(456);
            stack.Push(44445);
            Console.WriteLine(stack.Min()); //456
            Console.WriteLine(stack.Max()); //345666667
            stack.Clear();
            Console.WriteLine(stack);       //empty
            Console.WriteLine(stack.IsEmpty); //true 
        }
    }
}
