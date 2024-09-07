using Observer;

TicketStockService ticketStockService = new ();
TicketResellerService ticketResellerService = new ();
OrderService orderService = new ();

orderService.AddObserver(ticketStockService);
orderService.AddObserver(ticketResellerService);

orderService.CompleteTicektSale(1, 4);
Console.WriteLine("-----------------------");
orderService.RemoveObserver(ticketResellerService);
orderService.CompleteTicektSale(2, 5);
