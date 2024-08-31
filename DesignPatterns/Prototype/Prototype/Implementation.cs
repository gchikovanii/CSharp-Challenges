namespace Prototype
{
    public class Implementation
    {
        public abstract class Person
        {
            public abstract string Name { get; set; }
            public abstract Person Clone();
        }
        public class Manager : Person
        {

            public override string Name { get ; set; }
            public Manager(string name)
            {
                Name = name;
            }
            public override Person Clone()
            {
                //shallow copy
                return (Person)MemberwiseClone();
            }
        }
        public class Employee : Person
        {

            public override string Name { get; set; }
            public Manager Manager { get; set; }
            public Employee(string name, Manager manager)
            {
                Name = name;
                Manager = manager;
            }
            public override Person Clone()
            {
                //shallow copy
                return (Person)MemberwiseClone();
            }
        }

    }
}
