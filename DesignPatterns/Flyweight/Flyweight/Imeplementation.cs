﻿namespace Flyweight
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
        //Unshared Concrete Flyweight
        public ICharacter CreateParagraph(List<ICharacter> characters, int location)
        {
            return new Paragraph(location, characters);
        }
    }
    //Unshared Concrete Flyweight
    public class Paragraph : ICharacter
    {
        private int _location;
        private List<ICharacter> _characters = new();

        public Paragraph(int location, List<ICharacter> characters)
        {
            _location = location;
            _characters = characters;
        }

        public void Draw(string fontFamily, int fontSize)
        {
            Console.WriteLine($"Drawing in paragraph at location {_location}");
            foreach (var character in _characters)
            {
                character.Draw(fontFamily, fontSize);
            }
        }
    }
}
