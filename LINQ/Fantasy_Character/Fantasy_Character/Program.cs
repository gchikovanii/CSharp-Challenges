using Fantasy_Character;

List<Character> characters = await Character.FetchCharactersAsync();
var processedCharacters = await Character.ProcessCharactersAsync(characters,3);
await Character.PrintReport(processedCharacters);