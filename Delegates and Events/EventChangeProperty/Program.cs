using System;

namespace EventChangeProperty
{
    class Program
    {
        static void Main(string[] args)
        {
            var student = new Student("Lena", 22);

            student.onStudentPropertyChange += (Student sender, StudentPropChangeEventArgs eventArgs) =>
            {
                Console.WriteLine($"{sender.Name}'s {eventArgs.propName} has changed from {eventArgs.OldProp} to {eventArgs.NewProp}");
            };

            student.Age = 33;
            student.Age = 23;
            student.Name = "Alla";
        }
    }
}
