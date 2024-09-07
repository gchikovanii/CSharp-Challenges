namespace Observer
{
    public class TicketChange
    {
        public TicketChange(int amount, int artistId)
        {
            Amount = amount;
            ArtistId = artistId;
        }

        public int Amount { get; set; }
        public int ArtistId { get; set; }
    }
    public abstract class TicketChangeNotifier
    {
        private List<ITicketChangeListener> _observers = new();
        public void AddObserver(ITicketChangeListener listener) 
        {
            _observers.Add(listener);
        }
        public void RemoveObserver(ITicketChangeListener listener)
        {
            _observers.Remove(listener);
        }

        public void Notify(TicketChange ticketChange)
        {
            foreach (var obs in _observers)
            {
                obs.ReceiveTicketChangeNotification(ticketChange);
            }
        }

    }

    public interface ITicketChangeListener
    {
        void ReceiveTicketChangeNotification(TicketChange ticketChange);
    }


    public class OrderService : TicketChangeNotifier
    {
        public void CompleteTicektSale(int artistId, int amount)
        {
            //working with Database
            Console.WriteLine($"{nameof(OrderService)} is changing its state");
            // notify observer
            Console.WriteLine($"{nameof(OrderService)} notifying observer");
            Notify(new TicketChange(artistId, amount));
        }
    }

    public class TicketResellerService : ITicketChangeListener
    {
        public void ReceiveTicketChangeNotification(TicketChange ticketChange)
        {
            Console.WriteLine($"{nameof(TicketResellerService)} notified of ticket change: artist {ticketChange.ArtistId} and amount: {ticketChange.Amount}");
        }
    }
    public class TicketStockService : ITicketChangeListener
    {
        public void ReceiveTicketChangeNotification(TicketChange ticketChange)
        {
            Console.WriteLine($"{nameof(TicketStockService)} notified of ticket change: artist {ticketChange.ArtistId} and amount: {ticketChange.Amount}");
        }
    }

}
