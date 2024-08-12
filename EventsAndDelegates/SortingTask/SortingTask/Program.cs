using DelegatesAndEvents;

Person[] people = { new Person { Name = "Giorga", Age = 20 }, new Person { Name = "Kuta", Age = 19 }, new Person { Name = "Suka", Age = 21 } };
PersonSorter sorter = new PersonSorter();
sorter.Sort(people, CompareByAge);
foreach (Person person in people)
{
    Console.WriteLine(person.Name + " "+ person.Age);
}

sorter.Sort(people, CompareByName);
foreach (Person person in people)
{
    Console.WriteLine(person.Name + " " + person.Age);
}

static int CompareByName(Person person1, Person person2)
{
    return person1.Name.CompareTo(person2.Name);
}
static int CompareByAge(Person person1, Person person2)
{
    return person1.Age.CompareTo(person2.Age);
}
namespace DelegatesAndEvents
{
    public delegate int Comparisation<T>(T x, T y);

    public class Person
    {
        public int Age { get; set; }
        public string Name { get; set; }
    }
    public class PersonSorter
    {
        public void Sort(Person[] people, Comparisation<Person> comparisation)
        {
            for (int i = 0; i < people.Length; i++)
            {
                for (int j = i + 1; j < people.Length; j++)
                {
                    if (comparisation(people[i], people[j]) > 0)
                    {
                        //swapping
                        var temp = people[i];
                        people[i] = people[j];
                        people[j] = temp;
                    }
                }
            }

        }
    }
}