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

Console.WriteLine("-----------------------------------");

//Chaining with secure proxy
Console.WriteLine("Constructing protected proxy document");
var protectedProxy = new ProtectedDocumentProxy("TestDoc.pdf", "Viewer");
Console.WriteLine("Secure Proxy Documnet generated");
protectedProxy.DisplayDocument();