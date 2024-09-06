
using ChainOfResponsibility;
using System.ComponentModel.DataAnnotations;

Document validDoc = new Document("Our new text documnet",DateTimeOffset.UtcNow,true,true);
.Document invalidDoc = new Document("Our new text documnet N2",DateTimeOffset.UtcNow,false,true);

var docHandlerChan = new DocumentTitleHandler();
docHandlerChan.SetSuccessor(new DocumentLastModifiedHandler()).SetSuccessor(new DocumentapprovedbyLitigationHandler())
    .SetSuccessor(new DocumentapprovedbyManagementHandler());
try
{
    docHandlerChan.Handle(validDoc);
    Console.WriteLine("Document is valid");
    docHandlerChan.Handle(invalidDoc);
    Console.WriteLine("Document is invalid");
}
catch (ValidationException ex)
{
    Console.WriteLine(ex.Message);
}


