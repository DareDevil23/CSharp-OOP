using System;

namespace EventChangeProperty
{
    public delegate void onStudentPropChangeEventHendler(Student student, StudentPropChangeEventArgs args);

    public class Student
    {
        public event onStudentPropChangeEventHendler onStudentPropertyChange;

        private string name;
        private int age;

        public Student(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public string Name
        {
            get { return this.name; }

            set
            {             
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Name can't be null or empty.");
                }

                if (this.onStudentPropertyChange != null)
                {
                    this.onStudentPropertyChange(this, new StudentPropChangeEventArgs(nameof(this.name),this.name, value));
                }
                this.name = value;
            }
        }

        public int Age
        {
            get { return this.age; }
            set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentOutOfRangeException("The age must be in range [0 - 100].");
                }

                if (this.onStudentPropertyChange != null)
                {
                    this.onStudentPropertyChange(this, new StudentPropChangeEventArgs(nameof(this.age),this.age, value));
                }

                this.age = value;
            }
        }

    }
}
