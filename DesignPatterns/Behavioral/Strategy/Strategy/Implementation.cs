namespace Strategy
{
    public class Order
    {
        public Order(int amount, string customer, string name)
        {
            Amount = amount;
            Customer = customer;
            Name = name;
        }

        public int Amount { get; set; }
        public string Customer { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }

        public IExportService? ExportService { get; set; }
        public void Export()
        {
            ExportService?.Export(this);
        }
    }
    public interface IExportService
    {
        void Export(Order order);
    }
    public class JsonExportService : IExportService
    {
        public void Export(Order order)
        {
            Console.WriteLine($"Exporting {order.Name} to JSON");
        }
    }
    public class XmlExportService : IExportService
    {
        public void Export(Order order)
        {
            Console.WriteLine($"Exporting {order.Name} to XML");
        }
    }
    public class CsvExportService : IExportService
    {
        public void Export(Order order)
        {
            Console.WriteLine($"Exporting {order.Name} to CSV");
        }
    }


}
