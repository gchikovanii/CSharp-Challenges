namespace Advantages
{
    public class Dog
    {
        public Dog(string name, bool isGoodBoy)
        {
            Name = name;
            IsGoodBoy = isGoodBoy;
        }

        public string Name { get; set; }
        public bool IsGoodBoy { get; set; }
        public void GiveThreat(int numberOfThreats)
        {
            Console.WriteLine($"Is {Name} good dog? - {(IsGoodBoy ? "Yes" : "No")}. Okay we can feed {Name} {numberOfThreats} times");
        }
    }
}
