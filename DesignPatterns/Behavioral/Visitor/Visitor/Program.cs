using Visitor;

var container = new Container();
container.Customers.Add(new Customer(500, "Giorgi"));
container.Customers.Add(new Customer(1000, "Sako"));
container.Customers.Add(new Customer(350, "Gozanoyi"));
container.Employees.Add(new Employee(15,"Kristopher"));
container.Employees.Add(new Employee(10,"Katie"));

DiscountVisitor visitor = new();

container.Accept(visitor);
Console.WriteLine($"Total Discount: {visitor.TotalDiscount}");