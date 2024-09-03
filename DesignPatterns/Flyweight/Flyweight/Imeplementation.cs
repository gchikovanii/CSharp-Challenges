namespace Flyweight
{
    public interface ICharacter
    {
        void Draw(string fontFamily, int fontSize);
    }

    public class CharacterA : ICharacter
    {
        private char _actualChar = 'a';
        private string _fontFamily = string.Empty;
        private int _fontSize;
        public void Draw(string fontFamily, int fontSize)
        {
            _fontFamily = fontFamily;
            _fontSize = fontSize;
            Console.WriteLine($"Drawing {_actualChar} -> {_fontFamily} - {fontSize}");
        }
    }
    public class CharacterB : ICharacter
    {
        private char _actualChar = 'b';
        private string _fontFamily = string.Empty;
        private int _fontSize;
        public void Draw(string fontFamily, int fontSize)
        {
            _fontFamily = fontFamily;
            _fontSize = fontSize;
            Console.WriteLine($"Drawing {_actualChar} -> {_fontFamily} - {fontSize}");
        }
    }

    public class CharacterFactory
    {
        private readonly Dictionary<char, ICharacter> _characters = new();
        public ICharacter? GetCharacter(char character)
        {
            if (_characters.ContainsKey(character))
            {
                Console.WriteLine("Character reuse");
                return _characters[character];
            }
            switch (character)
            {
                case 'a':
                    _characters[character] = new CharacterA();
                    return _characters[character];
                case 'b':
                    _characters[character] = new CharacterB();
                    return _characters[character];
                default:
                    break;
            }
            return null;
        }
    }

}
