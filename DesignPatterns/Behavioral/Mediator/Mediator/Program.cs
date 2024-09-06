using Mediator;

TeamChatRoom teamChatRoom = new();

var gio = new Lawyer("Giorgi");
var luka = new Lawyer("Luka");
var oto = new Lawyer("Oto");
var beka = new Lawyer("Beka");

teamChatRoom.Register(gio);
teamChatRoom.Register(luka);
teamChatRoom.Register(oto);
teamChatRoom.Register(beka);
gio.Send("Giorgiii says hi");
luka.Send("Hello giys from luka");
oto.Send("Giorgi", "Hallo");

Console.WriteLine("---------------------");
beka.SendTo<Lawyer>("Task is done!!!");