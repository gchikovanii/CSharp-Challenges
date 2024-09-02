using Facade;

var facade = new DiscountFacade();
Console.WriteLine($"Discount percantage: {facade.GetDiscount(3)}");
Console.WriteLine($"Discount percantage: {facade.GetDiscount(15)}");