namespace Iterator
{
    public class Person
    {
        public Person(string name, string country)
        {
            Name = name;
            Country = country;
        }

        public string Name { get; set; }
        public string Country { get; set; }
    }

    public interface IPeopleCollection
    {
        IPeoplIterator CreaateIterator();
    }

    public class PeopleCollection : List<Person>, IPeopleCollection
    {
        public IPeoplIterator CreaateIterator()
        {
            return new PeopleIterator(this);
        }
    }
    public class PeopleIterator : IPeoplIterator
    {
        private PeopleCollection _peopleCollection;
        private int _current;
        public PeopleIterator(PeopleCollection peopleCollection)
        {
            _peopleCollection = peopleCollection;
        }

        public Person CurrentItem
        {
            get { return _peopleCollection.OrderBy(i => i.Name).ToList()[_current]; }
        }

        public bool IsDone
        {
            get { return _current >= _peopleCollection.Count; }
        }

        public Person First()
        {
            _current = 0;
            return _peopleCollection.OrderBy(i => i.Name).ToList()[_current];
        }

        public Person Next()
        {
            _current++;
            if (!IsDone)
                return _peopleCollection.OrderBy(i => i.Name).ToList()[_current];
            else
                return null;
        }
    }
    public interface IPeoplIterator
    {
        Person First();
        Person Next();
        Person CurrentItem { get; }
        bool IsDone { get; }
    }

}
