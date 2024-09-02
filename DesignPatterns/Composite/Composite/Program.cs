using static Composite.Implementation;

var root = new CustomDirectory("root",0);
var topLevelFile = new CustomFile("toplevel.txt",100);
var topLevelDir1 = new CustomDirectory("topLevelDir1", 8);
var topLevelDir2 = new CustomDirectory("topLevelDir2", 8);

root.AddFileItem(topLevelFile);
root.AddFileItem(topLevelDir1);
root.AddFileItem(topLevelDir2);

var subLevelFiles1 = new CustomFile("sublevel1.txt", 300);
var subLevelFiles2 = new CustomFile("sublevel2.txt", 400);

topLevelDir1.AddFileItem(subLevelFiles1);
topLevelDir2.AddFileItem(subLevelFiles2);

Console.WriteLine($"TopLevelDir1 - {topLevelDir1.GetSize()}");
Console.WriteLine($"TopLevelDir2 - {topLevelDir2.GetSize()}");
Console.WriteLine($"Root - {root.GetSize()}");