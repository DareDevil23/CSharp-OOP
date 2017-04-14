using System;

namespace GenericList
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new CustomList<int>();
            list.Add(5);
            Console.WriteLine(list); //5
            list.Add(567);
            list.Add(45);
            list.Add(78);
            Console.WriteLine(list.GetElementAt(2)); //45
            list.RemoveElementAt(1);
            Console.WriteLine(list); //5, 45, 78
            list.InsertAt(0, 4);
            Console.WriteLine(list); //4, 5, 45, 78
            list.InsertAt(4, 555);
            Console.WriteLine(list); //4, 5, 45, 78, 555
            list.InsertAt(3, 999);
            Console.WriteLine(list); //4, 5, 45, 999, 78, 555
            Console.WriteLine(list.Max()); // 999
            Console.WriteLine(list.Min()); //4
            
            list.Clear();
            Console.WriteLine(list.Count); //0
            Console.WriteLine(list.Min()); // InvalidOperation List is empty.
            Console.WriteLine(list);  //
            //list.InsertAt(3, 5);  // InvalidOperation
            list.InsertAt(0, 789);
            Console.WriteLine(list);
            Console.WriteLine(list.Count); // 1
            
        }
    }
}
