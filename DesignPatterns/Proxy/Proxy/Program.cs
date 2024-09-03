
using Proxy;

Console.WriteLine("Constructing document");
var myDoc = new Document("TestDoc.pdf");
Console.WriteLine("Documnet generated");
myDoc.DisplayDocument();
Console.WriteLine("-----------------------------------");
Console.WriteLine("Document Proxy");
var myDocProxy = new DocumentProxy("TestPtoxyDoc.pdf");
Console.WriteLine("Documnet generated");
myDocProxy.DisplayDocument();