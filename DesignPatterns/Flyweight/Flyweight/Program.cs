using Flyweight;

var characters = "abba";
var characterFacotyr = new CharacterFactory();

var charObj = characterFacotyr.GetCharacter(characters[0]);
charObj?.Draw("Sant-serif", 16);

charObj = characterFacotyr.GetCharacter(characters[1]);
charObj?.Draw("Arial", 18);

charObj = characterFacotyr.GetCharacter(characters[2]);
charObj?.Draw("Google Fonts Default", 14);

charObj = characterFacotyr.GetCharacter(characters[3]);
charObj?.Draw("Mememento", 12);
