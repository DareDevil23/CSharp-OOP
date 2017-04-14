using System;
using AttributePropertyValidation.Attributes;
using AttributePropertyValidation.Models;
using System.Collections.Generic;
using System.Linq;

namespace AttributePropertyValidation
{
    class Program
    {
        static void Main(string[] args)
        {
            var warriors = new List<Warrior>()
            {
                new Warrior()
                {
                    Name = "Gosho",
                    Weapon = new Weapon()
                    {
                        Name = "Pistol" ,
                        Damage = 20
                    }
                },
                new Warrior() {Name = "Gosho" },
                new Warrior() { Weapon = new Weapon()},
                new Warrior() { }
            };

            try
            {
                ValidateProperties(warriors);
            }
            catch (AggregateException ex)
            {
                foreach (var innerException in ex.InnerExceptions)
                {
                    Console.WriteLine(innerException.Message);
                }
            }
        }

        private static void ValidateProperties(List<Warrior> warriors)
        {
            Type typeData = typeof(Warrior);
            var requiredProperties = typeData.GetProperties().Where(p => p.GetCustomAttributes(false).Any(a => a is RequiredAttribute));

            var exceptions = new List<Exception>();

            foreach (var warrior in warriors)
            {
                foreach (var requiredPropertie in requiredProperties)
                {
                    if (requiredPropertie.GetValue(warrior) == null)
                    {
                        Exception exception = new ArgumentNullException(requiredPropertie.Name, "Argument can not be null.");
                        exceptions.Add(exception);
                    }
                }
            }

            if (exceptions.Count() > 0)
            {
                throw new AggregateException(exceptions);
            }
        }
    }
}
