using Iterator;

PeopleCollection people = new();

people.Add(new Person("Alan Pizz", "Fra"));
people.Add(new Person("Besarion Gabashvili", "Geo"));
people.Add(new Person("Ed Mylet", "Eng"));
people.Add(new Person("Jordan Peterson", "Can"));

var peopleIterator = people.CreaateIterator();

for (Person person = peopleIterator.First(); !peopleIterator.IsDone; person = peopleIterator.Next())
{
    Console.WriteLine(person.Name);
}