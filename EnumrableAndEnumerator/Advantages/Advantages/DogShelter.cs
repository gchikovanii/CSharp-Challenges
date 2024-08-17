using System.Collections;

namespace Advantages
{
    internal class DogShelter : IEnumerable<Dog>
    {
        public List<Dog> Dogs;
        public DogShelter()
        {
            Dogs = new List<Dog>()
            {
                new Dog("Lisa", true),
                new Dog("Batu", true),
                new Dog("Mural", false),
                new Dog("Menigo", true),
                new Dog("Marama", false)
            };
        }

        public IEnumerator<Dog> GetEnumerator()
        {
            return Dogs.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}

