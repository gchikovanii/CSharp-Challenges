using static Prototype.Implementation;

var manager = new Manager("Giorgi");
var managerClone = (Manager)manager.Clone();
Console.WriteLine($"Manager waas cloned: {managerClone.Name}");

var emp = new Employee("Georginio", managerClone);
/*var empClone = (Employee)emp.Clone();*/ //shallow copy
var empClone = (Employee)emp.Clone(); //deep copy
Console.WriteLine($"Employee waas cloned: {empClone.Name} with Manager {empClone.Manager.Name}");

//change the manager name
managerClone.Name = "Susana";
Console.WriteLine($"Employee waas cloned: {empClone.Name} with Manager {empClone.Manager.Name}");
