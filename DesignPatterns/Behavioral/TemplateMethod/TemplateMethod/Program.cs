using TemplateMethod;

ExchangeMailParser exMailParser = new();
Console.WriteLine(exMailParser.ParseMailBody("asdskmsadldkfasdf11111"));
Console.WriteLine();

ApacheMailParser apMailParser = new();
Console.WriteLine(apMailParser.ParseMailBody("asdskmsadldkfasdf22222"));
Console.WriteLine();

EudoraMailParser edMailParser = new();
Console.WriteLine(edMailParser.ParseMailBody("asdskmsadldkfasdf33333"));
Console.WriteLine();