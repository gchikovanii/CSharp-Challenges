
using static Decorator.Implementation;

var cloudMailService = new CloudMailService();
cloudMailService.SendMail("Hi there. ");

var onPermison = new OnPermissionMailServie();
onPermison.SendMail("Hi there perm. ");

var statiscticDecorator = new StatisticsDecorator(cloudMailService);
statiscticDecorator.SendMail($"Sending via {nameof(StatisticsDecorator)}");

var messageDatabaseDecorator = new DatabaseDecorator(onPermison);
messageDatabaseDecorator.SendMail($"Meesage 1 from {nameof(DatabaseDecorator)}");
messageDatabaseDecorator.SendMail($"Message 2 from {nameof(DatabaseDecorator)}");
foreach (var message in messageDatabaseDecorator.SentMessages)
{
    Console.WriteLine("Stored messages " + message);
}