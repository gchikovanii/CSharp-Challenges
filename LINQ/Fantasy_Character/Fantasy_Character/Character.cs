namespace Fantasy_Character
{
    public class Character
    {
        public Character(int id, string name, Family family, int level, double power)
        {
            Id = id;
            Name = name;
            Level = level;
            Power = power;
            Family = family;
        }

        public int Id { get; private set; }
        public string Name { get; private set; }
        public Family Family { get; private set; }
        public int Level { get; private set; }
        public double Power { get; private set; }

        public static async Task<List<Character>> FetchCharactersAsync()
        {
            await Task.Delay(3000);
            return new List<Character>()
            {
                new Character(1,"Super Man",Family.Middle,4,70),
                new Character(2,"Spider Man",Family.Low,5,75),
                new Character(3,"BatMan",Family.Royal,6,73),
                new Character(4,"Real Man",Family.Royal,1,80),
                new Character(5,"Top Man",Family.Low,2,69),
                new Character(6,"Real G",Family.Royal,10,100),
            };
        }

        public static async Task<Dictionary<string, List<Character>>> ProcessCharactersAsync(List<Character> characters, int fromLevel)
        {
            return await Task.Run(() =>
            {
                return characters.Where(i => i.Level > fromLevel)
               .OrderByDescending(i => i.Power)
               .GroupBy(i => i.Family.ToString())
               .ToDictionary(i => i.Key, i => i.ToList());
            });
        }
        public static async Task PrintReport(Dictionary<string, List<Character>> processedCharacters)
        {
            await Task.Run(() =>
            {
                foreach (var keys in processedCharacters)
                {
                    Console.WriteLine($"**{keys.Key}s**");
                    foreach (var character in keys.Value)
                    {
                        Console.WriteLine($"{character.Name} - Level {character.Level} - Power: {character.Power}, Familly - {character.Family}");
                    }
                }
            });
        }
    }
}
