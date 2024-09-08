namespace Visitor
{
    public class Customer : IElement
    {
        public Customer(decimal amount, string name)
        {
            Amount = amount;
            Name = name;
        }

        public decimal Amount { get; set; }
        public decimal Discount { get; set; }
        public string Name { get; set; }

        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
            Console.WriteLine($"Visited {nameof(Customer)} - discount is: {Discount}");
        }
    }
    public class Employee : IElement
    {
        public Employee(int yEmp, string name)
        {
            YearsEmployeed = yEmp;
            Name = name;
        }

        public int YearsEmployeed { get; set; }
        public decimal Discount { get; set; }
        public string Name { get; set; }
        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
            Console.WriteLine($"Visited {nameof(Employee)} - discount is: {Discount}");
        }
    }

    public interface IVisitor
    {
        void Visit(IElement element);
    }
    public interface IElement
    {
        void Accept(IVisitor visitor);
    }

    public class DiscountVisitor : IVisitor
    {
        public decimal TotalDiscount { get; set; }

        public void Visit(IElement element)
        {
            if (element is Customer)
                VisitCustomer((Customer)element);
            else if(element is Employee)
                VisitEmployee((Employee)element);
        }

        private void VisitCustomer(Customer customer)
        {
            var discount = customer.Amount / 10;
            customer.Discount = discount;
            TotalDiscount += discount;
        }

        private void VisitEmployee(Employee employee)
        {
            var discount = employee.YearsEmployeed < 10 ? 100 : 200;
            employee.Discount = discount;
            TotalDiscount += discount;
        }
    }
    public class Container
    {
        public List<Employee> Employees { get; set; } = new();
        public List<Customer> Customers { get; set; } = new();
        public void Accept(IVisitor visitor) 
        {
            foreach (var emp in Employees)
            {
                emp.Accept(visitor);
            }
            foreach (var cust in Customers)
            {
                cust.Accept(visitor);
            }
        }
    }
}
